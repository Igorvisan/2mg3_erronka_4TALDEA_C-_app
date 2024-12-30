using NHibernate;
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
    public partial class postrePantalla : Form
    {
        private string nombreUsuario;
        public postrePantalla(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;
        private void postrePantalla_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);
            userName.Text = nombreUsuario;

            tartaQueso.BackColor = Color.FromArgb(118, 138, 153);
            pastelVasco.BackColor = Color.FromArgb(118, 138, 153);
            tartaWhiskey.BackColor = Color.FromArgb(118, 138, 153);
            sorbete.BackColor = Color.FromArgb(118, 138, 153);
            finalizarButton.BackColor = Color.FromArgb(118, 138, 153);

            postreGroup.BackColor = Color.FromArgb(217, 217, 217);

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

        private void tartaQueso_Click(object sender, EventArgs e)
        {
            string tartaCheese = tartaQueso.Text;
            anyButtonClick(tartaCheese);
        }

        private void pastelVasco_Click(object sender, EventArgs e)
        {
            string pVasco = pastelVasco.Text;
            anyButtonClick(pVasco);
        }

        private void tartaWhiskey_Click(object sender, EventArgs e)
        {
            string tWhiskey = tartaWhiskey.Text;
            anyButtonClick(tWhiskey);
        }

        private void sorbete_Click(object sender, EventArgs e)
        {
            string sLimon = sorbete.Text;
            anyButtonClick(sLimon);
        }
    }
}
