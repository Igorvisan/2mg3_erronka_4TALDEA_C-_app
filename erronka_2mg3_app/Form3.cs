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
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(52, 90, 123);
            sukaldeUser.Text = nombreUsuario;
        }
    }
}
