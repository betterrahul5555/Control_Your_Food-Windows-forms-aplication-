using Control_Your_Food.Classes;
using CYFLibrary.Classes;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CYFLibrary
{
    public class SqliteDataAccess
    {
        public static SqliteDataAccess DataAccess { get;private set; } = new SqliteDataAccess();

        private SqliteDataAccess() {}

        public List<Product> productsOld = new List<Product>();
        public List<Product> productsNew = new List<Product>();
        public List<EntryDate> ListaDat = new List<EntryDate>();
  
        public  List<Product> LoadProduct()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Product>("select * from Produkt", new DynamicParameters());
                return output.ToList();
            }

        }
        public  List<Product> LoadProductID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Product>("select * from Produkt where produktID=", new DynamicParameters());
                return output.ToList();
            }

        }
        public  List<ProduktBazowy> LoadProduktBazowy()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProduktBazowy>("select * from ProduktBazowy", new DynamicParameters());
                return output.ToList();
            }

        }
       
        public  List<KategoriaProduktu> LoadCategory()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<KategoriaProduktu>("select * from KategoriaProduktu", new DynamicParameters());
                return output.ToList();
            }

        } 
        public  List<WartosciMin> LoadWartosc()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<WartosciMin>("select * from WartosciMin", new DynamicParameters());
                return output.ToList();
            }

        }
        public  List<EntryDate> LoadDateWejscia()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EntryDate>("select * from DatyWejscia", new DynamicParameters());
                return output.ToList();
            }

        }
        public  List<EntryDate> LoadLastDate()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<EntryDate>("SELECT data FROM DatyWejscia ORDER BY dataID DESC LIMIT 1", new DynamicParameters());
                return output.ToList(); ;
            }

        }
        public  void SaveEntryDate(EntryDate data)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into DatyWejscia(data) values ( @data)", data);
            }

        }
        public  void SaveCategory(KategoriaProduktu k)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into KategoriaProduktu(nazwaKategorii) values ( @nazwaKategorii)", k);
            }

        }
        public  List<Product> LoadLimits()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Product>("select * from Limity", new DynamicParameters());
                return output.ToList();
            }

        }

       
        public  List<DostawaClass> LoadDostawaList()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<DostawaClass>("select * from Dostawa", new DynamicParameters());
                return output.ToList();
            }
        }
        public  void SaveDostawa(DostawaClass d)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                cnn.Execute("insert into Dostawa(nazwa, baza) values (@nazwa, @baza)", d);

            }
        }
        public  void SaveProduct(Product product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

              cnn.Execute("insert into Produkt(nazwa, kategoriaID, ilosc, iloscW, dataDodania, dataWaznosci, minIlosc, jakieZuzycie, iloscZuzycia,zuzycieW, czyJednorazowy) values (@nazwa, @kategoriaID, @ilosc, @iloscW, @dataDodania, @dataWaznosci, @minIlosc,@jakieZuzycie, @iloscZuzycia, @zuzycieW, @czyJednorazowy)", product);

            }
        }
        public  void SaveProductB(ProduktBazowy product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
            //    cnn.Execute("insert into ProduktBazowy(nazwaB, kategoriaB, minIloscB,dniWaznosciB) values (@nazwaB, @kategoriaB, @minIloscB,@dniWaznosciB)", product);

              cnn.Execute("insert into ProduktBazowy(nazwaB, kategoriaID, iloscB, iloscWB, minIloscB, dniWaznosciB, zuzycieWB, iloscZuzyciaB, jakieZuzycieB) values (@nazwaB, @kategoriaID, @iloscB,@iloscWB, @minIloscB, @dniWaznosciB,@zuzycieWB, @iloscZuzyciaB, @jakieZuzycieB)", product);
                

            }
        }
        public  void wykonajPolecenie( string m)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(m);

            }
        }
        public void EditCategory(string value,int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = string.Format("UPDATE KategoriaProduktu set nazwaKategorii ='{0}' where kategoriaID={1}", value, id);

                cnn.Execute(query);

            }
        }
        public void EditDostawa(string value, int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = string.Format("UPDATE Dostawa set baza ='{0}' where dostawaID={1}", value, id);

                cnn.Execute(query);

            }
        }
        public  void EditWartisci(string value,string nazwa)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = string.Format("UPDATE WartosciMin set Ilosc ={0} where Nazwa='{1}'",value,nazwa);

                cnn.Execute(query);

            }
        }
        public  void DeleteProduct(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string q = "Delete from Produkt where produktID="+id;
                cnn.Execute(q);

            }
        }
        public  void DeleteProductB(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string q = "Delete from ProduktBazowy where produktBID=" + id;
                cnn.Execute(q);

            }
        }
        public void DeleteCategory(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string q = "Delete from KategoriaProduktu where kategoriaID=" + id;
                cnn.Execute(q);

            }
        }
        public  void DeleteDostawaWithName(string n)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string q = "Delete from Dostawa where nazwa='" + n+"'";
                cnn.Execute(q);

            }
        }
        public  void DeleteDostawaWithID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string q = "Delete from Dostawa where dostawaID=" + id;
                cnn.Execute(q);

            }
        }
        public  void EditProduct(string m)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(m);

            }
        }

        public  Product GetProduktByID(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string m = "select * from Produkt where produktID=" + id;
                var output = cnn.Query<Product>(m, new DynamicParameters());
                return output.First();
            }

        }
        public  ProduktBazowy GetProduktByIDB(int id)
        {

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                ProduktBazowy pb = new ProduktBazowy() ;
                try
                {
                    string m = "select * from ProduktBazowy where produktBID=" + id;
                    var output = cnn.Query<ProduktBazowy>(m, new DynamicParameters());
                    return output.First();
                }
                catch (Exception ex)
                {
                    return pb;
                }


            }
        }
        private  string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
     
        string dbPath = @"Data Source=.\Database.db";

        public  DataTable ExecuteQuery(string query)
        {

            SQLiteConnection con = new SQLiteConnection(dbPath);
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;


        }
    }
}
    

