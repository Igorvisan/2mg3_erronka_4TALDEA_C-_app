using erronka_2mg3_app.chat;
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
            
        }

        private void comenzarComanda_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);
            userName.Text = nombreUsuario;

            nuevoPedido.BackColor = Color.FromArgb(118, 138, 153);
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
    }
}
