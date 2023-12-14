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
    public struct Strukturaszukanie
    {
        public string nazwa { get; set; }
        public int id { get; set; }
        public Strukturaszukanie(string nazwa_, int id_)
        {
            nazwa = nazwa_;
            id = id_;
        }
    }

    public struct ProduktTest
    {

        public int produktID { get; set; }
        public string nazwa { get; set; }
        public string kategoria { get; set; }
        public string iloscW { get; set; }
        public double ilosc { get; set; }
        public string dataDodania { get; set; }
        public string dataWaznosci { get; set; }
        public double minIlosc { get; set; }
        public string jakieZuzycie { get; set; }
        public double iloscZuzycia { get; set; }
        public string zuzycieW { get; set; }
        public string czyJednorazowy { get; set; }


    }
    public partial class MenuF : Form
    {

        public List<EntryDate> ListaDat = new List<EntryDate>();
        DataTable table = new DataTable("ParentTable");

        public static List<Strukturaszukanie> listaDoSzukania = new List<Strukturaszukanie>();
        static DateTime dateTimeNow;
        public static DateTime dateTimeBefor;
        public List<Product> productsOld = new List<Product>();
        public List<Product> productsDataW = new List<Product>();

        public List<Product> listaProduktowDojutra = new List<Product>();
        public List<Product> listaProduktowDzis = new List<Product>();
        List<Product> listaProduktowPoTerminie = new List<Product>();
        List<Product> listaMaloProduktow = new List<Product>();
        List<Product> listaDuzoProduktow = new List<Product>();
        List<Product> listaBrakProduktow = new List<Product>();
        public List<Product> products = new List<Product>();
        public List<Product> ListadoFiltrowaniaproducts = new List<Product>();
        public List<WartosciMin> wartoscMin = new List<WartosciMin>();

        public List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();

        int productId;
        double wSztukach;
        double wKlio;
        double wDeko;
        double wGramach;
        public MenuF()
        {
            InitializeComponent();

        }



        private void dodajNowyProduktToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddProdukt add = new AddProdukt();
            add.Show();

        }




        private void listaZakupówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkDataWaznosci();
            ShoppingList shoppingList = new ShoppingList(listaMaloProduktow, listaProduktowPoTerminie, listaBrakProduktow);
            shoppingList.Show();
        }

        private void dodajUsuńKategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCategoryForm editCategoryForm = new EditCategoryForm();
            editCategoryForm.Show();
        }

        void pokazDzis()
        {
            try
            {
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[9].Value.ToString() == dateTimeBefor.ToShortDateString())
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                checkBoxBrak.Checked = false;
                checkBoxDuzo.Checked = false;
                checkBoxMało.Checked = false;
                checkBoxPoTerminie.Checked = false;
            }
            catch
            {

            }
        }
        void pokazJutro()
        {
            try {
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();
                var k = DateTime.Parse(dateTimeBefor.ToShortDateString());
                var m = k.AddDays(1);
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[9].Value.ToString() == m.ToShortDateString())
                    {
                        row.Visible = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
                checkBoxBrak.Checked = false;
                checkBoxDuzo.Checked = false;
                checkBoxMało.Checked = false;
                checkBoxPoTerminie.Checked = false;
            }
            catch
            {

            }
        }

        string odmianaProduktowDzis(int ilosc)
        {
            if (ilosc == 1)
            {
                return " produkt traci dziś ważność!";
            }
            if (ilosc > 1 && ilosc < 4)
            {
                return " produkty tracą dziś ważność!";
            }
            else
            {
                return " produktów traci dziś ważność!";
            }
        }
        string odmianaProduktowJutro(int ilosc)
        {
            if (ilosc == 1)
            {
                return " produkt traci jutro ważność!";
            }
            if (ilosc > 1 && ilosc < 4)
            {
                return " produkty tracą jutro ważność!";
            }
            else
            {
                return " produktów traci jutro ważność!";
            }
        }
        public void checkDataWaznosci()
        {
            productsDataW = SqliteDataAccess.DataAccess.LoadProduct().Where(p => p.ilosc != 0).ToList(); ;//.Where(p=>p.iloscZuzycia!=null);


            listaProduktowDzis.Clear();
            listaProduktowDojutra.Clear();
            listaProduktowPoTerminie.Clear();
            DateTime dateTime;

            dateTime = DateTime.Parse(dateTimeBefor.ToShortDateString());

            foreach (var item in productsDataW)
            {

                try
                {

                    if (item.dataWaznosci == dateTimeBefor.ToShortDateString())
                    {
                        listaProduktowDzis.Add(item);
                    }
                    int res = DateTime.Compare(DateTime.Parse(item.dataWaznosci), dateTime);
                 
                    if (res < 0)
                    {
                        listaProduktowPoTerminie.Add(item);
                    }

                    var k = DateTime.Parse(dateTimeBefor.ToShortDateString());
                    var m = k.AddDays(1);
                    if (m.ToShortDateString() == item.dataWaznosci)
                    {
                        listaProduktowDojutra.Add(item);
                    }

                    if (listaProduktowDzis.Count != 0 && listaProduktowDojutra.Count != 0)
                    {



                        labelDoDziś.Text = String.Format("Uwaga: " + listaProduktowDzis.Count.ToString() + odmianaProduktowDzis(listaProduktowDzis.Count));
                        labelDoJutra.Text = String.Format("Uwaga: " + listaProduktowDojutra.Count.ToString() + odmianaProduktowJutro(listaProduktowDojutra.Count));
                        panelPowiadomienia.Visible = true;
                        panelPowiadomieniaJutro.Visible = true;
                    }
                    if (listaProduktowDzis.Count != 0 && listaProduktowDojutra.Count == 0)
                    {
                        labelDoDziś.Text = String.Format("Uwaga: " + listaProduktowDzis.Count.ToString() + odmianaProduktowDzis(listaProduktowDzis.Count));
                        panelPowiadomienia.Visible = true;
                    }
                    if (listaProduktowDzis.Count == 0 && listaProduktowDojutra.Count != 0)
                    {
                        labelDoJutra.Text = String.Format("Uwaga: " + listaProduktowDojutra.Count.ToString() + odmianaProduktowJutro(listaProduktowDojutra.Count));
                        panelPowiadomieniaJutro.Visible = true;

                    }
                    if (products.Count == 0)
                    {
                        panelPowiadomienia.Visible = false;
                        panelPowiadomieniaJutro.Visible = false;
                    }
                    if (listaProduktowDzis.Count == 0 && listaProduktowDojutra.Count == 0)
                    {
                        panelPowiadomienia.Visible = false;
                        panelPowiadomieniaJutro.Visible = false;
                    }
                    if (listaProduktowDzis.Count == 0)
                    {
                        panelPowiadomienia.Visible = false;
                    }
                    if (listaProduktowDojutra.Count == 0)
                    {
                        panelPowiadomieniaJutro.Visible = false;
                    }





                }
                catch
                {
                }
            }
              if (dataGridView1.Rows.Count == 0)
                        try
                        {
                            panelPowiadomienia.Visible = false;
                            panelPowiadomieniaJutro.Visible = false;
                        }
                        catch
                        {

                        }      
                
            }
        
        public static int konwerter(Product product)
        {
            if (product.jakieZuzycie == "Dzienne") return 1;

            if (product.jakieZuzycie == "Tygodniowe") return 7;
            else return 30;
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
            else// if(JednostkaIlość == "Gramach")
            {
                if (JednostakZużycia == "Kilogramach")
                    return wartosc * 1000;
                if (JednostakZużycia == "Dekagramach") return wartosc * 100;
                else return wartosc;

            }


        }
        public void check2()
        {
            dateTimeNow = DateTime.Now.Date;
            productsOld = SqliteDataAccess.DataAccess.LoadProduct().Where(p => p.iloscZuzycia != 0).ToList();

            var k = dateTimeBefor - dateTimeNow;
            if (dateTimeBefor == dateTimeNow)
            {
                Console.WriteLine("Loguje się dziś kolejny raz");
            }
            else
            {
                productsOld = SqliteDataAccess.DataAccess.LoadProduct().Where(p => p.iloscZuzycia != 0).ToList(); ;//.Where(p=>p.iloscZuzycia!=null);



                double m = 0;

                foreach (var item in productsOld)
                {
                    if (item.dataDodania != dateTimeBefor.ToShortDateString() /*&& listaProduktowPoTerminie.Exists(p=>p.produktID==item.produktID)==false*/)
                    {
                        if (item.ilosc == 0)
                        {
                            continue;
                        }
                        if (item.iloscW != "Sztukach")
                        {
                            m = item.ilosc - (k.TotalDays * zamienNaOdpowiedni(item.iloscZuzycia, item.iloscW, item.zuzycieW) / konwerter(item));
                        }
                        if (item.iloscW == "Sztukach")
                        {
                            m = item.ilosc - (Math.Round(k.TotalDays * zamienNaOdpowiedni(item.iloscZuzycia, item.iloscW, item.zuzycieW) / konwerter(item)));
                        }
                        if (m <= 0)
                        {
                            string msql = "UPDATE Produkt SET ilosc = " + 0 + " WHERE produktID =" + item.produktID;
                            SqliteDataAccess.DataAccess.EditProduct(msql);
                            Console.WriteLine(msql);
                        }
                        if (m > 0)
                        {
                            var zaokroglona = Math.Round(m, 3);

                            string msql = "UPDATE Produkt SET ilosc = " + zaokroglona.ToString().Replace(",", ".") + " WHERE produktID =" + item.produktID;
                            SqliteDataAccess.DataAccess.EditProduct(msql);
                            Console.WriteLine(msql);
                        }

                        Console.WriteLine("total days" + k.TotalDays);

                    }
                }

            }
        }

        private void MenuF_Load(object sender, EventArgs e)
        {
            dateTimeBefor = DateTime.Parse(SqliteDataAccess.DataAccess.LoadDateWejscia().Last().data); 
            checkDataWaznosci();
            check2();
          
            LoadGrid();
            Strukturaszukanie ilosc = new Strukturaszukanie();
            listaDoSzukania.Add(new Strukturaszukanie("nazwie", 1));
            listaDoSzukania.Add(new Strukturaszukanie("kategorii", 12));
            listaDoSzukania.Add(new Strukturaszukanie("ilości", 3));
            listaDoSzukania.Add(new Strukturaszukanie("jednostce ilości", 4));
            listaDoSzukania.Add(new Strukturaszukanie("dacie dodania", 5));
            listaDoSzukania.Add(new Strukturaszukanie("dacie ważności", 6));
            listaDoSzukania.Add(new Strukturaszukanie("jakie zużycie", 7));
            listaDoSzukania.Add(new Strukturaszukanie("ilości zużycia", 8));
            listaDoSzukania.Add(new Strukturaszukanie("jednostce zużycia", 9));
            listaDoSzukania.Add(new Strukturaszukanie("czy okazjonalny", 10));
            listaDoSzukania.Add(new Strukturaszukanie("minimalnej ilości", 11));
            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
            cbSzukaj.DataSource = listaDoSzukania;
            cbSzukaj.DisplayMember = "nazwa";
            cbSzukaj.ValueMember = "id";
            cbSzukaj.SelectedValue = 1;

        }

        private void usuńDostawęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDelivery deleteDelivery = new DeleteDelivery();
            deleteDelivery.Show();
        }

        private void MenuF_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
        "Czy na pewno chcesz zamknąć program?",
        "Zamykanie Programu Control Your Food",
        MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);
        }

        private void MenuF_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void bWyszukaj_Click(object sender, EventArgs e)
        {
            string searchValue = tbWyszukaj.Text;




            dataGridView1.ClearSelection();
            string strSearch = searchValue.ToUpper();




            int x = 0;
            if (strSearch != "")
            {
                // Prevent exception when hiding rows out of view
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();

                // Show all lines
                for (int u = 0; u < dataGridView1.RowCount; u++)
                {
                    dataGridView1.Rows[u].Visible = true;
                    x++;
                }

                // Hide the ones that you want with the filter you want.
                for (int u = 0; u < dataGridView1.RowCount; u++)
                {
                    if (dataGridView1.Rows[u].Cells[3 + Int16.Parse(cbSzukaj.SelectedValue.ToString())].Value.ToString().ToUpper().Contains(strSearch))
                    {
                        dataGridView1.Rows[u].Visible = true;
                    }
                    else
                    {
                        dataGridView1.Rows[u].Visible = false;
                    }
                }

                // Resume data grid view binding
                currencyManager.ResumeBinding();
            }

        }
        public void LoadGrid()
        {
            try
            {
                listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
                products = SqliteDataAccess.DataAccess.LoadProduct();
                checkBoxBrak.Checked = false;
                checkBoxDuzo.Checked = false;
                checkBoxMało.Checked = false;
                checkBoxPoTerminie.Checked = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "";
                bc.Text = "Edytuj";
                bc.Name = "Edytuj";
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                //bc.Width = 50;
                bc.FlatStyle = FlatStyle.Flat;
                dataGridView1.Columns.Add(bc);
                bc.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn dl = new DataGridViewButtonColumn();

                listaProduktowDzis.Clear();
                listaProduktowDzis.Clear();
                dl.HeaderText = "";
                dl.Text = "Usuń";
                dl.Name = "Usuń";
                //dl.Width = 50;
                dl.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(dl);

                dl.FlatStyle = FlatStyle.Flat;

                DataGridViewButtonColumn ac = new DataGridViewButtonColumn();


                ac.HeaderText = "";
                ac.Text = "Zużycie";
                ac.Name = "Zużycie";
                //dl.Width = 50;
                ac.FlatStyle = FlatStyle.Flat;
                ac.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(ac);


                Product product = new Product();
                var k = product.GetAllProducts();
                k.Columns.Add("Kategoria:");

                for (int i = 0; i < k.Rows.Count; i++)
                {
                    DataRow dr = k.Rows[i];

                    dr[12] = zamiana(Int32.Parse(dr[2].ToString()));
                }
                dataGridView1.DataSource = k;

                dataGridView1.Columns["ilosc"].HeaderText = "Ilość:";
                dataGridView1.Columns["nazwa"].HeaderText = "Nazwa:";
                dataGridView1.Columns["produktID"].Visible = false;
                dataGridView1.Columns["kategoriaID"].Visible = false;
                dataGridView1.Columns["dataDodania"].HeaderText = "Data dodania:";
                dataGridView1.Columns["dataWaznosci"].HeaderText = "Data Ważności:";
                dataGridView1.Columns["zuzycieW"].HeaderText = "Zużycie w:";
                dataGridView1.Columns["czyJednorazowy"].HeaderText = "Okazjonalny?";
                dataGridView1.Columns["minIlosc"].HeaderText = "Minimalna Ilość:";
                dataGridView1.Columns["jakieZuzycie"].HeaderText = "Jakie Zużycie:";
                dataGridView1.Columns["iloscW"].HeaderText = "Ilość w:";
                dataGridView1.Columns["iloscZuzycia"].HeaderText = "Zużywa się czasowo:";
                dataGridView1.Columns["Kategoria:"].DisplayIndex = 5;


                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10, style: FontStyle.Bold);
                checkDataWaznosci();
                filtrRow();
            }
            catch
            {

            }
        }
        string zamiana(int id)
        {

            return listaKategorii.Where(p => p.kategoriaID == id).FirstOrDefault().nazwaKategorii.ToString();
        }


        void filtrRow()
        {
            DataGridViewCellStyle styleNieMa = new DataGridViewCellStyle();
            styleNieMa.BackColor = Color.LightSalmon;
            styleNieMa.ForeColor = Color.Black;

            DataGridViewCellStyle styleMało = new DataGridViewCellStyle();
            styleMało.BackColor = Color.LemonChiffon;
            styleMało.ForeColor = Color.Black;

            DataGridViewCellStyle styleOk = new DataGridViewCellStyle();
            styleOk.BackColor = Color.DarkKhaki;
            styleOk.ForeColor = Color.Black;

            DataGridViewCellStyle stylePoTerminie = new DataGridViewCellStyle();
            stylePoTerminie.BackColor = Color.Silver;
            stylePoTerminie.ForeColor = Color.Black;

            listaBrakProduktow.Clear();

            listaDuzoProduktow.Clear();
            listaMaloProduktow.Clear();
            wartoscMin = SqliteDataAccess.DataAccess.LoadWartosc();

            wSztukach = wartoscMin.Where(p => p.nazwa == "Sztukach").First().ilosc;
            wKlio = wartoscMin.Where(p => p.nazwa == "Kilogramach").First().ilosc;
            wDeko = wartoscMin.Where(p => p.nazwa == "Dekagramach").First().ilosc;
            wGramach = wartoscMin.Where(p => p.nazwa == "Gramach").First().ilosc;

            double wartoscRow;
            string jednostka;
            double MinRow;

            foreach (DataGridViewRow row in dataGridView1.Rows)

            {
                Console.WriteLine(row.Cells[3].Value.ToString());
                wartoscRow = Double.Parse(row.Cells[6].Value.ToString());
                jednostka = row.Cells[7].Value.ToString();
                MinRow = Double.Parse(row.Cells[14].Value.ToString());
                if (listaProduktowPoTerminie.Exists(p => p.produktID == Int16.Parse(row.Cells[3].Value.ToString())))
                {
                    row.DefaultCellStyle = stylePoTerminie;
                    //   listaProduktowPoTerminie.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                    continue;
                }
                if (wartoscRow == 0)
                {
                    row.DefaultCellStyle = styleNieMa;
                    listaBrakProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                    continue;
                }
                if (MinRow == 0)
                {

                    {
                        if (jednostka == "Sztukach")
                        {
                            if (wartoscRow <= wSztukach)
                            {
                                row.DefaultCellStyle = styleMało;
                                listaMaloProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                                continue;
                            }
                            else
                            {
                                row.DefaultCellStyle = styleOk;
                                listaDuzoProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                            }


                        }
                        if (jednostka == "Kilogramach")
                        {
                            if (wartoscRow <= wKlio)//&& Double.Parse(row.Cells[6].Value.ToString()) <= wSztukach)
                            {
                                row.DefaultCellStyle = styleMało;
                                listaMaloProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                                continue;
                            }
                            else
                            {
                                row.DefaultCellStyle = styleOk;
                                listaDuzoProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                            }
                        }

                        if (jednostka == "Dekagramach")
                        {
                            if (wartoscRow <= wDeko)//&& Double.Parse(row.Cells[6].Value.ToString()) <= wSztukach)
                            {
                                row.DefaultCellStyle = styleMało;
                                listaMaloProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                                continue;
                            }
                            else
                            {
                                row.DefaultCellStyle = styleOk;
                                listaDuzoProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                            }


                        }

                        if (jednostka == "Gramach")
                        {
                            if (wartoscRow <= wGramach)//&& Double.Parse(row.Cells[6].Value.ToString()) <= wSztukach)
                            {
                                row.DefaultCellStyle = styleMało;
                                listaMaloProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                                continue;
                            }
                            else
                            {
                                row.DefaultCellStyle = styleOk;
                                listaDuzoProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));
                            }
                        }
                      
                    }

                }
                else
                {
                    if (wartoscRow <= MinRow)
                    {
                        row.DefaultCellStyle = styleMało;
                        listaMaloProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));

                        continue;
                    }
                    else
                    {
                        row.DefaultCellStyle = styleOk;
                        listaDuzoProduktow.Add(products.Find(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())));

                    }
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {

                }
                else
                {
                    Console.WriteLine(e.ColumnIndex + " " + e.RowIndex);
                    productId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

                    dataGridView1.Rows[e.RowIndex].Selected = true;

                    if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                    {

                        dataGridView1.Rows[e.RowIndex].Selected = true;
                        EditProdukt editProdukt = new EditProdukt(productId);
                        editProdukt.Show();



                    }
                    if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                    {


                        if (MessageBox.Show("Czy na pewno chcesz usunąć ten produkt?", "Usuwanie produktu", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            try
                            {
                                SqliteDataAccess.DataAccess.DeleteProduct(productId);

                                LoadGrid();
                                //  dataGridView1.Rows[e.RowIndex].Selected = true;

                            }
                            catch (Exception ex)
                            {
                                //  filtrRow();
                            }
                        }

                    }
                    if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                    {



                        try
                        {
                            if (products.First(p => p.produktID == productId).ilosc != 0)
                            {
                                AddConsume2 addConsume2 = new AddConsume2(productId);
                                addConsume2.Show();


                                dataGridView1.Rows[e.RowIndex].Selected = true;
                            }
                            else
                            {
                                MessageBox.Show("Produkt się skończył. Nie możesz dodać zużycia.");
                            }

                        }
                        catch (Exception ex)
                        {
                            //filtrRow();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                filtrRow();
            }

        }


        private void bOdwierz_Click(object sender, EventArgs e)
        {
            LoadGrid();

        }

        private void dodajDostawęToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.Show();
        }

        private void usuńDostawęToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteDelivery deleteDelivery = new DeleteDelivery();

            deleteDelivery.Show();
        }

        private void dodajKategorięToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategory add = new AddCategory();
            add.Show();
        }

        private void labelPokazDzis_Click(object sender, EventArgs e)
        {

            pokazDzis();


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Wyjscie_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz zamknąć program?",
        "Zamykanie Programu Control Your Food", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                this.Dispose();
                Environment.Exit(0);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pokazJutro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMin setMin = new SetMin();
            setMin.Show();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            filtrRow();
        }

        private void produktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProdukt addProdukt = new AddProdukt();
            addProdukt.Show();
        }

      

   

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {

                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                currencyManager.SuspendBinding();
                if (MessageBox.Show("Czy na pewno chcesz usunąć zaznaczone produkty?", "Usuwanie produktów", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        try
                        {
                            if (row.Selected == true)
                            {

                                SqliteDataAccess.DataAccess.DeleteProduct(Int32.Parse(row.Cells[3].Value.ToString()));
                            }
                        }
                        catch
                        {

                        }

                    }
                    LoadGrid();
                }
            }
            else
            {
                MessageBox.Show("Zaznacz produkt, który chcesz usunąć.", "Usuwanie produktów");
            }
        }

     

   



        private void checkBoxPoTerminie_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxPoTerminie.CheckState == CheckState.Unchecked)
                {

                    pokazWszyskieRow();
                }
                if (checkBoxPoTerminie.CheckState == CheckState.Checked)
                {

                    checkBoxBrak.Checked = false;
                    checkBoxDuzo.Checked = false;
                    checkBoxMało.Checked = false;
                    checkBoxPoTerminie.Checked = true;
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (listaProduktowPoTerminie.Exists(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void checkBoxDuzo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxDuzo.CheckState == CheckState.Unchecked)
                {
                    pokazWszyskieRow();
                }
                if (checkBoxDuzo.CheckState == CheckState.Checked)
                {

                    checkBoxBrak.Checked = false;
                    checkBoxPoTerminie.Checked = false;
                    checkBoxMało.Checked = false;
                    checkBox2.Checked = false;
                    checkBox1.Checked = false;

                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        
                            if (listaDuzoProduktow.Exists(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())))
                            {
                                row.Visible = true;
                            }
                            else
                            {
                                row.Visible = false;
                            }
                        
                       
                    }
                }
            }
            catch
            {

            }
        }

        private void checkBoxMało_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxMało.CheckState == CheckState.Unchecked)
                {
                    pokazWszyskieRow();
                }
                if (checkBoxMało.CheckState == CheckState.Checked)
                {
                    checkBoxBrak.Checked = false;
                    checkBoxPoTerminie.Checked = false;
                    checkBoxDuzo.Checked = false;
                    checkBoxMało.Checked = true;
                    checkBox2.Checked = false;
                    checkBox1.Checked = false;
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        try
                        {
                            if (listaMaloProduktow.Exists(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())))
                            {
                                row.Visible = true;
                            }
                            else
                            {
                                row.Visible = false;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            catch
            {

            }
        }
        void pokazWszyskieRow()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    
                        row.Visible = true;
                 }
                   
                catch
                {

                }
            }
        }
        private void checkBoxBrak_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxBrak.CheckState == CheckState.Unchecked)
                {
                    pokazWszyskieRow();
                }
                if (checkBoxBrak.CheckState == CheckState.Checked)
                {
                    checkBoxMało.Checked = false;
                    checkBoxPoTerminie.Checked = false;
                    checkBoxDuzo.Checked = false;
                    checkBox2.Checked = false;
                    checkBox1.Checked = false;
                    CurrencyManager currencyManager = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager.SuspendBinding();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                        if (listaBrakProduktow.Exists(p => p.produktID == Int32.Parse(row.Cells[3].Value.ToString())))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }

                }
            }

            catch
            {

            } 
        }

     

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.CheckState == CheckState.Unchecked)
                {
                    pokazWszyskieRow();
                }
                if (checkBox1.CheckState == CheckState.Checked)
                {


                    checkBoxMało.Checked = false;
                    checkBoxPoTerminie.Checked = false;
                    checkBoxDuzo.Checked = false;
                    checkBox2.Checked = false;
                    pokazDzis();
                    checkBox1.Checked = true;
                }
            }
            catch
            {

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.CheckState == CheckState.Unchecked)
                {
                    pokazWszyskieRow();
                }
                if (checkBox2.CheckState == CheckState.Checked)
                {


                    checkBoxMało.Checked = false;
                    checkBoxPoTerminie.Checked = false;
                    checkBoxDuzo.Checked = false;
                    checkBox1.Checked = false;
                    pokazJutro();
                    checkBox2.Checked = true;
                }
            }
            catch
            {

            }
        }

       
    }
}

