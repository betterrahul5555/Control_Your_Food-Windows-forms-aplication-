using Control_Your_Food.Classes;
using CYFLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_Your_Food.FormsFolder
{
    public partial class AddConsume2 : Form
    {
        public AddConsume2()
        {
            InitializeComponent();
        }
        int produktId;
        Product wybranyProdukt = new Product();
        string iloscW;
        List<Product> products = new List<Product>();
        public AddConsume2(int id)
        {
            produktId = id;
            InitializeComponent();
        }
        List<string> IloscWLista = new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach" };

        private void AddConsume2_Load(object sender, EventArgs e)
        {
            try
            { 

                Product product = new Product();
                wybranyProdukt = SqliteDataAccess.DataAccess.GetProduktByID(produktId);
                 DataTable dt = product.GetProduktByID(produktId);
                if (dt.Rows.Count > 0)
                {

                    //WartośćWybranaPicker.Value = Decimal.Parse(dt.Rows[0]["ilosc"].ToString());
                    IloscWComboBox.Text = dt.Rows[0]["iloscW"].ToString();
                    iloscW= dt.Rows[0]["iloscW"].ToString();
                }
                funkcjazmienIloscCombobox();
            }


            catch (Exception ex)
            {

            }
        }
        public double zamianaJednostek()
        {

            if (wybranyProdukt.iloscW == IloscWComboBox.Text)
            {

                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value));
            }
     
            if (wybranyProdukt.iloscW == "Dekagramach" && IloscWComboBox.Text == "Gramach")
            {

                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value)) / 10;
            }
            if (wybranyProdukt.iloscW == "Dekagramach" && IloscWComboBox.Text == "Kilogramach")
            {

                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value)) * 100;
            }
            if (wybranyProdukt.iloscW == "Gramach" && IloscWComboBox.Text == "Kilogramach")
            {

                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value)) * 1000;
            }
            if (wybranyProdukt.iloscW == "Gramach" && IloscWComboBox.Text == "Dekagramach")
            {

                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value)) * 100;
            }
            if (wybranyProdukt.iloscW == "Kilogramach" && IloscWComboBox.Text == "Gramach")
            {
                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value)) / 1000;
            }
            else// (wybranyProdukt.iloscW == "Kilogramach" && IloscComboBox.Text == "Dekagramy")
            {
                return wybranyProdukt.ilosc - (((double)WartośćWybranaPicker.Value)) / 100;
            }


        }
        public void funkcjazmienIloscCombobox()
        {
            try
            {
                IloscWComboBox.DataSource = null;
              
                if (iloscW == "Sztukach")
                {
                    IloscWComboBox.Items.Clear();
                    IloscWComboBox.Items.Add("Sztukach");
                    IloscWComboBox.Text = "Sztukach";
                }
                if (iloscW == "Kilogramach" || iloscW == "Dekagramach" || iloscW == "Gramach")
                {
                    IloscWComboBox.Items.Clear();
                    IloscWComboBox.Items.Add("Gramach");
                    IloscWComboBox.Items.Add("Dekagramach");
                    IloscWComboBox.Items.Add("Kilogramach");
                    IloscWComboBox.Text = iloscW;
                }
            


            }
            catch (Exception ex)
            {

            }
        }
        private void DodajZuzycieButton_Click(object sender, EventArgs e)


        {
            try
            {
                if (WartośćWybranaPicker.Value > 0)
                {
                    if (wybranyProdukt.ilosc > 0)
                    {
                        var mainForm = Application.OpenForms.OfType<MenuF>().Single();
                        double wartosc = zamianaJednostek();
                        if ((wartosc) >= 0)
                        {
                            SqliteDataAccess.DataAccess.wykonajPolecenie("UPDATE Produkt SET ilosc=" + wartosc.ToString().Replace(",", ".") + " WHERE produktID='" + wybranyProdukt.produktID + "'");
                            MessageBox.Show("Udało się!");
                            this.Close();
                            mainForm.LoadGrid();
                        }
                        else
                        {

                            MessageBox.Show("Nie ma tyle tego produktu");
                            //SqliteDataAccess.DataAccess.wykonajPolecenie(String.Format("UPDATE Produkt SET ilosc=" + 0 + " WHERE produktID='" + wybranyProdukt.produktID + "'"));
                            //MessageBox.Show("Udało się! Odśwież strone główną");
                            //mainForm.LeadGrid();
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Podaj wartość zużycia!");
                }
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                    this.Close();

                
               
            
        }
    }
}
