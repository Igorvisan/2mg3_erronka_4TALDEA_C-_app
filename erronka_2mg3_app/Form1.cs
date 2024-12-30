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
    public partial class hasiSaioa : Form
    {
        public hasiSaioa()
        {
            InitializeComponent();
        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void hasiSaioa_Load(object sender, EventArgs e)
        {
            logInButton.BackColor = Color.FromArgb(118, 138, 153);

            this.BackColor = Color.FromArgb(52, 90, 123);
            
            profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, profilePicture.Width, profilePicture.Height);
            Region rg = new Region(gp);
            profilePicture.Region = rg;

            logoPicture.SizeMode = PictureBoxSizeMode.StretchImage;

            pasahitzaText.PasswordChar = '*';
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailText.Text) || string.IsNullOrWhiteSpace(pasahitzaText.Text)) { 
                MessageBox.Show("Rellena los Campos", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string hql = @"SELECT lan FROM langileLogIn lan WHERE lan.Email = :emailParam AND lan.Pasahitza = :pasahitzaParam";

                    string email = emailText.Text;
                    string pasahitza = pasahitzaText.Text;

                    var langileQuery = mySession.CreateQuery(hql);
                    langileQuery.SetParameter("emailParam", email);
                    langileQuery.SetParameter("pasahitzaParam", pasahitza);

                    var resultado = langileQuery.List<langileLogIn>();

                    if (resultado.Count > 0)
                    {
                        var usuario = resultado[0];
                        string nombreUsuario = usuario.Izena;
                        string lanPostua = usuario.LanPostua;

                        MessageBox.Show($"Bienvenido/a {nombreUsuario}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        transaccion.Commit();

                        if (lanPostua.Equals("Camarero"))
                        {
                            nuevComanda empezarPedidosPantalla = new nuevComanda(nombreUsuario);
                            empezarPedidosPantalla.Show();
                            this.Hide();
                            
                        }else if (lanPostua.Equals("Cocina"))
                        {
                            cocinaPantalla cocinaScreen = new cocinaPantalla(nombreUsuario);
                            cocinaScreen.Show();
                            this.Hide();
                        }
                        else if (lanPostua.Equals("Admin"))
                        {
                            adminPantalla adminScreen = new adminPantalla(nombreUsuario);
                            adminScreen.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No existe ese uduario en nuestra base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe ese uduario en nuestra base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex) { 
                    transaccion.Rollback();
                    MessageBox.Show(ex.Message + "No se ha podido realizar la operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
