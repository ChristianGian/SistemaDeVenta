using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using CapaNegocio;
using Entidad.Cache;
using CapaPresentacion.Reportes;

namespace CapaPresentacion.FormHijos
{
    public partial class FormVenta : Form
    {
        //Campos
        private readonly NVenta venta = new NVenta();
        private readonly NDetalleVenta detalle = new NDetalleVenta();
        private EVenta entiVenta;
        private EDetalleVenta entiDetalle;

        private decimal totalPagado = 0;

        public FormVenta()
        {
            InitializeComponent();
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
            MostrarVenta();
            Deshabilitar();
        }

        private void MostrarVenta()
        {
            var lista = venta.MostrarVenta();
            lblTotalRegistro.Text = $"Total registro: {lista.Count}";

            dgvVentas.AutoGenerateColumns = false;
            dgvVentas.DataSource = lista;

            dgvVentas.Columns[0].DataPropertyName = "IdVenta";
            dgvVentas.Columns[1].DataPropertyName = "IdCliente";
            dgvVentas.Columns[2].DataPropertyName = "Cliente";
            dgvVentas.Columns[3].DataPropertyName = "IdTrabajador";
            dgvVentas.Columns[4].DataPropertyName = "Trabajador";
            dgvVentas.Columns[5].DataPropertyName = "Fecha";
            dgvVentas.Columns[6].DataPropertyName = "TipoComprobante";
            dgvVentas.Columns[7].DataPropertyName = "Serie";
            dgvVentas.Columns[8].DataPropertyName = "Correlativo";
            dgvVentas.Columns[9].DataPropertyName = "Igv";
            dgvVentas.Columns[10].DataPropertyName = "Total";

            if (lista.Count == 0)
                MessageBox.Show("Noy hay registros de Ventas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMostrarVentas_Click(object sender, EventArgs e)
        {
            MostrarVenta();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecInicio = dtpFecInicio.Value;
            DateTime fecFin = dtpFecFin.Value;

            var lista = venta.BuscarEntreFechasVenta(fecInicio, fecFin);
            lblTotalRegistro.Text = $"Total registro: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvVentas.AutoGenerateColumns = false;
                dgvVentas.DataSource = lista;

                dgvVentas.Columns[0].DataPropertyName = "IdVenta";
                dgvVentas.Columns[1].DataPropertyName = "IdCliente";
                dgvVentas.Columns[2].DataPropertyName = "Cliente";
                dgvVentas.Columns[3].DataPropertyName = "IdTrabajador";
                dgvVentas.Columns[4].DataPropertyName = "Trabajador";
                dgvVentas.Columns[5].DataPropertyName = "Fecha";
                dgvVentas.Columns[6].DataPropertyName = "TipoComprobante";
                dgvVentas.Columns[7].DataPropertyName = "Serie";
                dgvVentas.Columns[8].DataPropertyName = "Correlativo";
                dgvVentas.Columns[9].DataPropertyName = "Igv";
                dgvVentas.Columns[10].DataPropertyName = "Total";
            }
            else
            {
                MessageBox.Show("Noy hay registros entre esas fechas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarDetalle()
        {
            int idVenta = Convert.ToInt32(txtIdVenta.Text);
            var lista = detalle.MostrarDetalleVenta(idVenta);
            lblTotalRegistro.Text = $"Total registro: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvDetalleVentas2.Visible = true;
                dgvDetalleVentas2.AutoGenerateColumns = false;
                dgvDetalleVentas2.DataSource = lista;

                dgvDetalleVentas2.Columns[0].DataPropertyName = "IdDetIngreso";
                dgvDetalleVentas2.Columns[1].DataPropertyName = "Articulo";
                dgvDetalleVentas2.Columns[2].DataPropertyName = "Cantidad";
                dgvDetalleVentas2.Columns[3].DataPropertyName = "PrecioVenta";
                dgvDetalleVentas2.Columns[4].DataPropertyName = "Descuento";
                dgvDetalleVentas2.Columns[5].DataPropertyName = "Subtotal";
            }
            else
            {
                MessageBox.Show("Noy hay registros de Detalle de ingreso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar esta Venta?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idVenta = dgvVentas.CurrentRow.Cells[0].Value.ToString();
                    if (venta.EliminarVenta(Convert.ToInt32(idVenta)))
                        MostrarVenta();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteVenta reporteVenta = new FormReporteVenta();
            reporteVenta.ShowDialog();
        }

        private void BtnComprobante_Click(object sender, EventArgs e)
        {
            FormReporteFactura reporte = new FormReporteFactura();
            
            if (dgvVentas.SelectedRows.Count > 0)
            {
                reporte.IdVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells[0].Value.ToString());
                reporte.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAbrirVistaCliente_Click(object sender, EventArgs e)
        {
            FormVistas.FormVistaCliente vistaCliente = new FormVistas.FormVistaCliente();
            AddOwnedForm(vistaCliente);
            vistaCliente.Show();
        }

        private void BtnAbrirVistaArticulo_Click(object sender, EventArgs e)
        {
            FormVistas.FormVistaArticulo_Venta vistaArticulo = new FormVistas.FormVistaArticulo_Venta();
            AddOwnedForm(vistaArticulo);
            vistaArticulo.Show();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {           
            if (lblIdArticulo.Text == "0")
            {
                MessageBox.Show("Por favor seleccione un artículo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtCantidad.Text == "")
            {
                txtCantidad.Focus();
                MessageBox.Show("Por favor ingrese la cantidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDescuento.Text == "")
            {
                txtDescuento.Focus();
                MessageBox.Show("Por favor ingrese el descuento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                {
                    AgregarDetalle();
                }
                else
                {
                    MessageBox.Show("No hay stock suficiente para esta venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void AgregarDetalle()
        {
            decimal subtotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecioVenta.Text) - Convert.ToDecimal(txtDescuento.Text);
            totalPagado += subtotal;
            lblTotalPagado.Text = $"Total pagado: {totalPagado:C}";

            //Agregamos los datos al dgvDetalleIngreso
            dgvDetalleVentas.Rows.Add(
                lblIdDetIngreso.Text,
                txtArticulo.Text,
                txtCantidad.Text.Trim(),
                txtPrecioVenta.Text,
                txtDescuento.Text.Trim(),
                subtotal);

            LimpiarDetalle();
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleVentas.SelectedRows.Count > 0)
            {
                int indiceFila = dgvDetalleVentas.CurrentCell.RowIndex;

                //Disminuimos el total pago
                totalPagado -= Convert.ToDecimal(dgvDetalleVentas.CurrentRow.Cells[5].Value.ToString());
                lblTotalPagado.Text = $"Total pagado: {totalPagado:C}";

                //Removemos la fila
                dgvDetalleVentas.Rows.Remove(dgvDetalleVentas.Rows[indiceFila]);
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
            LimpiarDetalle();
            EliminarFilaDetalleVenta();
            dgvDetalleVentas2.Visible = false;
            Habilitar();
            btnNuevo.Enabled = false;
            btnAbrirVistaCliente.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (entiVenta == null) entiVenta = new EVenta();

                entiVenta.IdCliente = Convert.ToInt32(lblIdCliente.Text);
                entiVenta.IdTrabajador = UserCache.IdTrabajador;
                entiVenta.Fecha = dtpFecha.Value;
                entiVenta.TipoComprobante = cmbComprobante.Text;
                entiVenta.Serie = txtSerie.Text.Trim();
                entiVenta.Correlativo = txtCorrelativo.Text.Trim();
                entiVenta.Igv = Convert.ToDecimal(txtIgv.Text.Trim());

                //Capturamos el IdUltimo
                int idUltimo = venta.RegistrarVenta(entiVenta);
                if (idUltimo > 0)
                {
                    MessageBox.Show("¡Registro de venta con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Registramos el Detalle ingreso
                    if (entiDetalle == null) entiDetalle = new EDetalleVenta();
                    int numFilas = dgvDetalleVentas.Rows.Count;
                    int contador = 0;

                    for (int i = 0; i < numFilas; i++)
                    {
                        entiDetalle.IdVenta = idUltimo;
                        entiDetalle.IdDetIngreso = Convert.ToInt32(dgvDetalleVentas.Rows[i].Cells[0 ].Value.ToString());
                        entiDetalle.Cantidad = Convert.ToInt32(dgvDetalleVentas.Rows[i].Cells[2].Value.ToString());
                        entiDetalle.PrecioVenta = Convert.ToDecimal(dgvDetalleVentas.Rows[i].Cells[3].Value.ToString());
                        entiDetalle.Descuento = Convert.ToInt32(dgvDetalleVentas.Rows[i].Cells[4].Value.ToString());

                        int idDetIngreso = Convert.ToInt32(dgvDetalleVentas.Rows[i].Cells[0].Value.ToString());
                        int cantidad = Convert.ToInt32(dgvDetalleVentas.Rows[i].Cells[2].Value.ToString());

                        if (detalle.RegistrarDetalleVenta(entiDetalle))
                        {
                            venta.DisminuirStockPorVenta(idDetIngreso, cantidad);
                        }
                        else
                        {
                            contador++;
                        }
                    }

                    if (contador == 0) MessageBox.Show("¡Detalle de venta registrado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (venta.builder.Length != 0)
                {
                    MessageBox.Show(venta.builder.ToString(), "VENTA: Para continuar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (detalle.builder.Length != 0)
                    {
                        MessageBox.Show(detalle.builder.ToString(), "DETALLE VENTA: Para continuar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarVenta();
                LimpiarVenta();
                Deshabilitar();
                btnNuevo.Enabled = true;
                EliminarFilaDetalleVenta();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
            LimpiarDetalle();
            EliminarFilaDetalleVenta();
            dgvDetalleVentas2.Visible = false;
            Deshabilitar();
            btnNuevo.Enabled = true;
        }

        private void LimpiarVenta()
        {
            txtIdVenta.Clear();
            cmbComprobante.SelectedIndex = 0;
            lblIdCliente.Text = "0";
            txtCliente.Clear();
            txtSerie.Clear();
            txtCorrelativo.Clear();
            dtpFecha.Value = DateTime.Now;
            txtIgv.Text = "18";

            lblTotalPagado.Text = "Total pagado: S/ 0.00";
        }

        private void LimpiarDetalle()
        {
            lblIdDetIngreso.Text = "0";
            lblIdArticulo.Text = "0";
            txtArticulo.Clear();
            txtCantidad.Clear();
            txtStockActual.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            dtpFecVencimiento.Value = DateTime.Now;
            txtDescuento.Clear();
        }

        private void Habilitar()
        {
            txtIdVenta.Enabled = true;
            cmbComprobante.Enabled = true;
            lblIdCliente.Enabled = true;
            txtCliente.Enabled = true;
            txtSerie.Enabled = true;
            txtCorrelativo.Enabled = true;
            dtpFecha.Enabled = true;
            txtIgv.Enabled = true;

            lblIdDetIngreso.Enabled = true;
            lblIdArticulo.Enabled = true;
            txtArticulo.Enabled = true;
            txtCantidad.Enabled = true;
            txtStockActual.Enabled = true;
            txtPrecioCompra.Enabled = true;
            txtPrecioVenta.Enabled = true;
            dtpFecVencimiento.Enabled = true;
            txtDescuento.Enabled = true;
            btnAbrirVistaArticulo.Enabled = true;
            btnAbrirVistaCliente.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Deshabilitar()
        {
            txtIdVenta.Enabled = false;
            cmbComprobante.Enabled = false;
            lblIdCliente.Enabled = false;
            txtCliente.Enabled = false;
            txtSerie.Enabled = false;
            txtCorrelativo.Enabled = false;
            dtpFecha.Enabled = false;
            txtIgv.Enabled = false;

            lblIdDetIngreso.Enabled = false;
            lblIdArticulo.Enabled = false;
            txtArticulo.Enabled = false;
            txtCantidad.Enabled = false;
            txtStockActual.Enabled = false;
            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;
            dtpFecVencimiento.Enabled = false;
            txtDescuento.Enabled = false;
            btnAbrirVistaArticulo.Enabled = false;
            btnAbrirVistaCliente.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void DgvVentas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdVenta.Text = dgvVentas.CurrentRow.Cells[0].Value.ToString();
            cmbComprobante.Text = dgvVentas.CurrentRow.Cells[6].Value.ToString();
            lblIdCliente.Text = dgvVentas.CurrentRow.Cells[1].Value.ToString();
            txtCliente.Text = dgvVentas.CurrentRow.Cells[2].Value.ToString();
            txtSerie.Text = dgvVentas.CurrentRow.Cells[8].Value.ToString();
            txtCorrelativo.Text = dgvVentas.CurrentRow.Cells[9].Value.ToString();
            dtpFecha.Text = dgvVentas.CurrentRow.Cells[5].Value.ToString();
            txtIgv.Text = dgvVentas.CurrentRow.Cells[9].Value.ToString();

            MostrarDetalle();
            decimal totalDetalle = 0;

            for (int i = 0; i < dgvDetalleVentas2.Rows.Count; i++)
            {
                totalDetalle += Convert.ToDecimal(dgvDetalleVentas2.Rows[i].Cells[5].Value.ToString());
            }

            lblTotalPagado.Text = $"Total pagado: {totalDetalle:C}";
        }

        private void EliminarFilaDetalleVenta()
        {
            int numFilas = dgvDetalleVentas.Rows.Count;

            if (numFilas > 0)
            {
                for (int i = 0; i < numFilas; i++)
                {
                    dgvDetalleVentas.Rows.RemoveAt(0);
                }
            }
        }

        
    }
}
