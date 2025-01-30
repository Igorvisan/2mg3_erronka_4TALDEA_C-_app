using erronka_2mg3_app.edaria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erronka_2mg3_app.produkto
{
    public class produktua_kudeaketa
    {
        private NHibernate.Cfg.Configuration miConfiguracion;
        private ISessionFactory mySessionFactory;
        private ISession mySession;
    
            public void ListarProductos(DataGridView tablaProductos)
            {
                miConfiguracion = new NHibernate.Cfg.Configuration();
                miConfiguracion.Configure();
                mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    // HQL query to get all products
                    string hqlQuery = "FROM produktua";
                    var queryProduct = mySession.CreateQuery(hqlQuery);

                    var resultados = queryProduct.List<produktua>();

                    var dataTable = new System.Data.DataTable();
                    dataTable.Columns.Add("Id");
                    dataTable.Columns.Add("Izena");
                    dataTable.Columns.Add("Egoera");
                    dataTable.Columns.Add("GutxienezkoKantitatea");
                    dataTable.Columns.Add("OraingoKantitatea");
                    dataTable.Columns.Add("GehienezkoKantitatea");

                    foreach (var item in resultados)
                    {
                        var row = dataTable.NewRow();
                        row["Id"] = item.Id;
                        row["Izena"] = item.Izena;
                        row["Egoera"] = item.Egoera;
                        row["GutxienezkoKantitatea"] = item.GutxienezkoKantitatea;
                        row["OraingoKantitatea"] = item.OraingoKantitatea;
                        row["GehienezkoKantitatea"] = item.GehienezkoKantitatea;

                        dataTable.Rows.Add(row);
                    }

                    tablaProductos.DataSource = dataTable;

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido realizar la operacion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
        }

        public void gehituProduktua(string produktuGehituText, int kantitatea)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    if(string.IsNullOrEmpty(produktuGehituText) || kantitatea == 0)
                    {
                        MessageBox.Show("Debe rellenar ambos campos poara la insercion");
                        return;
                    }

                    var produktuaGehitu = new produktua
                    {
                        Izena = produktuGehituText,
                        Egoera = "perfecto",
                        GutxienezkoKantitatea = 20,
                        OraingoKantitatea = kantitatea,
                        GehienezkoKantitatea = 100
                    };

                    mySession.Save(produktuaGehitu);
                    mySession.Flush();
                    mySession.Clear();
                    transaccion.Commit();

                }
                catch (Exception ex) 
                {
                    transaccion.Rollback();
                    MessageBox.Show($"Ha ocurrido un error al añadir el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void comboBoxProducts(ComboBox listProductos)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    // HQL query to get all products from "platera" and "edaria"
                    string hqlQueryPlatera = "FROM platera pl";
                    string hqlQueryEdaria = "FROM Edaria ed";

                    var queryPlatera = mySession.CreateQuery(hqlQueryPlatera);
                    var queryEdaria = mySession.CreateQuery(hqlQueryEdaria);

                    var resultadosPlatera = queryPlatera.List<platera.platera>();
                    var resultadosEdaria = queryEdaria.List<Edaria>();

                    // Clear existing items
                    listProductos.Items.Clear();

                    // Add items from "platera"
                    foreach (var item in resultadosPlatera)
                    {
                        listProductos.Items.Add(item.Izena);
                    }

                    // Add items from "edaria"
                    foreach (var item in resultadosEdaria)
                    {
                        listProductos.Items.Add(item.Izena);
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

        public void actualizarProducto(string nombreProducto, int kantitatea)
        {
            miConfiguracion = new NHibernate.Cfg.Configuration();
            miConfiguracion.Configure();
            mySessionFactory = miConfiguracion.BuildSessionFactory();

            using (mySession = mySessionFactory.OpenSession())
            using (var transaccion = mySession.BeginTransaction())
            {
                try
                {
                    string seletcHql = "FROM produktua pr WHERE pr.Izena = :izenaParam";

                    var querySelet = mySession.CreateQuery(seletcHql);

                    querySelet.SetParameter("izenaParam", nombreProducto);

                    var resultado = querySelet.UniqueResult<produktua>();

                    if(resultado == null)
                    {
                        MessageBox.Show("No se han encontrado coincidencias de este producto en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int nuevaCantidad = resultado.OraingoKantitatea + kantitatea;
                    if(nuevaCantidad > 100)
                    {
                        MessageBox.Show("Ya has alacanzado la cantidad de productos maxima", "Atention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        nuevaCantidad = 100;
                    }

                    resultado.OraingoKantitatea = nuevaCantidad;
                    mySession.Update(resultado); //Actualiza la cantidad del producto YA registrado anteriormente
                    mySession.Flush();
                    mySession.Clear();
                    transaccion.Commit();

                    MessageBox.Show("Producto actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) 
                {
                    transaccion.Rollback();
                    MessageBox.Show($"No se ha podido actualizar la columna: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
       