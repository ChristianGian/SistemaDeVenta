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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Remoting.Contexts;
using Microsoft.Win32.SafeHandles;
using System.Security.Cryptography;
using CapaPresentacion.Reportes;

namespace CapaPresentacion.FormHijos
{
    public partial class FormArticulo : Form
    {
        //Campos
        private readonly NArticulo articulo = new NArticulo();
        private EArticulo entidad;
        private bool editar = false;

        public FormArticulo()
        {
            InitializeComponent();
        }

        private void FormArticulo_Load(object sender, EventArgs e)
        {
            MostrarArticulo();
            LlenarComboBoxPresentaciones();
            Deshabilitar();
        }

        private void MostrarArticulo()
        {
            var lista = articulo.MostrarArticulo();
            lblTotalRegistro.Text = $"Total registros: {lista.Count}";

            dgvArticulos.AutoGenerateColumns = false;
            dgvArticulos.DataSource = lista;

            dgvArticulos.Columns[0].DataPropertyName = "IdArticulo";
            dgvArticulos.Columns[1].DataPropertyName = "Codigo";
            dgvArticulos.Columns[2].DataPropertyName = "Nombre";
            dgvArticulos.Columns[3].DataPropertyName = "Descripcion";
            dgvArticulos.Columns[4].DataPropertyName = "Imagen";
            dgvArticulos.Columns[5].DataPropertyName = "IdCategoria";
            dgvArticulos.Columns[6].DataPropertyName = "Categoria";
            dgvArticulos.Columns[7].DataPropertyName = "IdPresentacion";
            dgvArticulos.Columns[8].DataPropertyName = "Presentacion";

            if (lista.Count == 0)
                MessageBox.Show("No hay registros de Artículos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtBuscar.Text;

            if (nombre != "")
            {
                var lista = articulo.BuscarArticulo(nombre);
                lblTotalRegistro.Text = $"Total registros: {lista.Count}";

                dgvArticulos.AutoGenerateColumns = false;
                dgvArticulos.DataSource = lista;

                dgvArticulos.Columns[0].DataPropertyName = "IdArticulo";
                dgvArticulos.Columns[1].DataPropertyName = "Codigo";
                dgvArticulos.Columns[2].DataPropertyName = "Nombre";
                dgvArticulos.Columns[3].DataPropertyName = "Descripcion";
                dgvArticulos.Columns[4].DataPropertyName = "Imagen";
                dgvArticulos.Columns[5].DataPropertyName = "IdCategoria";
                dgvArticulos.Columns[6].DataPropertyName = "Categoria";
                dgvArticulos.Columns[7].DataPropertyName = "IdPresentacion";
                dgvArticulos.Columns[8].DataPropertyName = "Presentacion";
            }
            else
            {
                MostrarArticulo();
            }
        }

        private void Limpiar()
        {
            txtIdArticulo.Clear();
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            lblIdCategoria.Text = "0";
            txtCategoria.Clear();
            cmbIdPresentacion.SelectedIndex = 0;
            pboxImagenProducto.Image = Properties.Resources.ImgProducto50;
            pboxImagenProducto.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void Habilitar()
        {
            txtIdArticulo.Enabled = true;
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtCategoria.Enabled = true;
            cmbIdPresentacion.Enabled = true;
            pboxImagenProducto.Enabled = true;
            btnAbrirCategoria.Enabled = true;
            btnCargar.Enabled = true;
            btnLimpiar.Enabled = true;

            btnGuardar.Enabled = true;
            btnEditar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void Deshabilitar()
        {
            txtIdArticulo.Enabled = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCategoria.Enabled = false;
            cmbIdPresentacion.Enabled = false;
            pboxImagenProducto.Enabled = false;
            btnAbrirCategoria.Enabled = false;
            btnCargar.Enabled = false;
            btnLimpiar.Enabled = false;

            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void LlenarComboBoxPresentaciones()
        {
            NPresentacion datos = new NPresentacion();
            cmbIdPresentacion.DataSource = datos.MostrarPresentacion();
            cmbIdPresentacion.DisplayMember = "Nombre";
            cmbIdPresentacion.ValueMember = "IdPresentacion";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btnEditar.Enabled = false;
            btnNuevo.Enabled = false;
            txtCodigo.Focus();
            editar = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (entidad == null) entidad = new EArticulo();

                entidad.Codigo = txtCodigo.Text.Trim();
                entidad.Nombre = txtNombre.Text.Trim();
                entidad.Descripcion = txtDescripcion.Text.Trim();
                //Convertimos la imagen en un arreglo de byte
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pboxImagenProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                byte[] miImagen = ms.GetBuffer();
                entidad.Imagen = miImagen;
                entidad.IdCategoria = Convert.ToInt32(lblIdCategoria.Text);
                entidad.IdPresentacion = Convert.ToInt32(cmbIdPresentacion.SelectedValue.ToString());

                if (editar)
                {
                    entidad.IdArticulo = Convert.ToInt32(txtIdArticulo.Text);

                    if (articulo.EditarArticulo(entidad))
                    {
                        MessageBox.Show("¡Artículo editado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarArticulo();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                        editar = false;
                    }
                }
                else
                {
                    if (articulo.RegistrarArticulo(entidad))
                    {
                        MessageBox.Show("¡Artículo registrado con éxito!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MostrarArticulo();
                        Limpiar();
                        Deshabilitar();
                        btnNuevo.Enabled = true;
                    }
                }

                if (articulo.builder.Length != 0)
                {
                    MessageBox.Show(articulo.builder.ToString(), "Para continuar...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnNuevo.Enabled = true;
            editar = false;
        }

        private void BtnAbrirCategoria_Click(object sender, EventArgs e)
        {
            FormVistas.FormVistaCategoria vistaCategoria = new FormVistas.FormVistaCategoria();
            AddOwnedForm(vistaCategoria);
            vistaCategoria.Show();
        }

        private void BtnCargar_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pboxImagenProducto.Image = Image.FromFile(openFileDialog1.FileName);
                pboxImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            pboxImagenProducto.Image = Properties.Resources.ImgProducto50;
            pboxImagenProducto.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Está seguro de eliminar este Artículo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string idArticulo = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
                    if (articulo.EliminarArticulo(Convert.ToInt32(idArticulo)))
                        MostrarArticulo();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            FormReporteArticulos reporteArticulos = new FormReporteArticulos();
            reporteArticulos.ShowDialog();
        }

        private void DgvCategorias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editar = true;
            Habilitar();
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = false;

            txtIdArticulo.Text = dgvArticulos.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Text = dgvArticulos.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dgvArticulos.CurrentRow.Cells[2].Value.ToString();
            txtDescripcion.Text = dgvArticulos.CurrentRow.Cells[3].Value.ToString();

            byte[] imagenBuffer = (byte[])dgvArticulos.CurrentRow.Cells[4].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            pboxImagenProducto.Image = Image.FromStream(ms);
            pboxImagenProducto.SizeMode = PictureBoxSizeMode.Zoom;

            lblIdCategoria.Text = dgvArticulos.CurrentRow.Cells[5].Value.ToString();
            txtCategoria.Text = dgvArticulos.CurrentRow.Cells[6].Value.ToString();
            cmbIdPresentacion.Text = dgvArticulos.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
