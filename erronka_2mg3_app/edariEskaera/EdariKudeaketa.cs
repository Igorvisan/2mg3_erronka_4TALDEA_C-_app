using erronka_2mg3_app.edaria;
using erronka_2mg3_app.edariEskaera;
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
                    string edariaHql = "SELECT ed.Id, ed.Prezioa FROM Edaria ed WHERE ed.Izena = :izenaParam";
                    var queryEdaria = mySession.CreateQuery(edariaHql);

                    queryEdaria.SetParameter("izenaParam", edariIzenaButton);

                    //Usaremos el tipo object como argumento en el UniqueResult para poder recoger los valores de la query y asignarlos a las variables
                    var resultado = queryEdaria.UniqueResult<object[]>();


                    if (resultado != null)
                    {
                        int idEdaria = (int)resultado[0];
                        double edariPrezioa = (double)resultado[1];

                        if (!eskaeraGlobal.EskaeraDatua.ContainsKey("edariPrezioa") && !eskaeraGlobal.EskaeraDatua.ContainsKey("edariKantitatea")
                            && !eskaeraGlobal.EskaeraDatua.ContainsKey("idEdaria"))
                        {
                            eskaeraGlobal.EskaeraDatua.Add("edariPrezioa", edariPrezioa);
                            eskaeraGlobal.EskaeraDatua.Add("edariKantitatea", kantitatea);
                            eskaeraGlobal.EskaeraDatua.Add("idEdaria", idEdaria);

                            insertEdariEskaera();
                        }
                        else
                        {
                            eskaeraGlobal.EskaeraDatua["edariPrezioa"] = edariPrezioa;
                            eskaeraGlobal.EskaeraDatua["edariKantitatea"] = kantitatea;
                            eskaeraGlobal.EskaeraDatua["idEdaria"] = idEdaria;

                            insertEdariEskaera();
                        }
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido {edariIzenaButton} con la ID: {idEdaria} con un precio de {edariPrezioa}€ con la cantidad de {kantitatea}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void insertEdariEskaera()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    int idEskaera = (int)eskaeraGlobal.EskaeraDatua["idEskaera"];
                    int idEdaria = (int)eskaeraGlobal.EskaeraDatua["idEdaria"];
                    double edariPrezioa = (double)eskaeraGlobal.EskaeraDatua["edariPrezioa"];
                    int edariKantitatea = (int)eskaeraGlobal.EskaeraDatua["edariKantitatea"];

                    if (edariPrezioa <= 0 || edariKantitatea <= 0)
                    {

                        MessageBox.Show("No se ha podido completar la operacion: La cantidad o el precio no pueden ser menores o iguales a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var eskaera = mySession.Get<erronka_2mg3_app.eskaria.Eskaera>(idEskaera);
                        var edaria = mySession.Get<erronka_2mg3_app.edaria.Edaria>(idEdaria);

                        double prezioFinala = edariPrezioa * edariKantitatea;

                        var edariEskaera = new EskaeraEdaria
                        {
                            EskaeraId = eskaera,
                            EdariaId = edaria,
                            Prezioa = prezioFinala,
                            Kantitatea = edariKantitatea
                        };

                        mySession.Save(edariEskaera);
                        MessageBox.Show("El pedido se ha efectuado correctamente", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mySession.Flush();
                        mySession.Clear();
                        transaccion.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido completar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
