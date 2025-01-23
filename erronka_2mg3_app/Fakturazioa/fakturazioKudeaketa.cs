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
using erronka_2mg3_app.Fakturazioa;
using System.Diagnostics;


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
                    if(!eskaeraGlobal.EskaeraDatua.ContainsKey("plateraIzenakLista"))
                    {
                        eskaeraGlobal.EskaeraDatua.Add("plateraIzenakLista", resultsDetails);
                    }
                    else
                    {
                        eskaeraGlobal.EskaeraDatua["plateraIzenakLista"] = resultsDetails;
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
                    transaccion.Commit();
                    eskaeraGlobal.EskaeraDatua.Add("precioMaximoTotal", total);
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
                    doc.SetMargins(36, 36, 36, 36);

                    // Cargar logo
                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string logoRelativePath = @"..\..\..\restaurantLogo\restauranLogo.png";
                    string logoPath = System.IO.Path.Combine(basePath, logoRelativePath);


                    ImageData imagenLogo = ImageDataFactory.Create(logoPath);

                    if (!File.Exists(logoPath))
                    {
                        MessageBox.Show("No se ha encontrado el logo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var image = new iText.Layout.Element.Image(imagenLogo)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER)
                        .SetWidth(100)//Ancho deseado 
                        .SetHeight(100);//largura deseada

                    // Agregar la imagen al documento
                    doc.Add(image);

                    // Datos del restaurante
                    string nombreRestaurante = "SAWORE";
                    string direccionRestaurante = "Calle Falsa 123";
                    string ciudadRestaurante = "Ordizia";

                    // Añadir datos del restaurante
                    PdfFont boldFont = PdfFontFactory.CreateFont();
                    iText.Kernel.Colors.Color azulLogo = new DeviceRgb(52, 90, 123);

                    Paragraph parrafo0 = new Paragraph("Cotización de Producto")
                        .SetFontSize(32)
                        .SetFontColor(azulLogo)
                        .SetFont(boldFont)
                        .SetTextAlignment(TextAlignment.CENTER);

                    doc.Add(parrafo0);

                    Paragraph folio = new Paragraph("FACTURA")
                        .SetFontSize(18)
                        .SetFontColor(azulLogo)
                        .SetFont(boldFont)
                        .SetTextAlignment(TextAlignment.CENTER);

                    doc.Add(folio);

                    Paragraph restauranteData = new Paragraph()
                        .Add("Nombre: " + nombreRestaurante + "\n")
                        .Add("Dirección: " + direccionRestaurante + "\n")
                        .Add("Ciudad: " + ciudadRestaurante + "\n")
                        .Add("Mesa: " + eskaeraGlobal.EskaeraDatua["idMesa"].ToString() + "\n")
                        .Add("Fecha de creación: " + fechaActual.ToString("dd/MM/yyyy"))
                        .SetTextAlignment(TextAlignment.CENTER);

                    doc.Add(restauranteData);

                    Paragraph edariLista = new Paragraph("BEBIDAS:")
                        .SetFontSize(14)
                        .SetFontColor(azulLogo)
                        .SetFont(boldFont)
                        .SetTextAlignment(TextAlignment.LEFT);

                    doc.Add(edariLista);

                    // Crear tabla para los items de BEBIDAS
                    Table table = new Table(3, true);
                    table.AddHeaderCell("Producto");
                    table.AddHeaderCell("Cantidad");
                    table.AddHeaderCell("Precio");

                    if (eskaeraGlobal.EskaeraDatua.ContainsKey("edariIzenakLista"))
                    {
                        var Bebidas = (List<object[]>)eskaeraGlobal.EskaeraDatua["edariIzenakLista"];

                        foreach (var item in Bebidas)
                        {
                            string nombreBebida = (string)item[0];
                            double precio = (double)(item[1]);
                            int cantidad = (int)(item[2]);

                            table.AddCell(nombreBebida);
                            table.AddCell(cantidad.ToString());
                            table.AddCell(precio.ToString("C")); // Mostrar con dos decimales
                        }
                    }
                    else
                    {
                        table.AddCell("No se han encontrado bebidas");
                    }

                    doc.Add(table);


                    Paragraph platosLista = new Paragraph("PLATOS:")
                        .SetFontSize(14)
                        .SetFontColor(azulLogo)
                        .SetFont(boldFont)
                        .SetTextAlignment(TextAlignment.LEFT);

                    doc.Add(platosLista);

                    // Crear tabla para los items de PLATOS
                    Table table2 = new Table(3, true);
                    table2.AddHeaderCell("Producto");
                    table2.AddHeaderCell("Cantidad");
                    table2.AddHeaderCell("Precio");

                    if (eskaeraGlobal.EskaeraDatua.ContainsKey("plateraIzenakLista"))
                    {
                        var platos = (List<object[]>)eskaeraGlobal.EskaeraDatua["plateraIzenakLista"];

                        foreach (var plato in platos)
                        {
                            string nombrePlato = (string)plato[0];
                            double precio = (double)(plato[1]);
                            int cantidad = (int)(plato[2]);

                            table2.AddCell(nombrePlato);
                            table2.AddCell(cantidad.ToString());
                            table2.AddCell(precio.ToString("C")); // Mostrar con dos decimales
                        }
                    }
                    else
                    {
                        table2.AddCell("No se han encontrado platos");
                    }

                    doc.Add(table2);

                    Paragraph precioTotal = new Paragraph()
                        .Add("TOTAL: " + eskaeraGlobal.EskaeraDatua["precioMaximoTotal"].ToString() + "€")
                        .SetFontSize(32)
                        .SetFontColor(new DeviceRgb(System.Drawing.Color.White))
                        .SetMarginTop(20)
                        .SetFont(boldFont)
                        .SetBackgroundColor(azulLogo)
                        .SetTextAlignment(TextAlignment.RIGHT);

                    doc.Add(precioTotal);

                    doc.Close();
                }
            }
        }

        public void borrarPedidoGeneral()
        {
            borrarPedidoEdaria();
            borrarPedidoPlatera();

            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (var mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    if(eskaeraGlobal.EskaeraDatua == null)
                    {
                        throw new NullReferenceException("eskaeraGlobal o eskaeraGlobal.EskaeraDatua es nulo.");
                    }
                    if(!eskaeraGlobal.EskaeraDatua.ContainsKey("idEskaera"))
                    {
                        MessageBox.Show("No se ha encontrado la id eskaera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int idEskaeraGlobal = (int)eskaeraGlobal.EskaeraDatua["idEskaera"];
                    string hql = "DELETE FROM Eskaera esk WHERE esk.Id = :idParam";
                    var query = mySession.CreateQuery(hql);
                    query.SetParameter("idParam", idEskaeraGlobal);

                    int result = query.ExecuteUpdate();

                    if(result == 0)
                    {
                        throw new Exception("No se encontró ningún registro con el id especificado.");
                    }
                    transaccion.Commit();
                    MessageBox.Show("Linea borrada con éxito", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var firstKey = eskaeraGlobal.EskaeraDatua.Keys.First();
                    var firstValue = eskaeraGlobal.EskaeraDatua[firstKey];
                    eskaeraGlobal.EskaeraDatua.Clear();
                    eskaeraGlobal.EskaeraDatua[firstKey] = firstValue;

                    // Mostrar en un MessageBox para verificar
                    MessageBox.Show($"Key: {firstKey}, Value: {firstValue}", "Verificación de datos");

                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    mySession.Flush();
                    mySession.Clear();
                }
            }
        }

        public void borrarPedidoEdaria()
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

                    if (idEskaeraGlobal == 0)
                    {
                        MessageBox.Show("No se ha encontrado la id de la eskaera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (eskaeraGlobal.EskaeraDatua == null)
                    {
                        throw new NullReferenceException("eskaeraGlobal o eskaeraGlobal.EskaeraDatua es nulo.");
                    }

                    string hqlDeleteEdaria = "DELETE FROM EskaeraEdaria ed WHERE ed.EskaeraId = :idParam";
                    var queryDeleteEdaria = mySession.CreateQuery(hqlDeleteEdaria);

                    queryDeleteEdaria.SetParameter("idParam", idEskaeraGlobal);

                    int resultados = queryDeleteEdaria.ExecuteUpdate();

                    if (resultados == 0)
                    {
                        throw new Exception("No se encontró ningún registro con el id especificado.");
                    }
                    else
                    {
                        transaccion.Commit();
                        MessageBox.Show("Linea borrada con éxito", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void borrarPedidoPlatera()
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

                    if (idEskaeraGlobal == 0)
                    {
                        MessageBox.Show("No se ha encontrado la id de la eskaera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (eskaeraGlobal.EskaeraDatua == null)
                    {
                        throw new NullReferenceException("eskaeraGlobal o eskaeraGlobal.EskaeraDatua es nulo.");
                    }

                    string hqlDeletePlatera = "DELETE FROM plateraEskaria pl WHERE pl.EskaeraId = :idParam";
                    var queryDeletePlatera = mySession.CreateQuery(hqlDeletePlatera);

                    queryDeletePlatera.SetParameter("idParam", idEskaeraGlobal);

                    int resultados = queryDeletePlatera.ExecuteUpdate();

                    if (resultados > 0)
                    {
                        transaccion.Commit();
                        MessageBox.Show("Linea borrada con éxito", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        throw new Exception("No se encontró ningún registro con el id especificado.");
                    }
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

