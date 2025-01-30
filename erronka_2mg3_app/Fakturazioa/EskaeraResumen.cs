using System;
using System.Windows.Forms;

namespace erronka_2mg3_app.Fakturazioa
{
    public partial class EskaeraResumen : Form
    {
        private string nombreUsuario;

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public EskaeraResumen(string userName)
        {
            InitializeComponent();
            userName = nombreUsuario;
        }

        private void EskaeraResumen_Load(object sender, EventArgs e)
        {
            fakturazioKudeaketa fakturazioKudeaketa = new fakturazioKudeaketa();

            fakturazioKudeaketa.listaPlaterasYGeneraLabels(laburpenBox);
            fakturazioKudeaketa.listaBebidasYGenerarLabels(laburpenBox);

            fakturazioKudeaketa.recuperarPrecioMaximoPedido(totalNumber);

            int idMesa = (int)eskaeraGlobal.EskaeraDatua["idMesa"];

            numMesa.Text = idMesa.ToString();

            userName.Text = nombreUsuario;

        }

        private void sacarTicketPdf_Click(object sender, EventArgs e)
        {
            fakturazioKudeaketa crearFactura = new fakturazioKudeaketa();
            crearFactura.crearFacturaPdf(path);

            nuevComanda nuevaComanda = new nuevComanda(nombreUsuario);
            nuevaComanda.Show();
            this.Hide();
        }

        private void borrarPedido_Click(object sender, EventArgs e)
        {
            fakturazioKudeaketa borrarFactura = new fakturazioKudeaketa();
            borrarFactura.borrarPedidoGeneral();

            nuevComanda nuevComanda = new nuevComanda(nombreUsuario);
            this.Close();
            nuevComanda.Show();

        }

    }
}
