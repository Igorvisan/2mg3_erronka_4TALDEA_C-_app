using erronka_2mg3_app.edariEskaera;
using erronka_2mg3_app.eskaria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.plateraEskaeria
{
    public class PlateraEskaera_kudeaketa
    {
        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        public void plateraEskaeraGorde()
        {
            EdariaKudeaketa eskaeraIdGorde = new EdariaKudeaketa();
            eskaeraIdGorde.eskariaGorde();
        }

        public void plateraEskaeraEgin(int kantitatea, string plateraIzenaButton)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();


            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string plateraHql = "SELECT pl.Id, pl.Prezioa FROM platera pl WHERE pl.Izena = :izenaParam";
                    var queryEdaria = mySession.CreateQuery(plateraHql);

                    queryEdaria.SetParameter("izenaParam", plateraIzenaButton);

                    //Usaremos el tipo object como argumento en el UniqueResult para poder recoger los valores de la query y asignarlos a las variables
                    var resultado = queryEdaria.UniqueResult<object[]>();


                    if (resultado != null)
                    {
                        int idPlatera = (int)resultado[0];
                        double platerPrezioa = (double)resultado[1];

                        if (!eskaeraGlobal.EskaeraDatua.ContainsKey("plateraPrezioa") && !eskaeraGlobal.EskaeraDatua.ContainsKey("platerKantitatea")
                            && !eskaeraGlobal.EskaeraDatua.ContainsKey("idPlatera"))
                        {
                            eskaeraGlobal.EskaeraDatua.Add("plateraPrezioa", platerPrezioa);
                            eskaeraGlobal.EskaeraDatua.Add("platerKantitatea", kantitatea);
                            eskaeraGlobal.EskaeraDatua.Add("idPlatera", idPlatera);

                            insertPlateraEskaera();
                        }
                        else
                        {
                            eskaeraGlobal.EskaeraDatua["plateraPrezioa"] = platerPrezioa;
                            eskaeraGlobal.EskaeraDatua["platerKantitatea"] = kantitatea;
                            eskaeraGlobal.EskaeraDatua["idPlatera"] = idPlatera;

                            insertPlateraEskaera();

                        }
                        transaccion.Commit();
                        MessageBox.Show($"Has escogido {plateraIzenaButton} con la ID: {idPlatera} con un precio de {platerPrezioa}€ con la cantidad de {kantitatea}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido encontrar el precio de la bebida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se ha podido completar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void insertPlateraEskaera()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            horaDeServir();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                { 
                    DateTime fechaPedido = Convert.ToDateTime(eskaeraGlobal.EskaeraDatua["dateTimeNow"]);
                    DateTime fechaServir = Convert.ToDateTime(eskaeraGlobal.EskaeraDatua["horaFinal"]);
                    int idEskaera = (int)eskaeraGlobal.EskaeraDatua["idEskaera"];
                    int idPlatera = (int)eskaeraGlobal.EskaeraDatua["idPlatera"];
                    double platerPrezioa = (double)eskaeraGlobal.EskaeraDatua["plateraPrezioa"];
                    int platerKantitatea = (int)eskaeraGlobal.EskaeraDatua["platerKantitatea"];

                    if (platerPrezioa <= 0 || platerKantitatea <= 0)
                    {
                        MessageBox.Show("No se ha podido completar la operacion: La cantidad o el precio no pueden ser menores o iguales a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        var eskaera = mySession.Get<erronka_2mg3_app.eskaria.Eskaera>(idEskaera);
                        var platera = mySession.Get<erronka_2mg3_app.platera.platera>(idPlatera);

                        double prezioFinala = platerPrezioa * platerKantitatea;

                        var eskaeraPlatera = new plateraEskaria
                        {
                            EskaeraId = eskaera,
                            PlateraId = platera,
                            Prezioa = prezioFinala,
                            Kantitatea = platerKantitatea,
                            EskaeraOrdua = fechaPedido,
                            ZerbitzatzekoOrdua = fechaServir
                        };

                        mySession.Save(eskaeraPlatera);
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

        public void horaDeServir()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            try
            {
                DateTime dateTimePedido = DateTime.Now;

                string horaPedido = dateTimePedido.ToString("HH:mm");

                if (!eskaeraGlobal.EskaeraDatua.ContainsKey("dateTimeNow"))
                {
                    eskaeraGlobal.EskaeraDatua.Add("dateTimeNow", horaPedido);
                }
                else
                {
                    eskaeraGlobal.EskaeraDatua["dateTimeNow"] = horaPedido;
                }

                string[] wordsHoras = horaPedido.Split(':');

                int horas = Convert.ToInt32(wordsHoras[0]);
                int minutos = Convert.ToInt32(wordsHoras[1]);

                using (mySession = mySessionFactory.OpenSession())
                using (var transaccion = mySession.BeginTransaction())
                {
                    try
                    {
                        int idPlatera = (int)eskaeraGlobal.EskaeraDatua["idPlatera"];

                        string horaPreparada = "SELECT pl.PrestaketaDenbora FROM platera pl WHERE pl.Id = :idParam";

                        var queryHora = mySession.CreateQuery(horaPreparada);

                        queryHora.SetParameter("idParam", idPlatera);

                        var resultadoHora = queryHora.UniqueResult<int>();

                        if (resultadoHora != 0)
                        {
                            int prestaketaDenbora = resultadoHora;
                            int minutosTotales = minutos + prestaketaDenbora;

                            if (minutosTotales >= 60)
                            {
                                horas += minutosTotales / 60;
                                minutosTotales %= 60;
                            }

                            // Formatear hora final con ceros a la izquierda
                            string horaFinal = $"{horas:D2}:{minutosTotales:D2}";

                            DateTime parsedDate = DateTime.ParseExact(horaFinal, "HH:mm", CultureInfo.InvariantCulture);

                            if (!eskaeraGlobal.EskaeraDatua.ContainsKey("horaFinal"))
                            {
                                eskaeraGlobal.EskaeraDatua.Add("horaFinal", parsedDate);
                            }
                            else
                            {
                                eskaeraGlobal.EskaeraDatua["horaFinal"] = parsedDate;
                            }

                            transaccion.Commit();

                            MessageBox.Show($"El pedido se ha efectuado correctamente y se servirá a las {horaFinal}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido encontrar la hora de preparación del plato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaccion.Rollback();
                        MessageBox.Show($"No se ha podido completar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido completar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
