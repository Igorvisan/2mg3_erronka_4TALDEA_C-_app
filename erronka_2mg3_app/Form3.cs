using erronka_2mg3_app.Sukaldea;
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
    public partial class cocinaPantalla : Form
    {
        private string nombreUsuario;
        public cocinaPantalla(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
            this.Resize += new EventHandler(CocinaPantalla_Resize); // Suscribirse al evento Resize
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);
            sukaldeUser.Text = nombreUsuario;

            Sukalde_kudeaketa sukaldeKudeaketa = new Sukalde_kudeaketa();

            sukaldeKudeaketa.imprimirPedidosDelDia(sukaldePlaterak);
            this.WindowState = FormWindowState.Maximized;

            // Llamar al método Resize al cargar
            CocinaPantalla_Resize(this, EventArgs.Empty);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void nextButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CocinaPantalla_Resize(object sender, EventArgs e)
        {
            // Colocar el nombre de usuario en la parte superior derecha
            sukaldeUser.Location = new Point(
                this.ClientSize.Width - sukaldeUser.Width - 20,
                20 // Ajustar para que esté cerca de la parte superior derecha
            );

            // Colocar el GroupBox de platos en el centro de la pantalla
            sukaldePlaterak.Location = new Point(
                (this.ClientSize.Width - sukaldePlaterak.Width) / 2,
                (this.ClientSize.Height - sukaldePlaterak.Height) / 2
            );

            // Colocar el botón "TERMINAR" centrado debajo del GroupBox
            nextButton.Location = new Point(
                (this.ClientSize.Width - nextButton.Width) / 2,
                sukaldePlaterak.Location.Y + sukaldePlaterak.Height + 20 // Ajustar verticalmente
            );

            // Colocar el botón "EGUNERATU" justo al lado del panel
            button1.Location = new Point(
                sukaldePlaterak.Location.X + sukaldePlaterak.Width + 10, // Ajustar horizontalmente
                sukaldePlaterak.Location.Y // Mantener la misma altura que el panel
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sukalde_kudeaketa sukaldeKudeaketa = new Sukalde_kudeaketa();

            sukaldeKudeaketa.imprimirPedidosDelDia(sukaldePlaterak);
        }
    }
}
