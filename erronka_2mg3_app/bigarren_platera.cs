using erronka_2mg3_app.plateraEskaeria;
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

        private void hurrengoBotoia_Click(object sender, EventArgs e)
        {
            postrePantalla postreScreen = new postrePantalla(nombreUsuario);
            postreScreen.Show();
            this.Hide();
        }

        private void plusFirstPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstPlateCounter.Text);

            cantidadBebida++;

            firstPlateCounter.Text = cantidadBebida.ToString();
        }

        private void lessFirstPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstPlateCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            firstPlateCounter.Text = cantidadBebida.ToString();
        }

        private void plusSecondPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondPlateCounter.Text);

            cantidadBebida++;

            secondPlateCounter.Text = cantidadBebida.ToString();
        }

        private void lessSecondPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondPlateCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            secondPlateCounter.Text = cantidadBebida.ToString();
        }

        private void plusThridPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdPlateCounter.Text);

            cantidadBebida++;

            thirdPlateCounter.Text = cantidadBebida.ToString();
        }

        private void lessThridPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdPlateCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            thirdPlateCounter.Text = cantidadBebida.ToString();
        }

        private void plusFourthPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fouthPlateCounter.Text);

            cantidadBebida++;

            fouthPlateCounter.Text = cantidadBebida.ToString();
        }

        private void lessFourthPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fouthPlateCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fouthPlateCounter.Text = cantidadBebida.ToString();
        }

        private void plusFifthPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fifthPlateCounter.Text);

            cantidadBebida++;

            fifthPlateCounter.Text = cantidadBebida.ToString();
        }

        private void lessFifthPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fouthPlateCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fouthPlateCounter.Text = cantidadBebida.ToString();
        }

        private void plusSixthPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(sixthPlateCounter.Text);

            cantidadBebida++;

            sixthPlateCounter.Text = cantidadBebida.ToString();
        }

        private void lessSixthPlate_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(sixthPlateCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            sixthPlateCounter.Text = cantidadBebida.ToString();
        }

        private void addFirstPlate_Click(object sender, EventArgs e)
        {
            string primerPlato = merluza.Text;
            int kantitatea = Convert.ToInt32(firstPlateCounter.Text);

            PlateraEskaeraKudeaketa plateraEskaera = new PlateraEskaeraKudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addSecondPlate_Click(object sender, EventArgs e)
        {
            string primerPlato = entrecot.Text;
            int kantitatea = Convert.ToInt32(secondPlateCounter.Text);

            PlateraEskaeraKudeaketa plateraEskaera = new PlateraEskaeraKudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addThirdPlate_Click(object sender, EventArgs e)
        {
            string primerPlato = carrillera.Text;
            int kantitatea = Convert.ToInt32(thirdPlateCounter.Text);

            PlateraEskaeraKudeaketa plateraEskaera = new PlateraEskaeraKudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addFourthPlate_Click(object sender, EventArgs e)
        {
            string primerPlato = chipirones.Text;
            int kantitatea = Convert.ToInt32(fouthPlateCounter.Text);

            PlateraEskaeraKudeaketa plateraEskaera = new PlateraEskaeraKudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string primerPlato = pollo.Text;
            int kantitatea = Convert.ToInt32(fifthPlateCounter.Text);

            PlateraEskaeraKudeaketa plateraEskaera = new PlateraEskaeraKudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addSixthPlate_Click(object sender, EventArgs e)
        {
            string primerPlato = bacalao.Text;
            int kantitatea = Convert.ToInt32(sixthPlateCounter.Text);

            PlateraEskaeraKudeaketa plateraEskaera = new PlateraEskaeraKudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }
    }
}
