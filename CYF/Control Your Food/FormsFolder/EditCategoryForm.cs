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
    public partial class EditCategoryForm : Form
    {
        public EditCategoryForm()
        {
            InitializeComponent();
        }
        List<KategoriaProduktu> listaKategori = new List<KategoriaProduktu>();
        List<ProduktBazowy> listaProduktowB = new List<ProduktBazowy>();
        List<Product> listaProduktow = new List<Product>();

        int kategoriaIDWybrana;
        KategoriaProduktu kategoriaWybrana;
        private void EditCategoryForm_Load(object sender, EventArgs e)
        {
            loadGird();

        }
       
     

        private void buttonEdytuj_Click(object sender, EventArgs e)
        {
            try
            {
                if (gEdycjaKategorii.Visible == false)
                {
                    gEdycjaKategorii.Visible = true;


                }


            }
            catch (Exception ex)
            {

            }
        }
       public void loadGird()
        {
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.HeaderText = "";
            bc.Text = "Edytuj";
            bc.Name = "Edytuj";
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            bc.Width = 35;
            bc.FlatStyle = FlatStyle.Flat;
            dataGridView1.Columns.Add(bc);
            bc.UseColumnTextForButtonValue = true;
            DataGridViewButtonColumn dl = new DataGridViewButtonColumn();


            dl.HeaderText = "";
            dl.Text = "Usuń";
            dl.Name = "Usuń";
            dl.Width = 35;
            dl.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(dl);
            dl.FlatStyle = FlatStyle.Flat;
            listaKategori = SqliteDataAccess.DataAccess.LoadCategory();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaKategori;
            dataGridView1.Columns["kategoriaID"].Visible = false;
            dataGridView1.Columns["nazwaKategorii"].HeaderText = "Nazwa";
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 12, style: FontStyle.Bold);



        }
        private void buttonPotwierdzEdycje_Click(object sender, EventArgs e)
        {
            if (listaKategori.Exists(p => p.nazwaKategorii == tbTwojaWartosc.Text))
            {
                MessageBox.Show("Taka kategoria już jest, wpisz inną");
            }

            
            else
            {                kategoriaWybrana = listaKategori.Where(p => p.kategoriaID == kategoriaIDWybrana).FirstOrDefault();

                if (MessageBox.Show("Wciśnij tak, jeśli chcesz  zmienić kategorię we wszystkich aktualnie dodanych produktach oraz ich schematach", "Zmiana nazwy kategorii", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)

                {
                    try
                    {
                        if (tbTwojaWartosc.Text != "" || tbTwojaWartosc.Text != kategoriaWybrana.nazwaKategorii)
                        {
                          

                            zamienTylkoKategorie();
                            var mainForm = Application.OpenForms.OfType<MenuF>().Single();

                            mainForm.LoadGrid();

                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (tbTwojaWartosc.Text != "" || tbTwojaWartosc.Text != kategoriaWybrana.nazwaKategorii)
            {
              

                zamienTylkoKategorie();

            }
        }

        public void zamienTylkoKategorie()
        {
            string query = string.Format("UPDATE KategoriaProduktu set nazwaKategorii ='{0}' where kategoriaID={1}", tbTwojaWartosc.Text, kategoriaIDWybrana);
            try
            {

                SqliteDataAccess.DataAccess.EditCategory(tbTwojaWartosc.Text, kategoriaIDWybrana);
                MessageBox.Show("Kategoria została zmieniona") ;
            }
            catch (Exception ex)
            {
                MessageBox.Show ("nie udało się, spróbuj ponowanie");

            }
            gEdycjaKategorii.Visible = false;
            loadGird();
        }





        private void bAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            kategoriaIDWybrana = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
          
          
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    if (gEdycjaKategorii.Visible == false)
                    {
                        gEdycjaKategorii.Visible = true;


                    }


                }
                catch (Exception ex)
                {

                }



            }
            if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {




                if (MessageBox.Show("Czy na pewno chcesz usunąć kategorię: " + "?", "Usuwanie kategorii", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {
                        listaProduktowB = SqliteDataAccess.DataAccess.LoadProduktBazowy();
                        listaProduktow = SqliteDataAccess.DataAccess.LoadProduct();
                        Console.WriteLine(kategoriaIDWybrana);
                        if (listaProduktow.Exists(p => p.kategoriaID == kategoriaIDWybrana) || listaProduktowB.Exists(k => k.kategoriaID == kategoriaIDWybrana))
                        {
                            MessageBox.Show("Masz dodane produkty, które zawierają tą kategorie. Dodaj nową kategorię lub usuń produkty, które ją zawierają.");

                        }
                        else
                        {
                            SqliteDataAccess.DataAccess.DeleteCategory(kategoriaIDWybrana);
                            MessageBox.Show("Udało się usunąć kategorię");
                            loadGird();
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                }



            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAddCategory_Click_1(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.Show();
        }
    }
}
