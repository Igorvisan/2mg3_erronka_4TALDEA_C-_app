using MySqlX.XDevAPI;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.eskaria
{
    public class EskaeraKudeaketa
    {
        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;


        public void actualizarPedidoGlobal()
        {
            recuperarPrecioaximoPlato();
            recuperarPrecioMaximoBebida();

            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    int idEskaeraGlobal = (int)eskaeraGlobal.EskaeraDatua["idEskaera"];
                    double prezioPlatoMaximo = (double)eskaeraGlobal.EskaeraDatua["prezioPlatoMaximo"];
                    double prezioEdariMaximo = (double)eskaeraGlobal.EskaeraDatua["prezioEdariMaximo"];

                    if (prezioPlatoMaximo <= 0 || prezioEdariMaximo <= 0)
                    {
                        MessageBox.Show("El precio total de los platos o bebidas es inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    double prezioTotalEskaera = prezioPlatoMaximo + prezioEdariMaximo;

                    var r = mySession.Get<erronka_2mg3_app.eskaria.Eskaera>(idEskaeraGlobal);
                    r.Totala = prezioTotalEskaera;
                    mySession.Update(r);
                    mySession.Flush();
                    mySession.Clear();
                    transaccion.Commit();

                    eskaeraGlobal.EskaeraDatua["prezioPlatoMaximo"] = prezioPlatoMaximo;

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Error al realizar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

        public void recuperarPrecioaximoPlato()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    int idEskaeraGlobal = (int)eskaeraGlobal.EskaeraDatua["idEskaera"];

                    string prezioPlatoHql = "SELECT SUM(pl.Prezioa) FROM plateraEskaria pl WHERE pl.EskaeraId = :idEskaera";

                    var queryPrezioPlato = mySession.CreateQuery(prezioPlatoHql);

                    queryPrezioPlato.SetParameter("idEskaera", idEskaeraGlobal);

                    var prezioMaximo = queryPrezioPlato.UniqueResult<double>();

                    if (prezioMaximo > 0)
                    {
                        if (!eskaeraGlobal.EskaeraDatua.ContainsKey("prezioPlatoMaximo"))
                        {
                            eskaeraGlobal.EskaeraDatua.Add("prezioPlatoMaximo", prezioMaximo);
                        }
                        else
                        {
                            eskaeraGlobal.EskaeraDatua["prezioPlatoMaximo"] = prezioMaximo;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor del precio total del plato es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    Console.WriteLine($"Error al realizar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void recuperarPrecioMaximoBebida()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    int idEskaeraGlobal = (int)eskaeraGlobal.EskaeraDatua["idEskaera"];

                    string prezioEdariaHql = "SELECT SUM(ed.Prezioa) FROM EskaeraEdaria ed WHERE ed.EskaeraId = :idEskaera";

                    var queryPrezioEdaria = mySession.CreateQuery(prezioEdariaHql);

                    queryPrezioEdaria.SetParameter("idEskaera", idEskaeraGlobal);

                    var prezioMaximo = queryPrezioEdaria.UniqueResult<double>();

                    if (prezioMaximo > 0) { 
                        if(!eskaeraGlobal.EskaeraDatua.ContainsKey("prezioEdariMaximo"))
                        {
                            eskaeraGlobal.EskaeraDatua.Add("prezioEdariMaximo", prezioMaximo);
                        }
                        else
                        {
                            eskaeraGlobal.EskaeraDatua["prezioEdariMaximo"] = prezioMaximo;
                        }
                    }
                    else
                    {
                        MessageBox.Show("El valor del precio total de la bebida es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    Console.WriteLine($"Error al realizar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
