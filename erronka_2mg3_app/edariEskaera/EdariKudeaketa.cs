using erronka_2mg3_app.edaria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.eskaria
{
    public class EdariaKudeaketa
    {
        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public void eskariaGorde()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccon = mySession.BeginTransaction())
            {
                try
                {
                    // Cambia "esk" por el alias correcto
                    string hqlEskaera = "SELECT MAX(e.Id) FROM Eskaera e";

                    var queryEskaera = mySession.CreateQuery(hqlEskaera);

                    var idEskaera = queryEskaera.UniqueResult<int>();

                    if (idEskaera != 0)
                    {
                        if (!eskaeraGlobal.EskaeraDatua.ContainsKey("idEskaera"))
                        {
                            eskaeraGlobal.EskaeraDatua.Add("idEskaera", idEskaera);
                        }
                        else
                        {
                            eskaeraGlobal.EskaeraDatua["idEskaera"] = idEskaera;
                        }
                        transaccon.Commit();
                        MessageBox.Show("El id de la eskaera se ha guardado correctamente", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido guardar el id de la eskaera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    transaccon.Rollback();
                    MessageBox.Show($"Errorea eskaera egiterakoan: {ex.Message}");
                    return;
                }
            }
        }

        public void edariEskaeraEgin(int kantitatea, string edariIzenaButton)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string edariaHql = "SELECT ed.Prezioa FROM Edaria ed WHERE ed.Izena = :izenaParam";
                    var queryEdaria = mySession.CreateQuery(edariaHql);

                    queryEdaria.SetParameter("izenaParam", edariIzenaButton);

                    var edariPrezioa = queryEdaria.UniqueResult<double>();

                    if (edariPrezioa != 0)
                    {
                        if (!eskaeraGlobal.EskaeraDatua.ContainsKey("edariPrezioa"))
                        {
                            eskaeraGlobal.EskaeraDatua.Add("edariPrezioa", edariPrezioa);

                        }
                        else
                        {
                            eskaeraGlobal.EskaeraDatua["edariPrezioa"] = edariPrezioa;
                        }
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido {edariIzenaButton} con un precio de {edariPrezioa}€", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido encontrar el precio de la bebida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"No se ha podido completar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
