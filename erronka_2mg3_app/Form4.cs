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

            kudeaketaProduktua.comboBoxProducts(productsCombo);

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

        private void gehituBotoia_Click(object sender, EventArgs e)
        {
            produktua_kudeaketa añadirProduct = new produktua_kudeaketa();
            int kantitatea = Convert.ToInt32(txtKantitatea.Text);
            añadirProduct.gehituProduktua(productsCombo.Text, kantitatea);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           kudeaketaProduktua.ListarProductos(dataTableProduct);

            txtKantitatea.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void produktuaEguneratu_Click(object sender, EventArgs e)
        {
            int kantitatea = Convert.ToInt32(txtKantitatea.Text);
            kudeaketaProduktua.actualizarProducto(productsCombo.Text, kantitatea);
        }
    }
}
