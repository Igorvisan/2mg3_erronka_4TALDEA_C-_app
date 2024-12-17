using erronka_2mg3_app.edaria;
using NHibernate;
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
    }
}
