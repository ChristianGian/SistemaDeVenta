using CapaNegocio;
using CapaPresentacion.Reportes;
using Entidad;
using Entidad.Cache;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.FormHijos
{
    public partial class FormIngreso : Form
    {
        //Campos
        private readonly NIngreso ingreso = new NIngreso();
        private readonly NDetalleIngreso detalle = new NDetalleIngreso();
        private EIngreso entiIngreso;
        private EDetalleIngreso entiDetalle;

        private decimal totalPagado = 0;

        public FormIngreso()
        {
            InitializeComponent();
        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
            MostrarIngreso();
            Deshabilitar();
        }

        private void MostrarIngreso()
        {
            var lista = ingreso.MostrarIngreso();
            lblTotalRegistro.Text = $"Total registro: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvIngresos.AutoGenerateColumns = false;
                dgvIngresos.DataSource = lista;

                dgvIngresos.Columns[0].DataPropertyName = "IdIngreso";
                dgvIngresos.Columns[1].DataPropertyName = "IdTrabajador";
                dgvIngresos.Columns[2].DataPropertyName = "Trabajador";
                dgvIngresos.Columns[3].DataPropertyName = "IdProveedor";
                dgvIngresos.Columns[4].DataPropertyName = "Proveedor";
                dgvIngresos.Columns[5].DataPropertyName = "Fecha";
                dgvIngresos.Columns[6].DataPropertyName = "TipoComprobante";
                dgvIngresos.Columns[7].DataPropertyName = "Serie";
                dgvIngresos.Columns[8].DataPropertyName = "Correlativo";
                dgvIngresos.Columns[9].DataPropertyName = "Igv";
                dgvIngresos.Columns[10].DataPropertyName = "Estado";
                dgvIngresos.Columns[11].DataPropertyName = "Total";
            }
            else
            {
                MessageBox.Show("Noy hay registros de Ingresos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnMostrarIngresos_Click(object sender, EventArgs e)
        {
            MostrarIngreso();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecInicio = dtpFecInicio.Value;
            DateTime fecFin = dtpFecFin.Value;

            var lista = ingreso.MostrarEntreFechasIngreso(fecInicio, fecFin);
            lblTotalRegistro.Text = $"Total registro: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvIngresos.AutoGenerateColumns = false;
                dgvIngresos.DataSource = lista;

                dgvIngresos.Columns[0].DataPropertyName = "IdIngreso";
                dgvIngresos.Columns[1].DataPropertyName = "IdTrabajador";
                dgvIngresos.Columns[2].DataPropertyName = "Trabajador";
                dgvIngresos.Columns[3].DataPropertyName = "IdProveedor";
                dgvIngresos.Columns[4].DataPropertyName = "Proveedor";
                dgvIngresos.Columns[5].DataPropertyName = "Fecha";
                dgvIngresos.Columns[6].DataPropertyName = "TipoComprobante";
                dgvIngresos.Columns[7].DataPropertyName = "Serie";
                dgvIngresos.Columns[8].DataPropertyName = "Correlativo";
                dgvIngresos.Columns[9].DataPropertyName = "Igv";
                dgvIngresos.Columns[10].DataPropertyName = "Estado";
                dgvIngresos.Columns[11].DataPropertyName = "Total";
            }
            else
            {
                MessageBox.Show("Noy hay registros entre esas fechas", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarDetalle()
        {
            int idIngreso = Convert.ToInt32(txtIdIngreso.Text);
            var lista = detalle.MostrarDetalleIngreso(idIngreso);
            lblTotalRegistro.Text = $"Total registro: {lista.Count}";

            if (lista.Count > 0)
            {
                dgvDetalleIngresos2.Visible = true;
                dgvDetalleIngresos2.AutoGenerateColumns = false;
                dgvDetalleIngresos2.DataSource = lista;

                dgvDetalleIngresos2.Columns[0].DataPropertyName = "IdArticulo";
                dgvDetalleIngresos2.Columns[1].DataPropertyName = "Articulo";
                dgvDetalleIngresos2.Columns[2].DataPropertyName = "PrecioCompra";
                dgvDetalleIngresos2.Columns[3].DataPropertyName = "PrecioVenta";
                dgvDetalleIngresos2.Columns[4].DataPropertyName = "StockInicial";
                dgvDetalleIngresos2.Columns[5].DataPropertyName = "FecProduccion";
                dgvDetalleIngresos2.Columns[6].DataPropertyName = "FecVencimiento";
                dgvDetalleIngresos2.Columns[7].DataPropertyName = "Subtotal";
            }
            else
            {
                MessageBox.Show("Noy hay registros de Detalle de ingreso", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAnular_Click(object sender, EventArgs e)
        {
            if (dgvIngresos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de anular este Ingreso?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idIngreso = dgvIngresos.CurrentRow.Cells[0].Value.ToString();
                    if (ingreso.Anular(Convert.ToInt32(idIngreso)))
                        MostrarIngreso();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteIngresos reporteIngresos = new FormReporteIngresos();
            reporteIngresos.ShowDialog();
        }

        private void BtnAbrirVistaProveedor_Click(object sender, EventArgs e)
        {
            FormVistas.FormVistaProveedor vistaProveedor = new FormVistas.FormVistaProveedor();
            AddOwnedForm(vistaProveedor);
            vistaProveedor.Show();
        }

        private void BtnAbrirVistaArticulo_Click(object sender, EventArgs e)
        {
            FormVistas.FormVistaArticulo vistaArticulo = new FormVistas.FormVistaArticulo();
            AddOwnedForm(vistaArticulo);
            vistaArticulo.Show();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (lblIdArticulo.Text == "0")
            {
                MessageBox.Show("Por favor seleccione un artículo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtStockInicial.Text == "")
            {
                txtStockInicial.Focus();
                MessageBox.Show("Por favor ingrese el stock inicial", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPrecioCompra.Text == "")
            {
                txtPrecioCompra.Focus();
                MessageBox.Show("Por favor ingrese el precio de compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPrecioVenta.Text == "")
            {
                txtPrecioVenta.Focus();
                MessageBox.Show("Por favor ingrese el precio de venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int numFilas = dgvDetalleIngresos.Rows.Count;
                string idArticulo = lblIdArticulo.Text;

                if (numFilas == 0)
                {
                    AgregarDetalle(idArticulo);
                }
                else
                {
                    bool existe = false;

                    for (int i = 0; i < numFilas; i++)
                    {
                        if (idArticulo == dgvDetalleIngresos.Rows[i].Cells[0].Value.ToString())
                        {
                            existe = true;
                            break;
                        }
                    }

                    if (existe)
                    {
                        MessageBox.Show("El detalle que desea ingresar ya se encuentra registrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LimpiarDetalle();
                    }
                    else
                    {
                        AgregarDetalle(idArticulo);
                    }
                }
            }
        }

        private void AgregarDetalle(string idArticulo)
        {
            decimal subtotal = Convert.ToDecimal(txtStockInicial.Text) * Convert.ToDecimal(txtPrecioCompra.Text);
            totalPagado += subtotal;
            lblTotalPagado.Text = $"Total pagado: {totalPagado:C}";

            //Agregamos los datos al dgvDetalleIngreso
            dgvDetalleIngresos.Rows.Add(
                idArticulo,
                txtArticulo.Text,
                txtPrecioCompra.Text.Trim(),
                txtPrecioVenta.Text.Trim(),
                txtStockInicial.Text.Trim(),
                dtpFecProduccion.Text,
                dtpFecVencimiento.Text,
                subtotal);

            LimpiarDetalle();
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvDetalleIngresos.SelectedRows.Count > 0)
            {
                int indiceFila = dgvDetalleIngresos.CurrentCell.RowIndex;

                //Disminuimos el total pago
                totalPagado -= Convert.ToDecimal(dgvDetalleIngresos.CurrentRow.Cells[7].Value.ToString());
                lblTotalPagado.Text = $"Total pagado: {totalPagado:C}";

                //Removemos la fila
                dgvDetalleIngresos.Rows.Remove(dgvDetalleIngresos.Rows[indiceFila]);
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarIngreso();
            LimpiarDetalle();
            EliminarFilaDetalleIngreso();
            dgvDetalleIngresos2.Visible = false;
            Habilitar();
            btnNuevo.Enabled = false;
            btnAbrirVistaProveedor.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (entiIngreso == null) entiIngreso = new EIngreso();

                entiIngreso.IdTrabajador = UserCache.IdTrabajador;
                entiIngreso.IdProveedor = Convert.ToInt32(lblIdProveedor.Text);
                entiIngreso.Fecha = dtpFecha.Value;
                entiIngreso.TipoComprobante = cmbComprobante.Text;
                entiIngreso.Serie = txtSerie.Text.Trim();
                entiIngreso.Correlativo = txtCorrelativo.Text.Trim();
                entiIngreso.Igv = Convert.ToDecimal(txtIgv.Text.Trim());
                entiIngreso.Estado = "EMITIDO";

                //Capturamos el IdUltimo
                int idUltimo = ingreso.RegistrarIngreso(entiIngreso);
                if (idUltimo > 0)
                {
                    MessageBox.Show("¡Ingreso a almacén con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Regsitramos el Detalle ingreso
                    if (entiDetalle == null) entiDetalle = new EDetalleIngreso();
                    int numFilas = dgvDetalleIngresos.Rows.Count;
                    int contador = 0;

                    for (int i = 0; i < numFilas; i++)
                    {
                        entiDetalle.IdIngreso = idUltimo;
                        entiDetalle.IdArticulo = Convert.ToInt32(dgvDetalleIngresos.Rows[i].Cells[0].Value.ToString());
                        entiDetalle.PrecioCompra = Convert.ToDecimal(dgvDetalleIngresos.Rows[i].Cells[2].Value.ToString());
                        entiDetalle.PrecioVenta = Convert.ToDecimal(dgvDetalleIngresos.Rows[i].Cells[3].Value.ToString());
                        entiDetalle.StockInicial = Convert.ToInt32(dgvDetalleIngresos.Rows[i].Cells[4].Value.ToString());
                        entiDetalle.StockActual = Convert.ToInt32(dgvDetalleIngresos.Rows[i].Cells[4].Value.ToString());
                        entiDetalle.FecProduccion = Convert.ToDateTime(dgvDetalleIngresos.Rows[i].Cells[5].Value.ToString());
                        entiDetalle.FecVencimiento = Convert.ToDateTime(dgvDetalleIngresos.Rows[i].Cells[6].Value.ToString());

                        if (!detalle.RegistrarDetalleIngreso(entiDetalle)) contador++;
                    }

                    if (contador == 0) MessageBox.Show("¡Detalle de ingreso registrado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                if (ingreso.builder.Length != 0)
                {
                    MessageBox.Show(ingreso.builder.ToString(), "INGRESO: Para continuar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (detalle.builder.Length != 0)
                    {
                        MessageBox.Show(detalle.builder.ToString(), "DETALLE INGRESO: Para continuar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarIngreso();
                LimpiarIngreso();
                Deshabilitar();
                btnNuevo.Enabled = true;
                EliminarFilaDetalleIngreso();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarIngreso();
            LimpiarDetalle();
            EliminarFilaDetalleIngreso();
            dgvDetalleIngresos2.Visible = false;
            Deshabilitar();
            btnNuevo.Enabled = true;
        }

        private void LimpiarIngreso()
        {
            txtIdIngreso.Clear();
            cmbComprobante.SelectedIndex = 0;
            lblIdProveedor.Text = "0";
            txtProveedor.Clear();
            txtSerie.Clear();
            txtCorrelativo.Clear();
            dtpFecha.Value = DateTime.Now;
            txtIgv.Text = "18";

            lblTotalPagado.Text = "Total pagado: S/ 0.00";
        }

        private void LimpiarDetalle()
        {
            lblIdArticulo.Text = "0";
            txtArticulo.Clear();
            txtStockInicial.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            dtpFecProduccion.Value = DateTime.Now;
            dtpFecVencimiento.Value = DateTime.Now;
        }

        private void Habilitar()
        {
            txtIdIngreso.Enabled = true;
            cmbComprobante.Enabled = true;
            lblIdProveedor.Enabled = true;
            txtProveedor.Enabled = true;
            txtSerie.Enabled = true;
            txtCorrelativo.Enabled = true;
            dtpFecha.Enabled = true;
            txtIgv.Enabled = true;

            lblIdArticulo.Enabled = true;
            txtArticulo.Enabled = true;
            txtStockInicial.Enabled = true;
            txtPrecioCompra.Enabled = true;
            txtPrecioVenta.Enabled = true;
            dtpFecProduccion.Enabled = true;
            dtpFecVencimiento.Enabled = true;
            btnAbrirVistaArticulo.Enabled = true;
            btnAbrirVistaProveedor.Enabled = true;
            btnAgregar.Enabled = true;
            btnQuitar.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Deshabilitar()
        {
            txtIdIngreso.Enabled = false;
            cmbComprobante.Enabled = false;
            lblIdProveedor.Enabled = false;
            txtProveedor.Enabled = false;
            txtSerie.Enabled = false;
            txtCorrelativo.Enabled = false;
            dtpFecha.Enabled = false;
            txtIgv.Enabled = false;

            lblIdArticulo.Enabled = false;
            txtArticulo.Enabled = false;
            txtStockInicial.Enabled = false;
            txtPrecioCompra.Enabled = false;
            txtPrecioVenta.Enabled = false;
            dtpFecProduccion.Enabled = false;
            dtpFecVencimiento.Enabled = false;
            btnAbrirVistaArticulo.Enabled = false;
            btnAbrirVistaProveedor.Enabled = false;
            btnAgregar.Enabled = false;
            btnQuitar.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void DgvIngresos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtIdIngreso.Text = dgvIngresos.CurrentRow.Cells[0].Value.ToString();
            lblIdProveedor.Text = dgvIngresos.CurrentRow.Cells[3].Value.ToString();
            txtProveedor.Text = dgvIngresos.CurrentRow.Cells[4].Value.ToString();
            txtSerie.Text = dgvIngresos.CurrentRow.Cells[7].Value.ToString();
            txtCorrelativo.Text = dgvIngresos.CurrentRow.Cells[8].Value.ToString();
            dtpFecha.Text = dgvIngresos.CurrentRow.Cells[5].Value.ToString();
            txtIgv.Text = dgvIngresos.CurrentRow.Cells[9].Value.ToString();

            MostrarDetalle();
            decimal totalDetalle = 0;

            for (int i = 0; i < dgvDetalleIngresos2.Rows.Count; i++)
            {
                totalDetalle += Convert.ToDecimal(dgvDetalleIngresos2.Rows[i].Cells[7].Value.ToString());
            }

            lblTotalPagado.Text = $"Total pagado: {totalDetalle:C}";
        }

        private void EliminarFilaDetalleIngreso()
        {
            int numFilas = dgvDetalleIngresos.Rows.Count;

            if (numFilas > 0)
            {
                for (int i = 0; i < numFilas; i++)
                {
                    dgvDetalleIngresos.Rows.RemoveAt(0);
                }
            }
        }
    }
}
