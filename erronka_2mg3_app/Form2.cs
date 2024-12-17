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

        private void anyButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string buttonText = clickedButton.Text;
                MessageBox.Show($"Botón presionado: {buttonText}");

            }
        }

        private void edari1_Click(object sender, EventArgs e)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaccion = mySession.BeginTransaction()) {

                try
                {
                    string hql = "SELECT e.Izena FROM edariaMapping e WHERE e.Izena = :izenaParam";
                    string edaria = edari1.Text;
                    var consulta = mySession.CreateQuery(hql);
                    consulta.SetParameter("izenaParam", edaria);
                    var resultado = consulta.UniqueResult<string>();

                    if (resultado != null && resultado.Equals("Cocacola"))
                    {
                        MessageBox.Show("Has escogido la bebida", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);  
                    }
                    else
                    {
                        MessageBox.Show("No han encontrado resultados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    transaccion.Commit();
                }
                catch (Exception ex) { 
                    MessageBox.Show($"No se ha podido realizar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    transaccion.Rollback();
                    return;
                }
            }
        }
    }
}
