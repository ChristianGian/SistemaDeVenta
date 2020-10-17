using Entidad.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        //Campos
        private Form formActivo = null;
        private Button botonActual;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("D");
            lblUserDatos.Text = $"{UserCache.Nombre} {UserCache.Apellidos}";
            lblEmail.Text = UserCache.Email.ToString();

            PermisosDeUsuarios();
        }

        private void PermisosDeUsuarios()
        {
            if (UserCache.Acceso == Acceso.Vendedor)
            {
                panelMenuAlmacen.Visible = false;
                panelMenuCompras.Visible = false;
                panelMenuMantenimiento.Visible = false;
                btnBackup.Visible = false;
            }

            if (UserCache.Acceso == Acceso.Almacenero)
            {
                panelMenuVentas.Visible = false;
                panelMenuMantenimiento.Visible = false;
                btnBackup.Visible = false;
            }
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormVenta());
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormCliente());
        }

        private void btnIngresos_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormIngreso());
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormProveedores());
        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormArticulo());
        }

        private void BtnCategorias_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormCategoria());
        }

        private void BtnPresentaciones_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormPresentacion());
        }

        private void BtnStock_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormStock());
        }

        private void btnConsultaCompra_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultaVenta_Click(object sender, EventArgs e)
        {

        }

        private void BtnTrabajadores_Click(object sender, EventArgs e)
        {
            ActivarBoton(sender);
            AbrirFormHijo(new FormHijos.FormTrabajador());
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {

        }

        private void PboxLogo_Click(object sender, EventArgs e)
        {
            if (formActivo != null) formActivo.Close();
            DesactivarBoton();
        }

        private void AbrirFormHijo(Form formHijo)
        {
            if (formActivo != null) formActivo.Close();

            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelFormHijo.Controls.Add(formHijo);
            panelFormHijo.Tag = formHijo;

            formHijo.BringToFront();
            formHijo.Show();
        }

        private void ActivarBoton(object senderBtn)
        {
            DesactivarBoton();
            
            if (senderBtn != null)
            {
                botonActual = (Button)senderBtn;
                botonActual.BackColor = Color.FromArgb(97, 45, 210);
            }
        }

        private void DesactivarBoton()
        {
            if (botonActual != null)
            {
                botonActual.BackColor = Color.FromArgb(12, 18, 22);
            }
        }
        
    }
}
