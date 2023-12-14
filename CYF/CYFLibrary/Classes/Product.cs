using CYFLibrary;
using System;
using System.Data;

namespace Control_Your_Food.Classes
{
    public class Product
    {
        
        public int produktID { get; set; }
        public string nazwa { get; set; }
        public int kategoriaID { get; set; }
        public string iloscW { get; set; }
        public double ilosc { get; set; }
        public string dataDodania { get; set; }
        public string dataWaznosci { get; set; }
        public double minIlosc { get; set; }
        public string jakieZuzycie { get; set; }
        public double iloscZuzycia { get; set; }
        public string zuzycieW { get; set; }
        public string czyJednorazowy { get; set; }
       
        public string NazwaIloscDataW
        {
            get
            {
                return $" { nazwa }  Ilość: {ilosc} w {iloscW} Data Ważności: {dataWaznosci}  ";

            }
        }
        public DataTable GetAllProducts()
        {
            string query = "SELECT *FROM PRODUKT";
            return SqliteDataAccess.DataAccess.ExecuteQuery(query);

        }
        public DataTable GetProduktByID(int id)
        {
            string query = "SELECT * FROM Produkt where produktID=" + id;
            return SqliteDataAccess.DataAccess.ExecuteQuery(query);
        }
        public void Update(
            int id,
            string nazwa,
            int  kategoriaID,
          string ilosc,
            string iloscW
            ,string dataWaznosci,
           string jakieZuzycie,
            string iloscZuzycia,
          string zuzycieW
          , string czyJednorazowy
           , string minIlosc
            )
        {
            try
            {
                string query = string.Format("UPDATE Produkt set nazwa='{0}', kategoriaID={1}, ilosc='{2}', iloscW='{3}', dataWaznosci='{4}'" +
                    ", jakieZuzycie='{5}',iloscZuzycia='{6}',zuzycieW='{7}',czyJednorazowy='{8}',minIlosc={9} WHERE produktID={10}", nazwa, kategoriaID, ilosc
                    , iloscW, dataWaznosci, jakieZuzycie, iloscZuzycia, zuzycieW, czyJednorazowy, minIlosc, id);
                SqliteDataAccess.DataAccess.wykonajPolecenie(query);
            }
            catch
            {

            }
        }
      

    }
}

