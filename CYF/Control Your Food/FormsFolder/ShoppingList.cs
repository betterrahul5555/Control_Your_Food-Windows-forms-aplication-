using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Your_Food.Classes;
using CYFLibrary;
using CYFLibrary.Classes;

namespace Control_Your_Food.FormsFolder
{
    public partial class ShoppingList : Form
    {
       
    
        List<ProduktBazowy> Allproductsbazowy = new List<ProduktBazowy>();
        List<ProduktBazowy> SelectedProductsbazowy = new List<ProduktBazowy>();
         List<Product> listaProduktowPoTerminie = new List<Product>();
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();
       
        List<Product> listaMaloProduktow = new List<Product>();
        List<Product> listaDuzoProduktow = new List<Product>();
        List<Product> listaBrakProduktow = new List<Product>();
        ProduktBazowy productBazoowy = new ProduktBazowy();
        List<Product> listaOkazjonanych = new List<Product>();
        double wSztukach;
        double wKlio;
        double wDeko;
        double wGramach;
        public ShoppingList()
        {
            InitializeComponent();
        }
      public ShoppingList(List<Product> productsMalo_, List<Product> productsPo_, List<Product> productsBrak_)
        {
            InitializeComponent();
            listaBrakProduktow.Clear();
            listaProduktowPoTerminie.Clear();
            listaMaloProduktow.Clear();
         
              listaProduktowPoTerminie = productsPo_;
            
            listaBrakProduktow = productsBrak_;
            listaMaloProduktow = productsMalo_;


        }
        string zamiana(int id)
        {

            return listaKategorii.Where(p => p.kategoriaID == id).FirstOrDefault().nazwaKategorii.ToString();
        }
        public static DataTable ToDataTable<T>( IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        double zamienNaOdpowiedni(double wartosc, string JednostkaIlość, string JednostakZużycia)
        {
            if (JednostkaIlość == "Kilogramach")
            {

                if (JednostakZużycia == "Dekagramach") return wartosc / 100;
                if (JednostakZużycia == "Gramach") return wartosc / 1000;
                else
                    return wartosc;
            }
            if (JednostkaIlość == "Dekagramach")
            {
                if (JednostakZużycia == "Kilogramach")
                    return wartosc * 100;

                if (JednostakZużycia == "Gramach") return wartosc * 10;
                else return wartosc;
            }
             if(JednostkaIlość == "Gramach")
            {
                if (JednostakZużycia == "Kilogramach")
                    return wartosc * 1000;
                if (JednostakZużycia == "Dekagramach") return wartosc * 100;
                else return wartosc;

            }
            else { return wartosc; }


        }
        private void ShoppingListView_Load(object sender, EventArgs e)
        {

            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();

            SelectedProductsbazowy.Clear();
           
            listaProduktowPoTerminie.AddRange(listaBrakProduktow);
            listaProduktowPoTerminie.AddRange(listaMaloProduktow);
            Allproductsbazowy = SqliteDataAccess.DataAccess.LoadProduktBazowy();


            //   listaProduktowPoTerminie.Remove(item);
            //        continue;
            //}
            var listaOkazyjnch = listaProduktowPoTerminie.FindAll(p => p.czyJednorazowy == "Tak");
            foreach (var item in listaOkazyjnch)
            {
                listaProduktowPoTerminie.Remove(item);
            }
          
                foreach (var item in listaProduktowPoTerminie)
            {
               
                if (SelectedProductsbazowy.Exists(p => p.nazwaB == item.nazwa && p.kategoriaID ==item.kategoriaID))
                {
                  
                        var k = SelectedProductsbazowy.FindIndex(p => p.nazwaB == item.nazwa && p.kategoriaID == item.kategoriaID);
                  //  if(SelectedProductsbazowy[k].iloscWB=="Kilogramy"||
                        SelectedProductsbazowy[k].iloscB += zamienNaOdpowiedni(item.ilosc, SelectedProductsbazowy[k].iloscWB,item.iloscW );


                        continue;
                    
                  
                }
                else
                {
                    if (Allproductsbazowy.Exists( p => p.nazwaB == item.nazwa && p.kategoriaID == item.kategoriaID ))
                    {
                        var k = Allproductsbazowy.FindLast(p => p.nazwaB == item.nazwa && p.kategoriaID == item.kategoriaID);
                        SelectedProductsbazowy.Add(k);
                    }
                }      
            }

            
            var m = productBazoowy.GetAllProductsB();
            DataTable dataTable = new DataTable();
            m.Rows.Clear();
            var l = ToDataTable(SelectedProductsbazowy);
            l.Columns.Add("Kategoria:");
            for (int i = 0; i < l.Rows.Count; i++)
            {
                DataRow dr = l.Rows[i];

                dr[10] = zamiana(Int32.Parse(dr[2].ToString()));
            }
            dataGridView1.DataSource = l;
           
            dataGridView1.Columns["produktBID"].Visible = false;
            dataGridView1.Columns["jakieZuzycieB"].Visible = false;
            dataGridView1.Columns["iloscZuzyciaB"].Visible = false;
            dataGridView1.Columns["minIloscB"].Visible = false;
            dataGridView1.Columns["kategoriaID"].Visible = false;
            dataGridView1.Columns["zuzycieWB"].Visible = false;
       
           
            dataGridView1.Columns["dniWaznosciB"].Visible = false;

            dataGridView1.Columns["iloscWB"].HeaderText = "Ilość w:";
            dataGridView1.Columns["nazwaB"].HeaderText = "Nazwa:";
            dataGridView1.Columns["kategoriaID"].HeaderText = "KategoriaID:";
            dataGridView1.Columns["iloscB"].HeaderText = "Kup:";
            dataGridView1.Columns["nazwaB"].DisplayIndex = 0;
            dataGridView1.Columns["Kategoria:"].DisplayIndex = 1;
            dataGridView1.Columns["iloscB"].DisplayIndex = 2;
            dataGridView1.Columns["iloscWB"].DisplayIndex = 3;

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 12, style: FontStyle.Bold);


        }

        private void PowrotButton_Click(object sender, EventArgs e)
        {
          
        }
        private void Column_Click(object sender, EventArgs e)
        {

        }

        private void ShoppingList_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void ShoppingListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
