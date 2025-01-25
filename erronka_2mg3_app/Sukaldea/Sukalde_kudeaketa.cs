using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.Sukaldea
{
    public class Sukalde_kudeaketa
    {
        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;


        public void imprimirPedidosDelDia(GroupBox platos)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    DateTime fechaHoyInicio = DateTime.Today;
                    DateTime fechaHoyFin = DateTime.Today.AddDays(1).AddTicks(-1);

                    var hql = @"
                        SELECT pl.Izena, pl.PlaterMota, pe.ZerbitzatzekoOrdua
                        FROM plateraEskaria pe
                        JOIN pe.PlateraId pl
                        WHERE pe.ZerbitzatzekoOrdua BETWEEN :fechaHoyInicio AND :fechaHoyFin";

                    var query = mySession.CreateQuery(hql);
                    query.SetParameter("fechaHoyInicio", fechaHoyInicio);
                    query.SetParameter("fechaHoyFin", fechaHoyFin);

                    var listaPlatos = query.List<object[]>();

                    if (listaPlatos.Count == 0)
                    {
                        MessageBox.Show("No hay platos en el rango de la fecha actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int posY = 10;
                    foreach (var plato in listaPlatos)
                    {
                        string nombrePlato = (string)plato[0];
                        string tipoPlato = (string)plato[1];
                        DateTime zerbitzatzekoOrdura = (DateTime)plato[2];

                        Label lblPlato = new Label();
                        lblPlato.Text = $"{nombrePlato} ({tipoPlato}) - {zerbitzatzekoOrdura}";
                        lblPlato.Location = new System.Drawing.Point(10, posY);
                        lblPlato.AutoSize = true;

                        platos.Controls.Add(lblPlato);
                        posY += 30; // Incrementa la posición Y para el siguiente label
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido hacer la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
