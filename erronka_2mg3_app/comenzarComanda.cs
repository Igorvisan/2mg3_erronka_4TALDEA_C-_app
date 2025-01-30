using erronka_2mg3_app.chat;
using erronka_2mg3_app.eskaria;
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
    public partial class nuevComanda : Form
    {
        private string nombreUsuario;
        public nuevComanda(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
            this.Resize += new EventHandler(NuevComanda_Resize); // Suscribirse al evento Resize

        }

        private void comenzarComanda_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);
            userName.Text = nombreUsuario;

            nuevoPedido.BackColor = Color.FromArgb(118, 138, 153);
            this.WindowState = FormWindowState.Maximized;
        }

        private void nuevoPedido_Click(object sender, EventArgs e)
        {
            mesaDePedido mesaPedido = new mesaDePedido(nombreUsuario);
            mesaPedido.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chatApp newChat = new chatApp(nombreUsuario);
            newChat.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            eskaerLista listaPedidos = new eskaerLista(nombreUsuario);
            listaPedidos.Show();
            this.Hide();
        }

        private void userName_Click(object sender, EventArgs e)
        {

        }
        private void NuevComanda_Resize(object sender, EventArgs e)
        {
            // Colocar el nombre de usuario en la esquina superior derecha
            userName.Location = new Point(
                this.ClientSize.Width - userName.Width - 20,
                20 // Ajustar para que esté cerca de la parte superior
            );

            // Colocar los botones "HACER NUEVA COMANDA" y "VER PEDIDOS" uno al lado del otro
            int buttonSpacing = 20; // Espacio entre los botones
            int totalButtonWidth = nuevoPedido.Width + button2.Width + buttonSpacing;

            nuevoPedido.Location = new Point(
                (this.ClientSize.Width - totalButtonWidth) / 2,
                (this.ClientSize.Height / 2) - 20 // Ajustar verticalmente
            );

            button2.Location = new Point(
                nuevoPedido.Location.X + nuevoPedido.Width + buttonSpacing,
                (this.ClientSize.Height / 2) - 20 // Ajustar verticalmente
            );

            // Colocar el botón de "CHAT"
            button1.Location = new Point(
                20, // Ajustar para que esté cerca de la parte superior izquierda
                20
            );

            // Colocar el botón de "ITXI APP" en la esquina inferior izquierda
            closeApp.Location = new Point(
                20, // Ajustar para que esté cerca de la parte inferior izquierda
                this.ClientSize.Height - closeApp.Height - 20
            );
        }

        private void closeApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
