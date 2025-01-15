using erronka_2mg3_app.edaria;
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
        private void hurrengoBotoia_Click(object sender, EventArgs e)
        {
            bigarren_platera bigarren_Platera = new bigarren_platera(nombreUsuario);
            bigarren_Platera.Show();
            this.Hide();
        }

        private void plusFirstDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstDishCounter.Text);

            cantidadBebida++;

            firstDishCounter.Text = cantidadBebida.ToString();
        }

        private void lessFirstDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(firstDishCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            firstDishCounter.Text = cantidadBebida.ToString();
        }

        private void plusSecondDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondDishCounter.Text);

            cantidadBebida++;

            secondDishCounter.Text = cantidadBebida.ToString();
        }

        private void lessSecondDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondDishCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            secondDishCounter.Text = cantidadBebida.ToString();
        }

        private void plusThirdDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdDishCounter.Text);

            cantidadBebida++;

            thirdDishCounter.Text = cantidadBebida.ToString();
        }

        private void lessThirdDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdDishCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            thirdDishCounter.Text = cantidadBebida.ToString();
        }

        private void plusFourthDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fourthDishCounter.Text);

            cantidadBebida++;

            fourthDishCounter.Text = cantidadBebida.ToString();
        }

        private void lessFourthDIsh_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fourthDishCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fourthDishCounter.Text = cantidadBebida.ToString();
        }

        private void plusFifthDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fifthDishCounter.Text);

            cantidadBebida++;

            fifthDishCounter.Text = cantidadBebida.ToString();
        }

        private void lessFifthDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fifthDishCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fifthDishCounter.Text = cantidadBebida.ToString();
        }

        private void plusSixthDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(sisxthDishCounter.Text);

            cantidadBebida++;

            sisxthDishCounter.Text = cantidadBebida.ToString();
        }

        private void lessSixthDish_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(sisxthDishCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            sisxthDishCounter.Text = cantidadBebida.ToString();
        }

        private void addFirstDish_Click(object sender, EventArgs e)
        {
            string primerPlato = sopaPescado.Text;
            int kantitatea = Convert.ToInt32(firstDishCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addSecondDish_Click(object sender, EventArgs e)
        {
            string primerPlato = alubias.Text;
            int kantitatea = Convert.ToInt32(secondDishCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addThirdDish_Click(object sender, EventArgs e)
        {
            string primerPlato = ensaladaMixta.Text;
            int kantitatea = Convert.ToInt32(thirdDishCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addFourthDish_Click(object sender, EventArgs e)
        {
            string primerPlato = ensaladaTemplada.Text;
            int kantitatea = Convert.ToInt32(fourthDishCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addFifthDish_Click(object sender, EventArgs e)
        {
            string primerPlato = pimientoRelleno.Text;
            int kantitatea = Convert.ToInt32(fifthDishCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }

        private void addSixthDish_Click(object sender, EventArgs e)
        {
            string primerPlato = chorizoSidra.Text;
            int kantitatea = Convert.ToInt32(sisxthDishCounter.Text);

            PlateraEskaera_kudeaketa plateraEskaera = new PlateraEskaera_kudeaketa();

            plateraEskaera.plateraEskaeraGorde();
            plateraEskaera.plateraEskaeraEgin(kantitatea, primerPlato);
        }
    }
}
