using erronka_2mg3_app.chat;
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
            this.Resize += new EventHandler(MesaDePedido_Resize); // Suscribirse al evento Resize
        }

        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;

        private void mesaDePedido_Load(object sender, EventArgs e)
        {
            userName.Text = nombreUsuario;

            this.BackColor = Color.FromArgb(52, 90, 123);


            confirmarMesa();

            this.WindowState = FormWindowState.Maximized;

            // Llamar al método Resize al cargar
            MesaDePedido_Resize(this, EventArgs.Empty);

        }

        private void confirmarMesa()
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    // Obtener todas las mesas desde la base de datos
                    string hql = "SELECT mai.Izena, mai.Id FROM mahaia mai";
                    var seleccion = mySession.CreateQuery(hql);
                    var resultados = seleccion.List<object[]>();

                    // Crear y configurar el FlowLayoutPanel
                    FlowLayoutPanel panelMesas = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.LeftToRight,
                        WrapContents = true,
                        AutoSize = false,
                        Width = 800, // Tamaño fijo del ancho del panel
                        Height = 300, // Tamaño fijo de la altura del panel
                        Padding = new Padding(10), // Espaciado interno
                        Margin = new Padding(20), // Espaciado externo
                        BackColor = Color.LightBlue // Fondo para identificar el área
                    };

                    foreach (var resultado in resultados)
                    {
                        string mesaNombre = (string)resultado[0];
                        int mesaId = (int)resultado[1];

                        Button btn = new Button
                        {
                            Text = mesaNombre,
                            Width = 120, // Ajustar el tamaño del botón
                            Height = 60,
                            Margin = new Padding(10), // Espaciado entre botones
                            FlatStyle = FlatStyle.Flat // Estilo visual plano
                        };

                        btn.Click += (sender, e) =>
                        {
                            // Acción cuando se presiona el botón
                            if (!eskaeraGlobal.EskaeraDatua.ContainsKey("idMesa"))
                            {
                                eskaeraGlobal.EskaeraDatua.Add("idMesa", mesaId);
                            }
                            else
                            {
                                eskaeraGlobal.EskaeraDatua["idMesa"] = mesaId;
                            }
                            MessageBox.Show($"Has escogido la mesa: {mesaNombre} con ID {mesaId}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        };

                        panelMesas.Controls.Add(btn);
                    }

                    // Centrar el panel en el formulario
                    panelMesas.Location = new Point(
                        (this.ClientSize.Width - panelMesas.Width) / 2,
                        (this.ClientSize.Height - panelMesas.Height) / 2
                    );

                    // Escuchar el evento Resize para mantenerlo centrado
                    this.Resize += (s, e) =>
                    {
                        panelMesas.Location = new Point(
                            (this.ClientSize.Width - panelMesas.Width) / 2,
                            (this.ClientSize.Height - panelMesas.Height) / 2
                        );
                    };

                    // Agregar el FlowLayoutPanel al formulario
                    this.Controls.Add(panelMesas);

                    transaccion.Commit();
                    MessageBox.Show($"Se han generado {resultados.Count} botones para las mesas.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ha ocurrido un error durante la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edariScreenButton_Click(object sender, EventArgs e)
        {
            tpvPantaila tpvPantaila = new tpvPantaila(nombreUsuario);
            elegirMesa();
            tpvPantaila.Show();
            this.Hide();
        }

        private void elegirMesa()
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

        private void select_Click(object sender, EventArgs e)
        {
            elegirMesa();
            tpvPantaila bebidas = new tpvPantaila(nombreUsuario);
            bebidas.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chatApp newChat = new chatApp(nombreUsuario);
            newChat.Show();
        }

        private void MesaDePedido_Resize(object sender, EventArgs e)
        {
            // Colocar el nombre de usuario en la parte superior derecha
            userName.Location = new Point(
                this.ClientSize.Width - userName.Width - 20,
                20 // Ajustar para que esté cerca de la parte superior derecha
            );

            // Colocar el botón "SELECCIONAR" más hacia el medio
            select.Location = new Point(
                (this.ClientSize.Width - select.Width) / 2,
                (this.ClientSize.Height / 2) + 150 // Ajustar verticalmente
            );

            // Colocar el FlowLayoutPanel centrado
            foreach (Control control in this.Controls)
            {
                if (control is FlowLayoutPanel panelMesas)
                {
                    panelMesas.Location = new Point(
                        (this.ClientSize.Width - panelMesas.Width) / 2,
                        (this.ClientSize.Height - panelMesas.Height) / 2
                    );
                }
            }
        }

        private void userName_Click(object sender, EventArgs e)
        {

        }
    }
}
