using erronka_2mg3_app.edaria;
using NHibernate;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app
{
    public partial class tpvPantaila : Form
    {
        private string nombreUsuario;
        
        public tpvPantaila(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;

        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void tpvPantaila_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);

            userNameLabel.Text = nombreUsuario;

            edariakBox.BackColor = Color.FromArgb(217, 217, 217);

            edari1.BackColor = Color.FromArgb(118, 138, 153);
            edari2.BackColor = Color.FromArgb(118, 138, 153);
            edari3.BackColor = Color.FromArgb(118, 138, 153);
            edari4.BackColor = Color.FromArgb(118, 138, 153);
            edari5.BackColor = Color.FromArgb(118, 138, 153);
            edari6.BackColor = Color.FromArgb(118, 138, 153);
            edari7.BackColor = Color.FromArgb(118, 138, 153);
            edari8.BackColor = Color.FromArgb(118, 138, 153);
            hurrengoBotoia.BackColor = Color.FromArgb(118, 138, 153);

        }

        private void edari1_Click(object sender, EventArgs e)
        {
            string bebida = edari1.Text;
            anyButtonClick(bebida);
        }

        private void edari2_Click(object sender, EventArgs e)
        {
            string bebida = edari2.Text;
            anyButtonClick(bebida);
        }

        private void edari3_Click(object sender, EventArgs e)
        {
            string bebida = edari3.Text;
            anyButtonClick(bebida);
        }

        private void edari4_Click(object sender, EventArgs e)
        {
            string bebida = edari4.Text;
            anyButtonClick(bebida);
        }

        private void edari5_Click(object sender, EventArgs e)
        {
            string bebida = edari5.Text;
            anyButtonClick(bebida);
        }

        private void edari6_Click(object sender, EventArgs e)
        {
            string bebida = edari6.Text;
            anyButtonClick(bebida);
        }

        private void edari7_Click(object sender, EventArgs e)
        {
            string bebida = edari7.Text;
            anyButtonClick(bebida);
        }

        private void edari8_Click(object sender, EventArgs e)
        {
            string bebida = edari8.Text;
            anyButtonClick(bebida);
        }

        private void anyButtonClick(string buttonText)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string hql = "SELECT e.Izena FROM edariaMapping e WHERE e.Izena = :izenaParam";

                    string edaria = buttonText;

                    var consulta = mySession.CreateQuery(hql);
                    consulta.SetParameter("izenaParam", edaria);

                    var resultado = consulta.UniqueResult<string>();

                    if (resultado != null && resultado.Equals(buttonText))
                    {
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido {buttonText}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido encontrar esa bebida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido completar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void hurrengoBotoia_Click(object sender, EventArgs e)
        {
            lehen_platera lehen_Platera = new lehen_platera(nombreUsuario);
            lehen_Platera.Show();
            this.Hide();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstDrinkCount.Text);
            
            cantidadBebida++;

            firstDrinkCount.Text = cantidadBebida.ToString();
        }

        private void lessButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstDrinkCount.Text);

            if(cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            firstDrinkCount.Text = cantidadBebida.ToString();
        }
    }
}
