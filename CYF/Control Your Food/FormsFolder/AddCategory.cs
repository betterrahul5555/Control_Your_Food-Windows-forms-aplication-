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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();

        private void bDodajNowaKategorie_Click(object sender, EventArgs e)
        {
            KategoriaProduktu kategoriaProduktu = new KategoriaProduktu();
           
            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
            
           
            try
            {
                if (tbDodajNowaKategorie.Text != "" )

                {
                    if (listaKategorii.Exists(p => p.nazwaKategorii == tbDodajNowaKategorie.Text) == false)
                    {
                        kategoriaProduktu.nazwaKategorii = tbDodajNowaKategorie.Text;
                        SqliteDataAccess.DataAccess.SaveCategory(kategoriaProduktu);


                        MessageBox.Show("Pomyślnie dodano nową kategorie!");
                        tbDodajNowaKategorie.Text = "";
                        var mainForm = Application.OpenForms.OfType<EditCategoryForm>().Single();

                        mainForm.loadGird();
                        

                    }
                    else
                    {
                      MessageBox.Show("Ta kategoria jest już dodana. Podaj nową kategorię!");
                    }
                }
                else
                {

                    MessageBox.Show("Nie podano nazwy kategorii.");


                }
            }
            catch (Exception ex)
            {
               
            }

        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
