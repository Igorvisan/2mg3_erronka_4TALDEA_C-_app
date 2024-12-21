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
    public partial class lehen_platera : Form
    {
        private string nombreUsuario;
        public lehen_platera(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void lehen_platera_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);

            lehena.BackColor = Color.FromArgb(217, 217, 217);

            userText.Text = nombreUsuario;

            sopaPescado.BackColor = Color.FromArgb(118, 138, 153);
            alubias.BackColor = Color.FromArgb(118, 138, 153);
            ensaladaMixta.BackColor = Color.FromArgb(118, 138, 153);
            ensaladaTemplada.BackColor = Color.FromArgb(118, 138, 153);
            pimientoRelleno.BackColor = Color.FromArgb(118, 138, 153);
            chorizoSidra.BackColor = Color.FromArgb(118, 138, 153);
            hurrengoBotoia.BackColor = Color.FromArgb(118, 138, 153);
        }
        private void sopaPescado_Click(object sender, EventArgs e)
        {
            string plato = sopaPescado.Text;
            anyButtonClick(plato);
        }

        private void ensaladaTemplada_Click(object sender, EventArgs e)
        {
            string plato = ensaladaTemplada.Text;
            anyButtonClick(plato);
        }

        private void alubias_Click(object sender, EventArgs e)
        {
            string plato = alubias.Text;
            anyButtonClick(plato);
        }

        private void pimientoRelleno_Click(object sender, EventArgs e)
        {
            string plato = pimientoRelleno.Text;
            anyButtonClick(plato);
        }

        private void ensaladaMixta_Click(object sender, EventArgs e)
        {
            string plato = ensaladaMixta.Text;
            anyButtonClick(plato);
        }

        private void chorizoSidra_Click(object sender, EventArgs e)
        {
            string plato = chorizoSidra.Text; 
            anyButtonClick(plato);  
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

        private void hurrengoBotoia_Click(object sender, EventArgs e)
        {
            bigarren_platera bigarren_Platera = new bigarren_platera(nombreUsuario);
            bigarren_Platera.Show();
            this.Hide();
        }
    }
}
