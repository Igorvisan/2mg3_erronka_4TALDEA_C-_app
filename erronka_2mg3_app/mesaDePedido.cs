using erronka_2mg3_app.eskaria;
using Mysqlx;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app
{
    public partial class mesaDePedido : Form
    {
        private string nombreUsuario;
        public mesaDePedido(string userName)
        {
            InitializeComponent();
            nombreUsuario = userName;
        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void mesaDePedido_Load(object sender, EventArgs e)
        {
            userName.Text = nombreUsuario;

            this.BackColor = Color.FromArgb(52, 90, 123);

            mahaiGroup.BackColor = Color.FromArgb(217, 217, 217);

            mesa1.BackColor = Color.FromArgb(118, 138, 153);
            mesa2.BackColor = Color.FromArgb(118, 138, 153);
            mesa3.BackColor = Color.FromArgb(118, 138, 153);
            mesa4.BackColor = Color.FromArgb(118, 138, 153);
            mesa5.BackColor = Color.FromArgb(118, 138, 153);
            mesa6.BackColor = Color.FromArgb(118, 138, 153);
            edariScreenButton.BackColor = Color.FromArgb(118, 138, 153);
        }

        private void mesa1_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa1.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa2_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa2.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa3_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa3.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa4_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa4.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa5_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa5.Text;
            confirmarMesa(nombreMesa);
        }

        private void mesa6_Click(object sender, EventArgs e)
        {
            string nombreMesa = mesa6.Text;
            confirmarMesa(nombreMesa);
        }

        private void confirmarMesa(string textoMesa)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string hql = "SELECT mai.Izena FROM mahaia mai WHERE mai.Izena = :izenaParam";

                    var seleccion = mySession.CreateQuery(hql);

                    seleccion.SetParameter("izenaParam", textoMesa);

                    var resultados = seleccion.UniqueResult<string>();

                    if (resultados != null)
                    {
                        string idHql = "SELECT mai.Id FROM mahaia mai WHERE mai.Izena = :izenaParam";
                        var idSeleccionado = mySession.CreateQuery(idHql);

                        idSeleccionado.SetParameter("izenaParam", textoMesa);
                        var idMesa = idSeleccionado.UniqueResult<int>();

                        if (idMesa != 0)
                        {
                            if (eskaeraGlobal.EskaeraDatua.ContainsKey("idMesa")){

                                eskaeraGlobal.EskaeraDatua.Add("idMesa", idMesa);
                            }
                            else { 
                                eskaeraGlobal.EskaeraDatua["idMesa"] = idMesa; 
                            }
                        }
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido la: {resultados} con ID {idMesa}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido elegir esa mesa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ha ocurrido un error durante la operacion: {ex.Message}", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edariScreenButton_Click(object sender, EventArgs e)
        {
            tpvPantaila tpvPantaila = new tpvPantaila(nombreUsuario);
            confirmarElPedidoMesa();
            tpvPantaila.Show();
            this.Hide();
        }

        private void confirmarElPedidoMesa()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();



            using (mySession = mySessionFactory.OpenSession())
            using (ITransaction tx = mySession.BeginTransaction())
            {
                try
                {
                    if (eskaeraGlobal.EskaeraDatua.Count == 0)
                    {
                        MessageBox.Show("No has seleccionado ninguna mesa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        int langileId = (int)eskaeraGlobal.EskaeraDatua["idTrabajador"];
                        int mahaiaId = (int)eskaeraGlobal.EskaeraDatua["idMesa"];

                        var mahaia = mySession.Get<erronka_2mg3_app.mahaia.mahaia>(mahaiaId);
                        var langilea = mySession.Get<erronka_2mg3_app.langileLogIn>(langileId);

                        Eskaera eskaera = new Eskaera(mahaia, langilea, null, null, null);
                        mySession.Save(eskaera);
                        MessageBox.Show("Se ha guardado la mesa correctamente", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mySession.Flush();
                        mySession.Clear();
                        tx.Commit();
                    }
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show($"Ha ocurrido un error durante la operacion: {ex.Message}", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
