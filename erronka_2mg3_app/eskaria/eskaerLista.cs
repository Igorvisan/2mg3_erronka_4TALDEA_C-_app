using erronka_2mg3_app.Fakturazioa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.eskaria
{
    public partial class eskaerLista : Form
    {
        private string nombreUsuario;
        public eskaerLista(string username)
        {
            InitializeComponent();
            nombreUsuario = username;
        }

        private void eskaerLista_Load(object sender, EventArgs e)
        {
            EskaeraKudeaketa eskariakErakutsi = new EskaeraKudeaketa();
            eskariakErakutsi.listarPedidos(listaPedidos);
        }

        private void listaPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;

            int id = Convert.ToInt32(listaPedidos.Rows[rowIndex].Cells[0].Value);
            int mahiaId = Convert.ToInt32(listaPedidos.Rows[rowIndex].Cells[1].Value);

            if(!eskaeraGlobal.EskaeraDatua.ContainsKey("idEskaera") && !eskaeraGlobal.EskaeraDatua.ContainsKey("idMesa"))
            {
                eskaeraGlobal.EskaeraDatua.Add("idEskaera", id);
                eskaeraGlobal.EskaeraDatua.Add("idMesa", mahiaId);
                MessageBox.Show("Se ha guardado los id correctamente", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                eskaeraGlobal.EskaeraDatua["idEskaera"] = id;
                eskaeraGlobal.EskaeraDatua["idMesa"] = mahiaId;
                MessageBox.Show("Se ha guardado el id correctamente", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EskaeraResumen resumenPedido = new EskaeraResumen(nombreUsuario);
            resumenPedido.Show();
            this.Hide();

        }
    }
}
