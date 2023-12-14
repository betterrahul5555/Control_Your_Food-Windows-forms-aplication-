using Control_Your_Food.Classes;
using CYFLibrary;
using CYFLibrary.Classes;
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
    public partial class EditProdukt : Form
    {

        Product product;
        public int productId;
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();
        ZuzycieJakieClass dzienne = new ZuzycieJakieClass("Dzienne", 1);
        ZuzycieJakieClass tygodniowe = new ZuzycieJakieClass("Tygodniowe", 7);
        ZuzycieJakieClass miesieczne = new ZuzycieJakieClass("Miesieczne", 30);
      
        ZuzycieJakieClass brak = new ZuzycieJakieClass("Brak", 0);
        List<string> ListaIlośćZuzycia= new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach", "Brak" };
        List<string> ListaIloscW=new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach"};
        List<string> ListaZuzyciaSztuki = new List<string>() { "Sztukach", "Brak" };
        List<string> ListaIloscSztuki = new List<string>() { "Sztukach"};

        List<string> ListaZuzycuaKG = new List<string>() {  "Gramach", "Dekagramach", "Kilogramach", "Brak" };
        List<string> ListaIloscKG = new List<string>() { "Gramach", "Dekagramach", "Kilogramach" };
        List<ZuzycieJakieClass> ZuzycieJakieLisa = new List<ZuzycieJakieClass>();
        public EditProdukt()
        {
            InitializeComponent();
        }
        public EditProdukt(int id)
        {

            InitializeComponent();
            productId = id;
         
        }

        private void EditProdukt_Load(object sender, EventArgs e)
        { 
            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
           
            ZuzycieJakieLisa.Add(brak);
            ZuzycieJakieLisa.Add(dzienne);
            ZuzycieJakieLisa.Add(tygodniowe);
            ZuzycieJakieLisa.Add(miesieczne);

            CBILOSCW.DataSource= ListaIloscKG;


            cbJakieZuzycie.DataSource = ZuzycieJakieLisa;
            cbJakieZuzycie.DisplayMember = "nazwa";

        

            cbZuzycieW.DataSource = ListaIlośćZuzycia;
            cbZuzycieW.DisplayMember = "nazwa";
            tbKategoria.DisplayMember = "nazwaKategorii";
            tbKategoria.ValueMember = "kategoriaID";
         tbKategoria.DataSource = listaKategorii;
            labelMinIlosc.Text = "Wprowadź wartość minimalną produktu  \n (gdy ilość produktu będzie mniejsza lub równa tej wartości, \nprodukt znajdzie się na liście zakupów)\n Przedstawiona w " + CBILOSCW.Text.ToUpper();

            doIt();  
        }
        string zamiana(int id)
        {

            return listaKategorii.Where(p => p.kategoriaID == id).FirstOrDefault().nazwaKategorii.ToString();
        }
         static int CountDecimalPlaces(decimal dec)
        {

            int[] bits = Decimal.GetBits(dec);
            ulong lowInt = (uint)bits[0];
            ulong midInt = (uint)bits[1];
            int exponent = (bits[3] & 0x00FF0000) >> 16;
            int result = exponent;
            ulong lowDecimal = lowInt | (midInt << 32);
            while (result > 0 && (lowDecimal % 10) == 0)
            {
                result--;
                lowDecimal /= 10;
            }

            return result;
        }
        void doIt()
        {
            product = new Product();
            DataTable dt = product.GetProduktByID(productId);

            if (dt.Rows.Count > 0)
            {
                productId = Int32.Parse(dt.Rows[0]["produktId"].ToString());
                tbNazwa.Text = dt.Rows[0]["nazwa"].ToString();
                tbKategoria.Text = zamiana(Int32.Parse(dt.Rows[0]["kategoriaID"].ToString()));
                Decimal d= Decimal.Parse(dt.Rows[0]["ilosc"].ToString());
                
                nIlosc.Value = Decimal.Parse(dt.Rows[0]["ilosc"].ToString());
               // nIlosc.DecimalPlaces =CountDecimalPlaces(Decimal.Parse(dt.Rows[0]["ilosc"].ToString()));

                CBILOSCW.Text=dt.Rows[0]["iloscW"].ToString();
                if (dt.Rows[0]["iloscW"].ToString() == "Sztukach")
                {
                    CBILOSCW.DataSource = null;
                    CBILOSCW.DataSource = ListaIloscSztuki;
                }
                
                cbJakieZuzycie.Text = dt.Rows[0]["jakieZuzycie"].ToString();

                numericUpDownZuzycieCzasowe.Value = Decimal.Parse(dt.Rows[0]["iloscZuzycia"].ToString());
               // numericUpDownZuzycieCzasowe.DecimalPlaces= CountDecimalPlaces(Decimal.Parse(dt.Rows[0]["iloscZuzycia"].ToString()));
                cbZuzycieW.Text = dt.Rows[0]["zuzycieW"].ToString();
                numMinMinimalnaIlosc.Value = Decimal.Parse(dt.Rows[0]["minIlosc"].ToString());
               // numMinMinimalnaIlosc.DecimalPlaces = CountDecimalPlaces(Decimal.Parse(dt.Rows[0]["minIlosc"].ToString()));
                if (dt.Rows[0]["czyJednorazowy"].ToString() == "Tak")
                {
                    cbCzyProduktWazny.Checked = true;
                }
                datePickerWaznosci.Value = DateTime.Parse(dt.Rows[0]["dataWaznosci"].ToString());


            }
        }
        void poprawcbilosc()
        {
            if (CBILOSCW.Text.ToString() == "Sztukach")
            {

                cbZuzycieW.DataSource = null;
                cbZuzycieW.DataSource = ListaZuzyciaSztuki;
                if (cbJakieZuzycie.Text == "Brak") cbZuzycieW.Text = "Brak";

            }
            if ((CBILOSCW.Text == "Gramach" || CBILOSCW.Text == "Dekagramach" || CBILOSCW.Text == "Kilogramach"))
            {



                cbZuzycieW.DataSource = null;
                cbZuzycieW.DataSource = ListaZuzycuaKG;
                if (cbJakieZuzycie.Text == "Brak") cbZuzycieW.Text = "Brak";


            }
            labelMinIlosc.Text = "Wprowadź wartość minimalną produktu  \n (gdy ilość produktu będzie mniejsza lub równa tej wartości, \nprodukt znajdzie się na liście zakupów)\n Przedstawiona w " + CBILOSCW.Text.ToUpper();

        }
        bool checkBrak()
        {
            if (cbJakieZuzycie.Text == "Brak" && cbZuzycieW.Text != "Brak")
            {
                return false;
            }
            if (cbJakieZuzycie.Text == "Brak" && cbZuzycieW.Text == "Brak" && numericUpDownZuzycieCzasowe.Value != 0)
            {
                return false;
            }
            if (cbJakieZuzycie.Text != "Brak" && cbZuzycieW.Text != "Brak" && numericUpDownZuzycieCzasowe.Value == 0)
            {
                return false;
            }
            if (cbJakieZuzycie.Text != "Brak" && cbZuzycieW.Text == "Brak")
            {
                return false;
            }
            if (cbZuzycieW.Text == "Sztukach" && CountDecimalPlaces(numericUpDownZuzycieCzasowe.Value) > 0) return false;
            if (CBILOSCW.Text == "Sztukach" && cbZuzycieW.Text == "Gramach") return false;
            if (CBILOSCW.Text == "Sztukach" && cbZuzycieW.Text == "Kilogramach") return false;
            if (CBILOSCW.Text == "Sztukach" && cbZuzycieW.Text == "Dekagramach") return false;
            if (CBILOSCW.Text == "Kilogramach"|| CBILOSCW.Text == "Dekagramach"|| CBILOSCW.Text == "Gramach")
            {
                if (cbZuzycieW.Text == "Gramach" || cbZuzycieW.Text == "Kilogramach" || cbZuzycieW.Text == "Dekagramach"|| cbZuzycieW.Text=="Brak")
                    return true;
                else { return false; }
            }

            else { return true; }
        }
        string zamienNaTakLubNie(bool m)
        {
            if (m == true)
            {
                return "Tak";
            }
            else{
            return "Nie";
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (checkBrak())
            {
                if (tbNazwa.Text != "")
                {
                    try
                    {
                        product.Update(
                        productId,
                        tbNazwa.Text,
                        Int32.Parse(tbKategoria.SelectedValue.ToString())
                        , nIlosc.Value.ToString().Replace(",", ".")
                        , CBILOSCW.Text
                        , datePickerWaznosci.Value.ToShortDateString(),
                        cbJakieZuzycie.Text
                        , numericUpDownZuzycieCzasowe.Value.ToString().Replace(",", "."),
                       cbZuzycieW.Text
                        , zamienNaTakLubNie(cbCzyProduktWazny.Checked)
                       , numMinMinimalnaIlosc.Value.ToString().Replace(",", ".")
                       );
                        if (MessageBox.Show("Udało się zmienić produkt!", "Zmiana produktu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            try
                            {
                                var mainForm = Application.OpenForms.OfType<MenuF>().Single();
                                mainForm.LoadGrid();
                                this.Close();

                            }
                            catch (Exception ex)
                            {
                              //  MessageBox.Show(ex.Message);
                            }
                        }



                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Popraw dane!");
            }
        }

       

       

      

     

      

        private void CBILOSCW_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        poprawcbilosc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
