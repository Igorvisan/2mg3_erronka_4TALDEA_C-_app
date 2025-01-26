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
        private Timer timerActualizacion; // Timer para la actualización periódica
        private Dictionary<int, bool> pedidosListos; // Diccionario para controlar el estado de los pedidos

        public Sukalde_kudeaketa()
        {
            pedidosListos = new Dictionary<int, bool>();
            timerActualizacion = new Timer();
            timerActualizacion.Interval = 30000; 
            timerActualizacion.Tick += (s, e) => ActualizarPedidos(null);
            timerActualizacion.Start();
        }

        public void imprimirPedidosDelDia(GroupBox platos)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            ActualizarPedidos(platos);
        }

        private void ActualizarPedidos(GroupBox platos)
        {
            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    DateTime fechaHoyInicio = DateTime.Today;
                    DateTime fechaHoyFin = DateTime.Today.AddDays(1).AddTicks(-1);

                    var hql = @"
                        SELECT pl.Izena, pl.PlaterMota, pe.ZerbitzatzekoOrdua, pe.Kantitatea, pe.Id
                        FROM plateraEskaria pe
                        JOIN pe.PlateraId pl
                        WHERE pe.ZerbitzatzekoOrdua BETWEEN :fechaHoyInicio AND :fechaHoyFin";

                    var query = mySession.CreateQuery(hql);
                    query.SetParameter("fechaHoyInicio", fechaHoyInicio);
                    query.SetParameter("fechaHoyFin", fechaHoyFin);

                    var listaPlatos = query.List<object[]>();

                    if (listaPlatos.Count == 0)
                    {
                        if (platos != null)
                        {
                            MessageBox.Show("No hay platos en el rango de la fecha actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        return;
                    }

                    // Si se pasa un GroupBox (es decir, en la primera llamada), limpiamos y actualizamos la UI
                    if (platos != null)
                    {
                        platos.Controls.Clear();

                        Panel panelPedidos = new Panel();
                        panelPedidos.Dock = DockStyle.Fill;
                        panelPedidos.AutoScroll = true;
                        platos.Controls.Add(panelPedidos);

                        int posY = 10;
                        int groupBoxWidth = platos.Width;

                        foreach (var plato in listaPlatos)
                        {
                            string nombrePlato = (string)plato[0];
                            string tipoPlato = (string)plato[1];
                            DateTime zerbitzatzekoOrdura = (DateTime)plato[2];
                            int kantitatea = (int)plato[3];
                            int pedidoId = (int)plato[4];

                            Label lblPlato = new Label();
                            lblPlato.Text = $"{nombrePlato} ({tipoPlato}) - {zerbitzatzekoOrdura:HH:mm} - Cantidad: {kantitatea}";
                            lblPlato.AutoSize = true;

                            // Verificar si el pedido ya está marcado como listo
                            if (pedidosListos.ContainsKey(pedidoId) && pedidosListos[pedidoId])
                            {
                                lblPlato.ForeColor = System.Drawing.Color.LimeGreen;
                            }
                            else
                            {
                                lblPlato.ForeColor = System.Drawing.Color.White;
                            }

                            lblPlato.Font = new System.Drawing.Font(lblPlato.Font.FontFamily, 14, lblPlato.Font.Style);

                            // Calcular posición X para centrar el label
                            int labelWidth = TextRenderer.MeasureText(lblPlato.Text, lblPlato.Font).Width;
                            lblPlato.Location = new System.Drawing.Point((groupBoxWidth - labelWidth) / 2, posY);

                            // Agregar el evento Click para marcar como listo
                            lblPlato.Click += (sender, e) => MarcarPedidoListo(sender, pedidoId);

                            // Agregar el Label al Panel
                            panelPedidos.Controls.Add(lblPlato);
                            posY += 30; // Incrementa la posición Y para el siguiente label
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido hacer la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MarcarPedidoListo(object sender, int pedidoId)
        {
            var label = sender as Label;
            if (label != null)
            {
                // Cambiar el color del texto a verde
                label.ForeColor = System.Drawing.Color.LimeGreen;

                // Registrar el pedido como listo en el diccionario
                if (!pedidosListos.ContainsKey(pedidoId))
                {
                    pedidosListos.Add(pedidoId, true);
                }
                else
                {
                    pedidosListos[pedidoId] = true;
                }

                MessageBox.Show("¡El plato ha sido marcado como listo!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
