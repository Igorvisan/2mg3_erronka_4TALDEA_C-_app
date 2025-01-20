using iText.Kernel.Pdf;
using iText.StyledXmlParser.Jsoup.Nodes;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using System.IO;
using iText.Kernel.Font;
using iText.Kernel.Colors;


namespace erronka_2mg3_app.Fakturazioa
{
    public class fakturazioKudeaketa
    {
        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;


        public void listaPlaterasYGeneraLabels(GroupBox laburpenBox)
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

                    string hqlQueryDetails = @"
                        SELECT pl.PlateraId.Izena, pl.Prezioa, pl.Kantitatea 
                        FROM plateraEskaria pl 
                        WHERE pl.EskaeraId = :idParam";

                    var queryDetails = mySession.CreateQuery(hqlQueryDetails);
                    queryDetails.SetParameter("idParam", idEskaeraGlobal);

                    var resultsDetails = queryDetails.List<object[]>();

                    if (resultsDetails.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado plateras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int yOffset = 60; // Espaciado vertical
                    foreach (var item in resultsDetails)
                    {
                        string nombrePlato = (string)item[0];
                        double precio = (double)item[1];
                        int cantidad = (int)item[2];

                        Label label = new Label
                        {
                            Text = $"Plato: {nombrePlato}, Precio: {precio:C}, Cantidad: {cantidad}",
                            AutoSize = true,
                            Font = new Font("Arial", 10),
                            ForeColor = System.Drawing.Color.Black,
                            Location = new Point(10, yOffset) // Alineación a la izquierda
                        };
                        yOffset += 25;

                        laburpenBox.Controls.Add(label);
                    }

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido realizar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void listaBebidasYGenerarLabels(GroupBox laburpenBox)
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

                    string hqlQueryBebidaDetalles = @"SELECT ed.EdariaId.Izena, ed.Prezioa, ed.Kantitatea FROM EskaeraEdaria ed WHERE ed.EskaeraId = :idParam";

                    var queryBebidaDetalles = mySession.CreateQuery(hqlQueryBebidaDetalles);

                    queryBebidaDetalles.SetParameter("idParam", idEskaera);

                    var resultsBebidaDetalles = queryBebidaDetalles.List<object[]>();

                    if (resultsBebidaDetalles.Count == 0)
                    {
                        MessageBox.Show("No se han encontrado bebidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if(!eskaeraGlobal.EskaeraDatua.ContainsKey("edariIzenakLista"))
                    {
                        eskaeraGlobal.EskaeraDatua.Add("edariIzenakLista", resultsBebidaDetalles);
                    }
                    else
                    {
                        eskaeraGlobal.EskaeraDatua["edariIzenakLista"] = resultsBebidaDetalles;
                    }
                    int yOffset = 60; // Espaciado vertical
                    int xOffset = laburpenBox.Width / 2 + 80; // Alineación a la derecha del GroupBox
                    foreach (var item in resultsBebidaDetalles)
                    {
                        string nombreBebida = (string)item[0];
                        double precio = (double)item[1];
                        int cantidad = (int)item[2];

                        Label labelBebidas = new Label
                        {
                            Text = $"Bebida: {nombreBebida}, Precio: {precio:C}, Cantidad: {cantidad}",
                            AutoSize = true,
                            Font = new Font("Arial", 10),
                            ForeColor = System.Drawing.Color.Black,
                            Location = new Point(xOffset, yOffset) // Alineación a la derecha
                        };

                        yOffset += 25;

                        laburpenBox.Controls.Add(labelBebidas);
                    }

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido realizar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void recuperarPrecioMaximoPedido(Label labelText)
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

                    string queryHql = "SELECT es.Totala FROM Eskaera es WHERE es.Id = :idParam";

                    var query = mySession.CreateQuery(queryHql);

                    query.SetParameter("idParam", idEskaeraGlobal);

                    var total = query.UniqueResult<double>();

                    if (total != 0)
                    {
                        labelText.Text = total.ToString();
                    }
                    else
                    {
                        MessageBox.Show("El valor del precio total del pedido es invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Error al realizar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        public void crearFacturaPdf(string path)
        {
            // Crear factura en PDF
            DateTime fechaActual = DateTime.Now;

            string nombreFactura = "faktura_" + fechaActual.ToString("yyyyMMdd_HHmmss") + ".pdf"; 
            var exportarPDF = System.IO.Path.Combine(path, nombreFactura);

            // Crear el archivo PDF
            using (var writer = new PdfWriter(exportarPDF))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    // Crear el documento con márgenes
                    var doc = new iText.Layout.Document(pdf, iText.Kernel.Geom.PageSize.A4);
                    doc.SetMargins(90, 36, 36, 36);

                    //Cargar logo
                    string basePath = @"C:\GOIERRI\archivos_clase\erronka\c#_app\2mg3_erronka_4TALDEA_C-_app";
                    string logoRelativePath = @"restaurantLogo\restauranLogo.png";
                    string logoPath = System.IO.Path.Combine(basePath, logoRelativePath);

                    ImageData imagenLogo = ImageDataFactory.Create(logoPath);

                    if(!File.Exists(logoPath))
                    {
                        MessageBox.Show("No se ha encontrado el logo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var image = new iText.Layout.Element.Image(imagenLogo)

                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFixedPosition(1, 10, 700);

                    //Agregar la imagen al documento
                    doc.Add(image);
                    Paragraph encabezado = new Paragraph("");
                    encabezado.Add(image);
                    doc.Add(encabezado);

                    // Datos del restaurante
                    string nombreRestaurante = "SAWORE";
                    string direccionRestaurante = "Calle Falsa 123";
                    string ciudadRestaurante = "Ordizia";

                    // Añadir datos del restaurante
                    PdfFont bolfFont = PdfFontFactory.CreateFont();
                    iText.Kernel.Colors.Color azulLogo = new DeviceRgb(52, 90, 123);
                    iText.Kernel.Colors.Color negro = new DeviceRgb(0, 0, 0);

                    Paragraph parrafo0 = new Paragraph("Cotización de Producto")
                        .SetFontSize(32)
                        .SetMargins(0,0,0,0)
                        .SetPageNumber(1)
                        .SetFontColor(azulLogo)
                        .SetFont(bolfFont)
                        .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                        .SetTextAlignment(TextAlignment.CENTER);

                    doc.Add(parrafo0);

                    //FOLIO

                    Paragraph folio = new Paragraph("");
                    folio.Add("FACTURA");

                    folio.SetFixedPosition(300, 685, 300);
                    folio.SetPageNumber(1);
                    folio.SetFont(bolfFont);
                    folio.SetTextAlignment(TextAlignment.CENTER);
                    folio.SetFontSize(18);
                    folio.SetFontColor(azulLogo);
                    doc.Add(folio);


                    Paragraph parrafo1 = new Paragraph("FECHA DE CREACION: " + DateTime.Now + "\n").SetFontSize(12);
                        if (eskaeraGlobal.EskaeraDatua.ContainsKey("edariIzenakLista"))
                        {
                                var Bebidas = (List<object[]>)eskaeraGlobal.EskaeraDatua["edariIzenakLista"];

                            foreach (var item in Bebidas)
                            {
                                string nombreBebida = (string)item[0];
                                double precio = (double)item[1];
                                int cantidad = (int)item[2];
                                double subtotal = precio * cantidad;

                                doc.Add(new Paragraph($"- {nombreBebida} x{cantidad} - {subtotal:C}")
                                    .SetFontSize(12));
                            }
                        }
                        else
                        {
                            doc.Add(new Paragraph("No se han encontrado bebidas")
                                .SetFontSize(12));
                        }

                        doc.Close();


                    // Añadir contenido al documento
                    /*doc.Add(new Paragraph("Factura de la mesa: " + eskaeraGlobal.EskaeraDatua["idMesa"]));
                    doc.Add(new Paragraph("Fecha: " + fechaActual.ToString("dd/MM/yyyy HH:mm")));
                    doc.Add(new Paragraph("Platos: "));
                    doc.Add(new Paragraph("Bebidas: "));
                    doc.Add(new Paragraph("Total: " + eskaeraGlobal.EskaeraDatua["totala"]));

                    // Cerrar el documento
                    doc.Close();*/
                }
            }
        }

    }
}
