using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app
{
    public partial class mesaDePedido : Form
    {
        private string nombreUsuario;
        public mesaDePedido(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
        }

        private void mesaDePedido_Load(object sender, EventArgs e)
        {
            userName.Text = nombreUsuario;

            this.BackColor = Color.FromArgb(52, 90, 123);

            mahaiGroup.BackColor = Color.FromArgb(217, 217, 217);

            mesa1.BackColor = Color.FromArgb(118, 138, 153);
            mesa2.BackColor = Color.FromArgb(118, 138, 153);
            mesa3.BackColor = Color.FromArgb(118, 138, 153);
            mesa4.BackColor = Color.FromArgb(118, 138, 153);
            mesa5.BackColor = Color.FromArgb(118, 138, 153);
            mesa6.BackColor = Color.FromArgb(118, 138, 153);
            edariScreenButton.BackColor = Color.FromArgb(118, 138, 153);
        }

        private int seleccionMesa(string mesa)
        {

            string patronNumerico = @"\d+";

            Match coincidencia = Regex.Match(mesa, patronNumerico);

            if (coincidencia.Success) {

                string numeroCoicidencia = coincidencia.Value;
                
                int numeroMesa = Convert.ToInt32(numeroCoicidencia);

                return numeroMesa;
            }

            throw new FormatException("No ha habido ninguna coincidencia");
        }

        private void mesa1_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa1.Text;
            int numeroDeMesa = seleccionMesa(nombreMesa);
        }
    }
}
