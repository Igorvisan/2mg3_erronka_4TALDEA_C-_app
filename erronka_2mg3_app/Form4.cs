using erronka_2mg3_app.produkto;
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
    public partial class adminPantalla : Form
    {
        private string nombreUsuario;
        private Timer updateTimer;
        public produktua_kudeaketa kudeaketaProduktua = new produktua_kudeaketa();

        public adminPantalla(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
            updateTimer = new Timer();

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            kudeaketaProduktua.ListarProductos(dataTableProduct);
        }

        private void adminPantalla_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);
            adminUserName.Text = nombreUsuario;

            updateTimer.Start();

            kudeaketaProduktua.ListarProductos(dataTableProduct);

        }

        public void startTimer()
        {
            // Inicializa el Timer
            updateTimer = new Timer();
            updateTimer.Interval = 10000; // Intervalo en milisegundos (10,000 ms = 10 segundos)
            updateTimer.Tick += UpdateTimer_Tick;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
