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

namespace erronka_2mg3_app.Fakturazioa
{
    public partial class EskaeraResumen : Form
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public EskaeraResumen()
        {
            InitializeComponent();
        }

        private void EskaeraResumen_Load(object sender, EventArgs e)
        {
            fakturazioKudeaketa fakturazioKudeaketa = new fakturazioKudeaketa();

            fakturazioKudeaketa.listaPlaterasYGeneraLabels(laburpenBox);
            fakturazioKudeaketa.listaBebidasYGenerarLabels(laburpenBox);

            fakturazioKudeaketa.recuperarPrecioMaximoPedido(totalNumber);

            int idMesa = (int)eskaeraGlobal.EskaeraDatua["idMesa"];

            numMesa.Text = idMesa.ToString();
        }

        private void sacarTicketPdf_Click(object sender, EventArgs e)
        {
            fakturazioKudeaketa crearFactura = new fakturazioKudeaketa();
            crearFactura.crearFacturaPdf(path);
        }

        private void borrarPedido_Click(object sender, EventArgs e)
        {
            fakturazioKudeaketa borrarFactura = new fakturazioKudeaketa();
            borrarFactura.borrarPedidoGeneral();
            this.Close();

        }
    }
}
