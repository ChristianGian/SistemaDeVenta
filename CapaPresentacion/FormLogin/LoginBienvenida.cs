using Entidad.Cache;
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
    public partial class LoginBienvenida : Form
    {
        public LoginBienvenida()
        {
            InitializeComponent();
        }

        private void LoginBienvenida_Load(object sender, EventArgs e)
        {
            lblNombre.Text = $"{UserCache.Nombre} {UserCache.Apellidos}";
            lblAcceso.Text = UserCache.Acceso.ToString().ToUpper();

            this.Opacity = 0;
            timerAparecer.Start();
        }

        private int contador = 0;
        private void TimerAparecer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            contador++;

            if (contador == 100)
            {
                timerAparecer.Stop();
                timerDesvanecer.Start();
            }
        }

        private void TimerDesvanecer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;

            if (this.Opacity == 0)
            {
                timerDesvanecer.Stop();
                this.Close();
            }
        }
    }
}
