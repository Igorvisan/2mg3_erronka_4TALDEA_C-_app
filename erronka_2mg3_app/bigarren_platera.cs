using NHibernate;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app
{
    public partial class bigarren_platera : Form
    {

        private string nombreUsuario;
        public bigarren_platera(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;
        private void bigarren_platera_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);

            userName.Text = nombreUsuario;

            groupBigarrena.BackColor = Color.FromArgb(217, 217, 217);

            merluza.BackColor = Color.FromArgb(118, 138, 153);
            entrecot.BackColor = Color.FromArgb(118, 138, 153);
            carrillera.BackColor = Color.FromArgb(118, 138, 153);
            chipirones.BackColor = Color.FromArgb(118, 138, 153);
            pollo.BackColor = Color.FromArgb(118, 138, 153);
            bacalao.BackColor = Color.FromArgb(118, 138, 153);
            hurrengoBotoia.BackColor = Color.FromArgb(118, 138, 153);
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
                    string hql = "SELECT p.Izena FROM platera p WHERE p.Izena = :izenaParam";

                    string platera = buttonText;

                    var consulta = mySession.CreateQuery(hql);
                    consulta.SetParameter("izenaParam", platera);

                    var resultado = consulta.UniqueResult<string>();

                    if (resultado != null && resultado.Equals(buttonText))
                    {
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido {buttonText}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido encontrar ese plato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void merluza_Click(object sender, EventArgs e)
        {
            string bigarrenPlatera = merluza.Text;
            anyButtonClick(bigarrenPlatera);
        }

        private void entrecot_Click(object sender, EventArgs e)
        {
            string bigarrenPlatera = entrecot.Text;
            anyButtonClick(bigarrenPlatera);
        }

        private void carrillera_Click(object sender, EventArgs e)
        {
            string bigarrenPlatera = carrillera.Text;
            anyButtonClick(bigarrenPlatera);
        }

        private void chipirones_Click(object sender, EventArgs e)
        {
            string bigarrenPlatera = chipirones.Text;
            anyButtonClick(bigarrenPlatera);
        }

        private void pollo_Click(object sender, EventArgs e)
        {
            string bigarrenPlatera = pollo.Text;
            anyButtonClick(bigarrenPlatera);
        }

        private void bacalao_Click(object sender, EventArgs e)
        {
            string bigarrenPlatera = bacalao.Text;
            anyButtonClick(bigarrenPlatera);
        }

        private void hurrengoBotoia_Click(object sender, EventArgs e)
        {
            bigarren_platera bigarren_Platera = new bigarren_platera(nombreUsuario);
            bigarren_Platera.Show();
            this.Hide();
        }
    }
}
