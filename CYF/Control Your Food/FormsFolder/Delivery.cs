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
using WECPOFLogic;

namespace Control_Your_Food.FormsFolder
{
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
        }
        List<ProduktBazowy> listaProduktowBazowych = new List<ProduktBazowy>();
        List<ProduktBazowy> listaProduktowBazowychwybranych;
        List<DostawaClass> listaDostawa;
         ProduktBazowy productB;
         DostawaClass dostawa;
         string dostawaString;
        List<KategoriaProduktu> kategorieAll = new List<KategoriaProduktu>();
       List<KategoriaProduktu> kategorieWybrane = new List<KategoriaProduktu>();
        int productId;
        int productId2;
       List<sdataZuzycia> listaDatZuzycia = new List<sdataZuzycia>();
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();

        private void Delivery_Load(object sender, EventArgs e)
        {
            listaProduktowBazowych = SqliteDataAccess.DataAccess.LoadProduktBazowy();
            listaProduktowBazowychwybranych = new List<ProduktBazowy>();
            
            var k = listaProduktowBazowych.Select(p => p.kategoriaID).ToArray(); ;

            List<int> kategorie = new List<int>();
            for (int i = 0; i < k.Length; i++)
            {
                if (i == 0)
                {
                    kategorie.Add(k[i]);
                    continue;
                }
                if (kategorie.Contains(k[i]) == false)
                {
                    kategorie.Add(k[i]);
                }
            }
            kategorieAll = SqliteDataAccess.DataAccess.LoadCategory();
            for (int i = 0; i < kategorie.Count; i++)
            {
                kategorieWybrane.Add( kategorieAll.Where(p => p.kategoriaID == kategorie[i]).First());
            }
            loadDostaw();
            cbWyborKategorii.DataSource = null;
            cbWyborKategorii.DataSource = kategorieWybrane;
            cbWyborKategorii.DisplayMember = "nazwaKategorii";
            cbWyborKategorii.ValueMember = "kategoriaID";
       //     cbWyborKategorii.SelectedIndex = 0;
            cbDostawa.DataSource = null;
            cbDostawa.DataSource = listaDostawa;
            cbDostawa.DisplayMember = "nazwa";
            cbDostawa.ValueMember = "baza";
        
            gridDostawa.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10, style: FontStyle.Bold);
            gridProdukty.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10, style: FontStyle.Bold);
            listaDatZuzycia.Add(new sdataZuzycia("dziś", 0));
            listaDatZuzycia.Add(new sdataZuzycia("jutro", 1));
            listaDatZuzycia.Add(new sdataZuzycia("pojutrze", 2));
            listaDatZuzycia.Add(new sdataZuzycia("za 3 dni", 3));
            listaDatZuzycia.Add(new sdataZuzycia("za 4 dni", 4));
            listaDatZuzycia.Add(new sdataZuzycia("za 5 dni", 5));
            listaDatZuzycia.Add(new sdataZuzycia("za 6 dni", 6));
            listaDatZuzycia.Add(new sdataZuzycia("za tydzień", 7));
            listaDatZuzycia.Add(new sdataZuzycia("za dwa tygodnie", 14));
            listaDatZuzycia.Add(new sdataZuzycia("za miesiąc", 30));
            //cbListaDniWaznosci.DataSource = null;
            //     cbListaDniWaznosci.DataSource = listaDatZuzycia;
            //cbListaDniWaznosci.DisplayMember = "nazwa";
            //cbListaDniWaznosci.ValueMember = "iloscDni";
            LoadGird1();
            LoadGird2();

        }
        public void loadDostaw()
        {
            listaDostawa = SqliteDataAccess.DataAccess.LoadDostawaList();
            cbDostawa.DataSource = null;
            cbDostawa.DataSource = listaDostawa;
            cbDostawa.DisplayMember = "nazwa";
            cbDostawa.ValueMember = "baza";
        }     
        public void LoadGird1()
        {
            try
            {
                listaProduktowBazowych = SqliteDataAccess.DataAccess.LoadProduktBazowy();
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "";
                bc.Text = "Dodaj";
                bc.Name = "Dodaj";

                bc.FlatStyle = FlatStyle.Flat;
                DataGridViewButtonColumn ba = new DataGridViewButtonColumn();
                ba.HeaderText = "";
                ba.Text = "Edytuj/Usuń";
                ba.Name = "Edytuj/Usuń";

                ba.FlatStyle = FlatStyle.Flat;
                gridProdukty.DataSource = null;
                gridProdukty.Columns.Clear();
                gridProdukty.Columns.Add(bc);
                gridProdukty.Columns.Add(ba);
                bc.UseColumnTextForButtonValue = true;
                ba.UseColumnTextForButtonValue = true;
                gridProdukty.DataSource = listaProduktowBazowych;
                gridProdukty.Columns["produktBID"].Visible = false;
                gridProdukty.Columns["jakieZuzycieB"].Visible = false;
                gridProdukty.Columns["iloscZuzyciaB"].Visible = false;
                gridProdukty.Columns["minIloscB"].Visible = false;
                gridProdukty.Columns["zuzycieWB"].Visible = false;
                gridProdukty.Columns["nazwaB"].HeaderText = "Nazwa:";
                gridProdukty.Columns["kategoriaID"].Visible = false;
                gridProdukty.Columns["iloscB"].HeaderText = "Ilość:";
                gridProdukty.Columns["iloscWB"].HeaderText = "Ilość w:";
                gridProdukty.Columns["dniWaznosciB"].HeaderText = "Po ilu dniach traci wartość";
                int b;
                if (listaProduktowBazowych.Count != 0)
                {
                    bool Kategoriabool = Int32.TryParse(cbWyborKategorii.SelectedValue.ToString(), out b);
                    if (Kategoriabool && listaProduktowBazowych.Where(p => p.kategoriaID == b) != null)
                    {
                        gridProdukty.DataSource = listaProduktowBazowych.Where(p => p.kategoriaID == b).ToList();


                    }
                }
            }
            catch
            {

            }
          
        }
        public static DataTable ToDataTable<T>(IList<T> data)
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
        string zamiana(int id)
        {

            return listaKategorii.Where(p => p.kategoriaID == id).FirstOrDefault().nazwaKategorii.ToString();
        }
        public void LoadGird2()
        {

            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
            DataGridViewButtonColumn dl = new DataGridViewButtonColumn(); 
            dl.HeaderText = "";
            dl.Text = "Usuń";
            dl.Name = "Usuń";
            dl.Width = 50;
            gridDostawa.DataSource = null;
            gridDostawa.Columns.Clear();
  
            dl.FlatStyle = FlatStyle.Flat;
          
            gridDostawa.Columns.Add(dl);
         
            dl.UseColumnTextForButtonValue = true;
            var l = ToDataTable(listaProduktowBazowychwybranych.ToList());
            l.Columns.Add("Kategoria:");
            for (int i = 0; i < l.Rows.Count; i++)
            {
                DataRow dr = l.Rows[i];
Console.WriteLine("id kategorii to"+ Int32.Parse(dr[2].ToString()));
                dr[10] = zamiana(Int32.Parse(dr[2].ToString()));
                
            }
            gridDostawa.DataSource = l;
            gridDostawa.Columns["produktBID"].Visible = false;
            gridDostawa.Columns["jakieZuzycieB"].Visible = false;
            gridDostawa.Columns["iloscZuzyciaB"].Visible = false;
            gridDostawa.Columns["minIloscB"].Visible = false;
            gridDostawa.Columns["zuzycieWB"].Visible = false;
            gridDostawa.Columns["kategoriaID"].Visible = false;
            gridDostawa.Columns["nazwaB"].HeaderText = "Nazwa:";
            gridDostawa.Columns["kategoriaID"].HeaderText = "Kategoria:";
            gridDostawa.Columns["iloscB"].HeaderText = "Ilość:";
            gridDostawa.Columns["iloscWB"].HeaderText = "Ilość w:";
            gridDostawa.Columns["nazwaB"].DisplayIndex = 1;
            gridDostawa.Columns["Kategoria:"].DisplayIndex = 2;

            gridDostawa.Columns["dniWaznosciB"].HeaderText = "Po ilu dniach traci wartość";

        }
      
   

     

        private void gridProdukty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                productId = Int32.Parse(gridProdukty.Rows[e.RowIndex].Cells[2].Value.ToString());
                productB = SqliteDataAccess.DataAccess.GetProduktByIDB(productId);
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {


                 
                    if (listaProduktowBazowychwybranych.Exists(p => p.produktBID == productB.produktBID) == false)
                    {
                        listaProduktowBazowychwybranych.Add(productB);

                        LoadGird2();

                    }
                    else
                    {
                       MessageBox.Show("Ten produkt jest już dodany, możesz zmienić jego właściwości klikając przycisk Edytuj/Usuń ");
                    }

                }
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {

                    if (listaProduktowBazowychwybranych.Exists(p => p.produktBID == productB.produktBID) == false)
                    {

                        EditBaseProdukt editBaseProdukt = new EditBaseProdukt(productId);
                        editBaseProdukt.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuń ten produkt z listy obok, by go zmienić!");

                    }


                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void gridDostawa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // LoadGird2();
            Console.WriteLine(e.RowIndex + " " + e.ColumnIndex);
           
            try
            {


          
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    Console.WriteLine( gridDostawa.Rows[e.RowIndex].Cells[1].Value.ToString() ); 
                    var m = listaProduktowBazowychwybranych.Where(p => p.produktBID == Int32.Parse(gridDostawa.Rows[e.RowIndex].Cells[1].Value.ToString())).First();
                    listaProduktowBazowychwybranych.Remove(m);
                    LoadGird2();
                }
            }
            catch (Exception ex)
            {

            }

            }
        private void bDodajProdukty_Click(object sender, EventArgs e)
        {
            if (listaProduktowBazowychwybranych.Count != 0)
            {
                Product p = new Product();
                try
                {

                    foreach (var item in listaProduktowBazowychwybranych)
                    {

                        p.nazwa = item.nazwaB;
                        p.kategoriaID = item.kategoriaID;
                        p.ilosc = item.iloscB;
                        p.iloscW = item.iloscWB;
                        p.iloscZuzycia = item.iloscZuzyciaB;
                        p.jakieZuzycie = item.jakieZuzycieB;
                        p.minIlosc = item.minIloscB;
                        p.dataDodania = DateTime.Now.ToShortDateString();
                        p.dataWaznosci = DateTime.Now.AddDays(item.dniWaznosciB).ToShortDateString();
                        p.czyJednorazowy = "Nie";
                        p.zuzycieW = item.zuzycieWB;
                        SqliteDataAccess.DataAccess.SaveProduct(p);

                    }
                    MessageBox.Show("Udało się dodać produkty z dostawy");
                    var mainForm = Application.OpenForms.OfType<MenuF>().Single();
                    mainForm.LoadGrid();
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                MessageBox.Show("Lista jest pusta");
            }
            
        }

     

        private void bZapiszDostawe_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaProduktowBazowychwybranych.Count != 0 && (listaDostawa.Exists(p=>p.nazwa==tbDostawa.Text)==false))
                {
                    dostawa = new DostawaClass();
                    
                    dostawa.nazwa = tbDostawa.Text;//dorób sprawdzanie czy jest taka nazwa
                    dostawaString = "";
                    foreach (var item in listaProduktowBazowychwybranych)
                    {
                        if (dostawaString=="")
                        {
                            dostawaString += item.produktBID.ToString();
                        }
                        else
                        {
                            dostawaString += "," + item.produktBID.ToString();
                        }
                    }
                    dostawa.baza = dostawaString;

      
                    SqliteDataAccess.DataAccess.SaveDostawa(dostawa);
                    MessageBox.Show("Udało się zapisać dostawe");
                    loadDostaw();
                }
                else
                {
                    MessageBox.Show( "Twoja dostawa jest pusta lub istanieje taka nazwa");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Nie udało się zapisać dostawe");

            }
        }

      
        private void bWybierzDostawe_Click(object sender, EventArgs e)
        {
            try { 
           
                
                {
                    

                    string[] ssizes = cbDostawa.SelectedValue.ToString().Split(',', '\t');

                    foreach (var item in ssizes)
                    {
                        listaProduktowBazowychwybranych.Add(SqliteDataAccess.DataAccess.GetProduktByIDB(Int32.Parse(item)));
                    }
                    LoadGird2();
                }
            }
            catch(Exception ex)
            {
                labelWynik.Text = "Nie udało się!";
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz wyczyścić listę dostawy?", "Czyszczenie listy dostawy", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                try
                {


                    listaProduktowBazowychwybranych.Clear();
                    LoadGird2();
                }
                catch (Exception ex)
                {

                }
            }
        }

     
        private void cbZapiszDostawe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbZapiszDostawe.Checked == true)
            {
                label3.Visible = true;
                tbDostawa.Visible = true;
                bZapiszDostawe.Visible = true;
            }
            if (cbZapiszDostawe.Checked == false)
            {
                label3.Visible = false;
                tbDostawa.Visible = false;
                bZapiszDostawe.Visible = false;
            }
        }

     
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbWyborKategorii_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGird1();
        }
    } }
