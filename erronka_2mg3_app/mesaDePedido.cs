using Mysqlx;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

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

        private void mesa1_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa1.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa2_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa2.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa3_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa3.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa4_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa4.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa5_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa5.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa6_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa6.Text;
            confirmarMesa(nombreMesa);
        }

        private void confirmarMesa(string textoMesa)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string hql = "SELECT mai.Izena FROM mahaia mai WHERE mai.Izena = :izenaParam";

                    var seleccion = mySession.CreateQuery(hql);

                    seleccion.SetParameter("izenaParam", textoMesa);

                    var resultados = seleccion.UniqueResult<string>();

                    if (resultados != null)
                    {
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido la: {resultados}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido elegir esa mesa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ha ocurrido un error durante la operacion", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
