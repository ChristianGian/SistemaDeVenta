using CapaNegocio;
using Entidad.Cache;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.FormLogin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TxtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "USUARIO")
            {
                txtUsername.Clear();
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void TxtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "USUARIO";
                txtUsername.ForeColor = Color.DimGray;
            }
        }

        private void TxtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Clear();
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void TxtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            if (txtUsername.Text != "USUARIO")
            {
                if (txtPassword.Text != "CONTRASEÑA")
                {
                    NUser user = new NUser();
                    bool validarLogin = user.LoginUser(txtUsername.Text, txtPassword.Text);

                    if (validarLogin)
                    {
                        if (UserCache.Estado == "A")
                        {
                            FormPrincipal principal = new FormPrincipal();
                            this.Hide();

                            LoginBienvenida bienvenida = new LoginBienvenida();
                            bienvenida.ShowDialog();

                            principal.Show();
                            principal.FormClosed += CerrarSesion;
                        }
                        else
                        {
                            MensajeError("Usuario deshabilitado.\n      Póngase en contacto con el administrador");
                        }
                    }
                    else
                    {
                        MensajeError("Usuario o contraseña incorrecta.\n      Por favor intente otra vez");
                        txtPassword.Clear();
                        txtUsername.SelectAll();
                        txtUsername.Focus();
                    }
                }
                else
                {
                    MensajeError("Por favor ingrese su contraseña");
                }
            }
            else
            {
                MensajeError("Por favor ingrese su usuario");
            }
        }

        private void MensajeError(string msj)
        {
            lblMensajeError.Text = "      " + msj;
            lblMensajeError.Visible = true;
        }

        private void CerrarSesion(object sender, FormClosedEventArgs e)
        {
            txtUsername.Text = "USUARIO";
            txtPassword.Text = "CONTRASEÑA";
            txtPassword.UseSystemPasswordChar = false;

            lblMensajeError.Visible = false;
            this.Show();
        }

        //Datos
        private int posX = 0;
        private int posY = 0;
        private void PboxImageLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left += (e.X - posX);
                Top += (e.Y - posY);
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Ingresar();
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
