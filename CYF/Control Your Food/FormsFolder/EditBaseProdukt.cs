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
    public partial class EditBaseProdukt : Form
    {
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();
        ZuzycieJakieClass dzienne = new ZuzycieJakieClass("Dzienne", 1);
        ZuzycieJakieClass tygodniowe = new ZuzycieJakieClass("Tygodniowe", 7);
        ZuzycieJakieClass miesieczne = new ZuzycieJakieClass("Miesieczne", 30);
        ZuzycieJakieClass brak = new ZuzycieJakieClass("Brak", 0);
        List<string> ListaIlośćZuzycia = new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach", "Brak" };
        List<string> ListaIloscW = new List<string>() { "Sztukach", "Gramach", "Dekagramach", "Kilogramach" };
        List<string> ListaZuzyciaSztuki = new List<string>() { "Sztukach", "Brak" };
        List<string> ListaIloscWSztuki = new List<string>() { "Sztukach"};
        List<string> ListaZUzyciaKG = new List<string>() { "Gramach", "Dekagramach", "Kilogramach", "Brak" };
        List<string> ListaIloscKG = new List<string>() { "Gramach", "Dekagramach", "Kilogramach" };
        List<ZuzycieJakieClass> ZuzycieJakieLisa = new List<ZuzycieJakieClass>();
        List<DostawaClass> listaDostaw = new List<DostawaClass>();
        
        bool czyPoprawneDane;
        ProduktBazowy pb;
        public EditBaseProdukt()
        {
            InitializeComponent();
        }



        public EditBaseProdukt(int id)
        {
            InitializeComponent();
            pb = SqliteDataAccess.DataAccess.GetProduktByIDB(id);
            ZuzycieJakieLisa.Add(dzienne);
            ZuzycieJakieLisa.Add(tygodniowe);
            ZuzycieJakieLisa.Add(miesieczne);
            ZuzycieJakieLisa.Add(brak);
      
            cbIlosc.DataSource = ListaIloscKG;
            cbJakieZuzycie.DataSource = ZuzycieJakieLisa;
            cbJakieZuzycie.DisplayMember = "nazwa";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {



        }

        private void EditBaseProdukt_Load(object sender, EventArgs e)
        {
            
            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
            wripeUp();
            labelMInIlosc.Text = "Wprowadź wartość minimalną produktu  \n (gdy ilość produktu będzie mniejsza lub równa tej wartości, \nprodukt znajdzie się na liście zakupów)\n Przedstawiona w " + cbIlosc.Text.ToUpper();

        }
        string zamiana(int id)
        {
           return listaKategorii.Where(p => p.kategoriaID == id).FirstOrDefault().nazwaKategorii.ToString(); 
           
        }
        void wripeUp()
        {
            try
            {
                cbKategoria.DataSource = null;
                cbKategoria.DataSource = SqliteDataAccess.DataAccess.LoadCategory();
                cbKategoria.DisplayMember = "nazwaKategorii";
                cbKategoria.ValueMember = "kategoriaID";




                cbZuzycieW.DataSource = ListaZUzyciaKG;

                tbNazwa.Text = pb.nazwaB;
                cbKategoria.Text = zamiana(pb.kategoriaID);

                cbIlosc.SelectedItem = pb.iloscWB;
                if (pb.iloscWB == "Sztukach")
                {
                    cbIlosc.DataSource = null;
                    cbIlosc.DataSource = ListaIloscWSztuki;
                    cbIlosc.Text = pb.iloscWB;
                    cbZuzycieW.DataSource = ListaZuzyciaSztuki;
                  
                }
                cbZuzycieW.Text = pb.zuzycieWB;
                numericUpDownZuzycieCzasowe.Value = Decimal.Parse(pb.iloscZuzyciaB.ToString());
            //    numericUpDownZuzycieCzasowe.DecimalPlaces = CountDecimalPlaces(Decimal.Parse(pb.iloscZuzyciaB.ToString()));
                numMinMinimalnaIlosc.Value = Decimal.Parse(pb.minIloscB.ToString());
             //   numMinMinimalnaIlosc.DecimalPlaces = CountDecimalPlaces(Decimal.Parse(pb.minIloscB.ToString()));
                numericUpDownIleDni.Value = Decimal.Parse(pb.dniWaznosciB.ToString());
                nIlosc.Value = Decimal.Parse(pb.iloscB.ToString());
          //      nIlosc.DecimalPlaces= CountDecimalPlaces(Decimal.Parse(pb.iloscB.ToString()));
                cbJakieZuzycie.Text = pb.jakieZuzycieB;

                labelMInIlosc.Text = "Wprowadź wartość minimalną produktu  \n (gdy ilość produktu będzie mniejsza lub równa tej wartości, \nprodukt znajdzie się na liście zakupów)\n Przedstawiona w " + cbIlosc.Text.ToUpper();

            }
            catch
            {

            }
        }
        public static int CountDecimalPlaces(decimal dec)
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
        private void cbIloscW_SelectedIndexChanged(object sender, EventArgs e)
        {
            poprawcbilosc();
        }
        void poprawcbilosc()
        {
            if (cbIlosc.Text.ToString() == "Sztukach")
            {

                cbZuzycieW.DataSource = null;
                cbZuzycieW.DataSource = ListaZuzyciaSztuki;
                if (cbJakieZuzycie.Text == "Brak") cbZuzycieW.Text = "Brak";



            }
            if ((cbIlosc.Text == "Gramach" || cbIlosc.Text == "Dekagramach" || cbIlosc.Text == "Kilogramach"))
            {



                cbZuzycieW.DataSource = null;
                cbZuzycieW.DataSource = ListaZUzyciaKG;
                if (cbJakieZuzycie.Text == "Brak") cbZuzycieW.Text = "Brak";


            }
            labelMInIlosc.Text = "Wprowadź wartość minimalną produktu  \n (gdy ilość produktu będzie mniejsza lub równa tej wartości, \nprodukt znajdzie się na liście zakupów)\n Przedstawiona w " + cbIlosc.Text.ToUpper();
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
            if (cbJakieZuzycie.Text != "Brak" && cbZuzycieW.Text == "Brak")
            {
                return false;
            }
            if (cbZuzycieW.Text == "Sztukach"&& CountDecimalPlaces(numericUpDownZuzycieCzasowe.Value)>0) return false;
            if (cbIlosc.Text == "Sztukach" && cbZuzycieW.Text == "Gramach") return false;
            if (cbIlosc.Text == "Sztukach" && cbZuzycieW.Text == "Kilogramach") return false;
            if (cbIlosc.Text == "Sztukach" && cbZuzycieW.Text == "Dekagramach") return false;
            if (cbIlosc.Text == "Kilogramach" || cbIlosc.Text == "Dekagramach" || cbIlosc.Text == "Gramach")
            {
                if (cbZuzycieW.Text == "Gramach" || cbZuzycieW.Text == "Kilogramach" || cbZuzycieW.Text == "Dekagramach"||cbZuzycieW.Text == "Brak")
                    return true;
                else { return false; }
            }

            else { return true; }
        }
        private void bZatwierdz_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBrak())
                {

                    string query = string.Format("UPDATE ProduktBazowy set nazwaB='{0}', " +
                        "kategoriaID='{1}', iloscB='{2}', iloscWB='{3}', minIloscB='{4}'" +
                          ", dniWaznosciB='{5}',zuzycieWB='{6}',iloscZuzyciaB='{7}',jakieZuzycieB='{8}' where produktBID={9}",
                          tbNazwa.Text,
                          Int32.Parse(cbKategoria.SelectedValue.ToString()), nIlosc.Value.ToString().Replace(",", "."),
                          cbIlosc.Text,
                          numMinMinimalnaIlosc.Value.ToString().Replace(",", "."),
                          numericUpDownIleDni.Value.ToString().Replace(",", "."),
                          cbZuzycieW.Text,
                          numericUpDownZuzycieCzasowe.Value.ToString().Replace(",", "."),
                      cbJakieZuzycie.Text , pb.produktBID

                          );
                    SqliteDataAccess.DataAccess.wykonajPolecenie(query);
                    var mainForm = Application.OpenForms.OfType<Delivery>().Single();

                    mainForm.LoadGird1();
                    mainForm.LoadGird2();
                    MessageBox.Show("Udało się zmienić szkielet produktu: " + tbNazwa.Text);

                    
                }
                else
                {
                    MessageBox.Show("Popraw dane!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool sprawdźCzNalezyDoDostawyy(int id)
        {
            listaDostaw = SqliteDataAccess.DataAccess.LoadDostawaList();
            foreach (var item in listaDostaw)
            {
                try
                {
                    if (item.baza.Contains(id.ToString()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    
                    return false;
                }
            }
            return true;
        }
        

        
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string m = "Czy na pewno chcesz usunąć schemat produktu "+ tbNazwa.Text + " ?" +" Uwaga: Produkt, nie będzie wyświetlany w liście zakupów, jeśli taki jest teraz w systemie." ;
                if (MessageBox.Show(m, "Usuwanie produktu", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (sprawdźCzNalezyDoDostawyy(pb.produktBID))
                    {
                        SqliteDataAccess.DataAccess.DeleteProductB(pb.produktBID);
                        if (MessageBox.Show("Schemat produktu został usunięty", "Usuwanie produktu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        {
                            this.Close();

                        }
                        var mainForm = Application.OpenForms.OfType<Delivery>().Single();
                        mainForm.LoadGird1();
                    }
                    else
                    {
                        MessageBox.Show("Nie możesz usunąć tego schematu. Schemat znajduje się w conajmnniej jednej zapisanej dostawie");
                    }
                }
                
            }
            catch(Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbIlosc_SelectedIndexChanged(object sender, EventArgs e)
        {
            poprawcbilosc();
        }
        string odmianaProduktow(int ilosc)
        {
            if (ilosc == 1)
            {
                return "dniu.";
            }
           
            else
            {
                return "dniach.";
            }
        }
        private void numericUpDownIleDni_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                labelDniach.Text = odmianaProduktow(Int32.Parse(numericUpDownIleDni.Value.ToString()));
            }
            catch
            {

            }
        }

        private void nIlosc_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
