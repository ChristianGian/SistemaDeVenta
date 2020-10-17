using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class Validaciones
    {
        public static void SoloLetras(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar)) e.Handled = false;
            else if (char.IsSeparator(e.KeyChar)) e.Handled = false;
            else if (char.IsControl(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
        }

        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (char.IsSeparator(e.KeyChar)) e.Handled = false;
            else if (char.IsControl(e.KeyChar)) e.Handled = false;
            else e.Handled = true;
        }

        public static void NumeroDecimal(KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) e.Handled = false;
            else if (char.IsSeparator(e.KeyChar)) e.Handled = false;
            else if (char.IsControl(e.KeyChar)) e.Handled = false;
            else if (e.KeyChar.ToString().Equals(".")) e.Handled = false;
            else e.Handled = true;
        }

        public static bool EsEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0) return true;
                else return false;
            }
            else
            {
                return false;
            }
        }
    }
}
