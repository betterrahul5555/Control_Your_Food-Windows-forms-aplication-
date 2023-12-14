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
using Control_Your_Food.FormsFolder;
using CYFLibrary;
using CYFLibrary.Classes;

namespace Control_Your_Food
{
    public struct sdataZuzycia
    {
      public string nazwa { get; set; }
      public int iloscDni { get; set; }
        
      public  sdataZuzycia(string nazwa_,int iloscdni_)
        {
            nazwa = nazwa_;
            iloscDni = iloscdni_;

        }
    }
    public partial class AddProdukt : Form
    {
        DateTime dataDzis;
        List<Product> listaProduktow = new List<Product>();
        List<string> IloscWLista;//= new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach" };
        List<ZuzycieJakieClass> ZuzycieJakieLisa = new List<ZuzycieJakieClass>();
        List<sdataZuzycia> listaDatZuzycia = new List<sdataZuzycia>();
        List<ProduktBazowy> listaProduktowBazowych = new List<ProduktBazowy>();
        ZuzycieJakieClass dzienne = new ZuzycieJakieClass("Dzienne", 1);
        ZuzycieJakieClass tygodniowe = new ZuzycieJakieClass("Tygodniowe", 7);
        ZuzycieJakieClass miesieczne = new ZuzycieJakieClass("Miesieczne", 30);
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();
    List<string> ListaWagi = new List<string>() { "Gramach", "Dekagramach", "Kilogramach" };
        public AddProdukt()
        {
            InitializeComponent();

            ZuzycieJakieLisa.Add(dzienne);
            ZuzycieJakieLisa.Add(tygodniowe);
            ZuzycieJakieLisa.Add(miesieczne);
            IloscWLista = new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach" };
            listaDatZuzycia.Add(new sdataZuzycia("dziś", 0));
            listaDatZuzycia.Add(new sdataZuzycia("jutro", 1));
            listaDatZuzycia.Add(new sdataZuzycia("pojutrze", 2));
            listaDatZuzycia.Add(new sdataZuzycia("za 3 dni", 3));
            listaDatZuzycia.Add(new sdataZuzycia("za 4 dni", 4));
            listaDatZuzycia.Add(new sdataZuzycia("za 5 dni", 5));
            listaDatZuzycia.Add(new sdataZuzycia("za 6 dni", 6));
            listaDatZuzycia.Add(new sdataZuzycia("za tydzień", 7));
            listaDatZuzycia.Add(new sdataZuzycia("za miesiąc", 30));

            
            DateTime date = DateTime.Parse(SqliteDataAccess.DataAccess.LoadLastDate().First().data.ToString());

            DataWaznosciPicker.Value = new DateTime(date.Year, date.Month, date.Day);
            dataDzis = new DateTime(date.Year, date.Month, date.Day);
            LoadProductList();

        }
        private void LoadProductList()
        {
            listaProduktow = SqliteDataAccess.DataAccess.LoadProduct();
            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
            listaProduktowBazowych = SqliteDataAccess.DataAccess.LoadProduktBazowy();
            
            
            WireUpProductList();
        }
        private void WireUpProductList()
        {



            try
            {

              //  cbIloscW.DataSource = null;
                cbIloscW.DataSource = IloscWLista;
                cbIloscW.SelectedItem = "Sztukach";
                JakieZuzyciecomboBox.DataSource = null;
                JakieZuzyciecomboBox.DataSource = ZuzycieJakieLisa;
                JakieZuzyciecomboBox.DisplayMember = "nazwa";
                cbKategoria.DataSource = null;
                cbKategoria.DataSource = listaKategorii;
                cbKategoria.DisplayMember = "nazwaKategorii";
                cbKategoria.ValueMember = "kategoriaID";

                cbDataWażności.DataSource = null;
                cbDataWażności.DataSource = listaDatZuzycia;
                cbDataWażności.DisplayMember = "nazwa";
                cbDataWażności.ValueMember = "iloscDni";
                //cbCzyProduktJednorazowy.Checked = false;
                //CzyZuzycieCzasoweCheckBox.Checked = false;
             
            }
            catch (Exception ex)
            {
             MessageBox.Show(ex.Message);
            }

        }




        private void OdswiezButton_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }
        bool sprawdzCzyZuzycieiSztukaNieJEstPoPrzecinku()
        {
            if (cbZuzycieW.Text == "Sztukach")
                if (CountDecimalPlaces(numericUpDownIloscZuzycia.Value) == 0)
                {
                    return true;
                }
                else return false;
            else
            {
                return true;
            }
           
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
        public void SprawdzCzyJestTakiProdukt(Product p)
        {
           
            
            
           
                try
                {


                if (p.czyJednorazowy == "Nie")
                {
                    listaProduktow.Add(p);
                    System.TimeSpan diff2 = DataWaznosciPicker.Value - dataDzis;
                    SqliteDataAccess.DataAccess.SaveProduct(p);
                    tbNazwaProduktu.Text = "";

                    ProduktBazowy pb = new ProduktBazowy();
                    pb.nazwaB = p.nazwa;
                    pb.kategoriaID = p.kategoriaID;
                    pb.minIloscB = p.minIlosc;
                    pb.zuzycieWB = p.zuzycieW;
                    pb.dniWaznosciB = Int32.Parse(diff2.TotalDays.ToString());
                    pb.iloscB = p.ilosc;
                    pb.iloscZuzyciaB = p.iloscZuzycia;
                    pb.jakieZuzycieB = p.jakieZuzycie;
                    pb.iloscWB = p.iloscW;

                       
                    SqliteDataAccess.DataAccess.SaveProductB(pb);
                    MessageBox.Show("Udało się dodać produkt o nazwie: " + p.nazwa);
                }
                else {
                    listaProduktow.Add(p);
                    SqliteDataAccess.DataAccess.SaveProduct(p);
                    MessageBox.Show("Udało się dodać produkt o nazwie: " + p.nazwa); 
                }
                  
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
       
    
         
           

        }
        bool check()
        {
            try
            {
                if (listaProduktowBazowych.Exists(l => l.nazwaB == tbNazwaProduktu.Text && l.kategoriaID == Int32.Parse(cbKategoria.SelectedValue.ToString())))
                {

                    MessageBox.Show("Produkt z taką nazwą i kategorią już istnej. Skorzystaj z opcji dostawa!");
                    return false;

                }
                if (tbNazwaProduktu.Text == "")
                {
                    MessageBox.Show("Uzupełnij Dane");
                    return false;
                }
                if (CzyZuzycieCzasoweCheckBox.CheckState == CheckState.Checked && numericUpDownIloscZuzycia.Value == 0)
                {
                    MessageBox.Show("Podaj wartośc zużycia czasowego!");
                    return false;
                }
                if (sprawdzCzyZuzycieiSztukaNieJEstPoPrzecinku() == false)
                {
                    MessageBox.Show("Zużycie czasowe musi być podane w liczbie całkowitej(Po przecinku same zera). ");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        private void ZatwiedzProdukt_Click(object sender, EventArgs e)
      {
           

           if (check())
            { 

                
               
                
                    Product p = new Product();
                    p.nazwa = tbNazwaProduktu.Text;
                    p.kategoriaID = Int16.Parse(cbKategoria.SelectedValue.ToString());
                    p.ilosc = Double.Parse(numericUpDownIlosc.Value.ToString());

                    p.iloscW = cbIloscW.Text;
                    p.dataDodania = DateTime.Now.ToShortDateString();
                    p.dataWaznosci = DataWaznosciPicker.Value.ToShortDateString();
                    p.minIlosc = Double.Parse(minValuePicker.Value.ToString());
                    p.czyJednorazowy = "Nie";

                    if (cbCzyProduktJednorazowy.Checked == true)
                    {
                        p.czyJednorazowy = "Tak";
                    }



                if (CzyZuzycieCzasoweCheckBox.Checked == true)
                {


                    p.jakieZuzycie = JakieZuzyciecomboBox.Text;
                    p.iloscZuzycia = Double.Parse(numericUpDownIloscZuzycia.Value.ToString());
                    p.zuzycieW = cbZuzycieW.Text;

                    SprawdzCzyJestTakiProdukt(p);
                    LoadProductList();
                    var mainForm = Application.OpenForms.OfType<MenuF>().Single();
                    mainForm.LoadGrid();
                }
                else
                {
                    p.jakieZuzycie = "Brak";
                    p.iloscZuzycia = 0;
                    p.zuzycieW = "Brak";

                    SprawdzCzyJestTakiProdukt(p);
                    LoadProductList();
                    var mainForm = Application.OpenForms.OfType<MenuF>().Single();
                    mainForm.LoadGrid();
                

                    //   MenuF.ActiveForm.Load(true);

                }
            }
        }

     

     

        private void czyProduktWaznyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCzyProduktJednorazowy.Checked == false)
            {
                minValuePicker.Visible = true;
                WprowadzWartoscMinLabel.Visible = true;
            }
            else
            {
                minValuePicker.Visible = false;
                WprowadzWartoscMinLabel.Visible = false;
                minValuePicker.Value = 0;
            }
        }
      
   

        private void CzyZuzycieCzasoweCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            JakieZuzyciecomboBox.Text = "Dzienne";
            if (CzyZuzycieCzasoweCheckBox.Checked == true)
            {
                Zuzycie.Visible = true;
                IloscZuzyciaLabel.Visible = true;
                JakieZuzyciecomboBox.Visible = true;
                numericUpDownIloscZuzycia.Visible = true;
                cbZuzycieW.Visible = true;
                labelW.Visible = true;
             

            }

            if (CzyZuzycieCzasoweCheckBox.Checked == false)
            {
                Zuzycie.Visible = false;
                IloscZuzyciaLabel.Visible = false;
                JakieZuzyciecomboBox.Visible = false;
                numericUpDownIloscZuzycia.Visible = false;
                cbZuzycieW.Visible = false;
                labelW.Visible = false;


            }





        }

   
        void poprawCBIlosc()
        {
            if (cbIloscW.Text.ToString() == "Sztukach")
            {

                IloscZuzyciaLabel.Text = "";
                IloscZuzyciaLabel.Text = "Ilość zużycia";
                cbZuzycieW.Items.Clear();
                cbZuzycieW.Items.Add("Sztukach");
                cbZuzycieW.Text = "Sztukach";
            }
            if ((cbIloscW.Text == "Gramach" || cbIloscW.Text == "Dekagramach" || cbIloscW.Text == "Kilogramach"))
            {

                IloscZuzyciaLabel.Text = "";
                IloscZuzyciaLabel.Text = "Ilość zużycia";
                cbZuzycieW.Items.Clear();
                cbZuzycieW.Items.Add("Gramach");
                cbZuzycieW.Items.Add("Dekagramach");
                cbZuzycieW.Items.Add("Kilogramach");
                cbZuzycieW.Text = cbIloscW.Text;


            }
            WprowadzWartoscMinLabel.Text = "Wprowadź wartość minimalną produktu  \n (gdy ilość produktu będzie mniejsza lub równa tej wartości, \nprodukt znajdzie się na liście zakupów)\n Przedstawiona w " + cbIloscW.Text.ToUpper();
        }
        private void IloscWComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            poprawCBIlosc();
        }

      

     
        private void cbDokladnaData_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDokladnaData.Checked == false)
            {
                DataWaznosciPicker.Visible = false;

            }
            if(cbDokladnaData.Checked == true)
            {
                DataWaznosciPicker.Visible = true;
            }

        }
     
        private void cbDataWażności_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            try
            {
                DataWaznosciPicker.Value = new DateTime(dataDzis.Year, dataDzis.Month, dataDzis.Day);
                DataWaznosciPicker.Value = DataWaznosciPicker.Value.AddDays(Int16.Parse(cbDataWażności.SelectedValue.ToString()));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            AddCategory add = new AddCategory();
            add.Show();
        }

       
        private void CzyZuzycieCzasoweCheckBox_MouseEnter(object sender, EventArgs e)
        {
CzyZuzycieCzasoweCheckBox.Text= "Czy chcesz dodać zużycie czasowe?\nJeśli nie zaznaczysz tej opcji, ilość produktu\n nie zmniejszy się bez twojej ingerencji.";
        }

        private void CzyZuzycieCzasoweCheckBox_MouseLeave(object sender, EventArgs e)
        {
            CzyZuzycieCzasoweCheckBox.Text = " Czy chcesz dodać zużycie czasowe ?";
        }

      
     
        private void cbKategoria_Click(object sender, EventArgs e)
        {
            
            LoadProductList();
            WireUpProductList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
