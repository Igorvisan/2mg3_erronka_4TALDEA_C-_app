using erronka_2mg3_app.eskaria;
using erronka_2mg3_app.Fakturazioa;
using erronka_2mg3_app.plateraEskaeria;
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
        private void plusFirstDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstDessertCounter.Text);

            cantidadBebida++;

            firstDessertCounter.Text = cantidadBebida.ToString();
        }

        private void lessFirstDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstDessertCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            firstDessertCounter.Text = cantidadBebida.ToString();
        }

        private void plusSecondDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondDessertCounter.Text);

            cantidadBebida++;

            secondDessertCounter.Text = cantidadBebida.ToString();
        }

        private void lessSecondDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondDessertCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            secondDessertCounter.Text = cantidadBebida.ToString();
        }

        private void plusThirdDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdDessertCounter.Text);

            cantidadBebida++;

            thirdDessertCounter.Text = cantidadBebida.ToString();
        }

        private void lessThirdDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdDessertCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            thirdDessertCounter.Text = cantidadBebida.ToString();
        }

        private void plusFourthDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fourthDessertCounter.Text);

            cantidadBebida++;

            fourthDessertCounter.Text = cantidadBebida.ToString();
        }

        private void lessFourthDessert_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fourthDessertCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fourthDessertCounter.Text = cantidadBebida.ToString();
        }

        private void addFirstDessert_Click(object sender, EventArgs e)
        {
            string primerPlato = tartaQueso.Text;
            int kantitatea = Convert.ToInt32(firstDessertCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addSecondDessert_Click(object sender, EventArgs e)
        {
            string primerPlato = pastelVasco.Text;
            int kantitatea = Convert.ToInt32(secondDessertCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addThirdDessert_Click(object sender, EventArgs e)
        {
            string primerPlato = tartaWhiskey.Text;
            int kantitatea = Convert.ToInt32(thirdDessertCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addFourthDessert_Click(object sender, EventArgs e)
        {
            string primerPlato = sorbete.Text;
            int kantitatea = Convert.ToInt32(fourthDessertCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void finalizarButton_Click(object sender, EventArgs e)
        {
            EskaeraKudeaketa eskaeraKudeaketa = new EskaeraKudeaketa();

            eskaeraKudeaketa.actualizarPedidoGlobal();

            EskaeraResumen eskaeraResumen = new EskaeraResumen();   
            eskaeraResumen.Show();  
            this.Hide();
        }
    }
}
