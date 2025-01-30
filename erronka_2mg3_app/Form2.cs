using erronka_2mg3_app.chat;
using erronka_2mg3_app.edaria;
using erronka_2mg3_app.eskaria;
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

        private void addDrinkButton_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari1.Text;
            int kantitatea = Convert.ToInt32(firstDrinkCount.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void plusSecondButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondDrinkCount.Text);

            cantidadBebida++;

            secondDrinkCount.Text = cantidadBebida.ToString();
        }

        private void lessSecondButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(secondDrinkCount.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            secondDrinkCount.Text = cantidadBebida.ToString();
        }

        private void plusThridButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdDrinkCount.Text);

            cantidadBebida++;

            thirdDrinkCount.Text = cantidadBebida.ToString();
        }

        private void lessThirdButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(thirdDrinkCount.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            thirdDrinkCount.Text = cantidadBebida.ToString();
        }

        private void plusSeventhButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(seventhDrinkCounter.Text);

            cantidadBebida++;

            seventhDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void lessSeventhButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(seventhDrinkCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            seventhDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void lessFourthButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fourthDrinkCount.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fourthDrinkCount.Text = cantidadBebida.ToString();
        }
        private void plusForthButton_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fourthDrinkCount.Text);

            cantidadBebida++;

            fourthDrinkCount.Text = cantidadBebida.ToString();
        }

        private void plusFifthDrink_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fifthDrinkCounter.Text);

            cantidadBebida++;

            fifthDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void lessFifthDrink_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(fifthDrinkCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            fifthDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void plusSixthDrink_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(sisxthDrinkCounter.Text);

            cantidadBebida++;

            sisxthDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void lessSixthDrink_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(sisxthDrinkCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            sisxthDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void plusEightDrink_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(eightDrinkCounter.Text);

            cantidadBebida++;

            eightDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void lessEightDrink_Click(object sender, EventArgs e)
        {
            int cantidadBebida = Convert.ToInt32(eightDrinkCounter.Text);

            if (cantidadBebida == 0)
            {
                return;
            }

            cantidadBebida--;

            eightDrinkCounter.Text = cantidadBebida.ToString();
        }

        private void addSecondDrinkButton_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari2.Text;
            int kantitatea = Convert.ToInt32(secondDrinkCount.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void addThridDrinkButton_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari3.Text;
            int kantitatea = Convert.ToInt32(thirdDrinkCount.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void addFourthDrink_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari4.Text;
            int kantitatea = Convert.ToInt32(fourthDrinkCount.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void addFifthDrink_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari5.Text;
            int kantitatea = Convert.ToInt32(fifthDrinkCounter.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void addSixthDrink_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari6.Text;
            int kantitatea = Convert.ToInt32(sisxthDrinkCounter.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void addEightDrink_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari8.Text;
            int kantitatea = Convert.ToInt32(eightDrinkCounter.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void addSeventhDrinkButton_Click(object sender, EventArgs e)
        {
            string primeraBebida = edari7.Text;
            int kantitatea = Convert.ToInt32(seventhDrinkCounter.Text);
            EdariaKudeaketa edariaKudeaketa = new EdariaKudeaketa();

            edariaKudeaketa.eskariaGorde();
            edariaKudeaketa.edariEskaeraEgin(kantitatea, primeraBebida);
        }

        private void thirdDrinkCount_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chatApp newChat = new chatApp(nombreUsuario);
            newChat.Show();
        }
    }
}
