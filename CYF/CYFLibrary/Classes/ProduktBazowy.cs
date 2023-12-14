using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYFLibrary
{
    public class ProduktBazowy
    {
      
        public int produktBID { get; set; }
        public string nazwaB { get; set; }
        public int kategoriaID { get; set; }
        public double iloscB { get; set; }
        public string iloscWB { get; set; }
        public double minIloscB { get; set; }
        public int dniWaznosciB { get; set; }
        public string zuzycieWB { get; set; }
        public double iloscZuzyciaB { get; set; }
        public string jakieZuzycieB { get; set; }
    
       
        public static DataTable GetProduktByBID(int id)
        {
            string query = "SELECT * FROM ProduktBazowy where produktBID=" + id;
            return SqliteDataAccess.DataAccess.ExecuteQuery(query);
        }
        public DataTable GetAllProductsB()
        {
            string query = "SELECT *FROM PRODUKTBAZOWY";
            return SqliteDataAccess.DataAccess.ExecuteQuery(query);

        }
        public void UpdateB(int id,
          
          string ilosc
            
            )
        {
            string query = string.Format("UPDATE Produkt set ilosc={0} where produktBID={1}"
                , ilosc, id);
            SqliteDataAccess.DataAccess.wykonajPolecenie(query);
        }

    }
}
