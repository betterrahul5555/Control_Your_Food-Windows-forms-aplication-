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
    public partial class DeleteDelivery : Form
    { List<ProduktBazowy> listaProduktowBazowychwybranych;
        List<DostawaClass> listaDostawa;
        List<KategoriaProduktu> listaKategorii = new List<KategoriaProduktu>();
        public DeleteDelivery()
        {
            InitializeComponent(); 
            listaProduktowBazowychwybranych = new List<ProduktBazowy>();
        }

       
        void wczytajGrid()
        {
            try
            {
                string[] ssizes = cbDostawa.SelectedValue.ToString().Split(',', '\t');
                listaProduktowBazowychwybranych.Clear();
                foreach (var item in ssizes)
                {
                    listaProduktowBazowychwybranych.Add(SqliteDataAccess.DataAccess.GetProduktByIDB(Int32.Parse(item)));
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
        public void loadDostaw()
        {
            listaDostawa = SqliteDataAccess.DataAccess.LoadDostawaList();
            cbDostawa.DataSource = null;
            cbDostawa.DataSource = listaDostawa;
            
            cbDostawa.DisplayMember = "nazwa";
            cbDostawa.ValueMember = "baza";
            cbDostawa.SelectedIndex = 0;
        }
        void wripeUp()
        {
            listaKategorii = SqliteDataAccess.DataAccess.LoadCategory();
            listaProduktowBazowychwybranych.Clear();
            wczytajGrid();
            var dataTableWybraneProduty = ToDataTable(listaProduktowBazowychwybranych);
            
            dataTableWybraneProduty.Columns.Add("Kategoria:");
            for (int i = 0; i < dataTableWybraneProduty.Rows.Count; i++)
            {
                DataRow dr = dataTableWybraneProduty.Rows[i];

                dr[10] = zamiana(Int32.Parse(dr[2].ToString()));
            }
         
           
            dataGridView1.DataSource = dataTableWybraneProduty;
            dataGridView1.Columns["nazwaB"].HeaderText = "Nazwa:";
           
            dataGridView1.Columns["kategoriaID"].Visible = false;
            dataGridView1.Columns["iloscWB"].HeaderText = "Ilość w:";
            dataGridView1.Columns["iloscB"].HeaderText = "Ilość:";
            dataGridView1.Columns["produktBID"].Visible = false;
            dataGridView1.Columns["minIloscB"].HeaderText = "Minimalna ilośc:";
            dataGridView1.Columns["dniWaznosciB"].HeaderText = "Po ilu dniach traci wartość";
            dataGridView1.Columns["zuzycieWB"].HeaderText = "Zużycie w:";
            dataGridView1.Columns["iloscZuzyciaB"].HeaderText = "Ilość zużycia:";
            dataGridView1.Columns["jakieZuzycieB"].HeaderText = "Jakie zużycie:";
            dataGridView1.Columns["Kategoria:"].DisplayIndex = 2;
        }
        private void DeleteDelivery_Load(object sender, EventArgs e)
        {
            try
            {
                loadDostaw();
                wripeUp();
                
            }
            catch (Exception ex)
            {
                
            }
        }

      

        private void cbDostawa_SelectionChangeCommitted(object sender, EventArgs e)
        {
            wripeUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listaDostawa.Count != 0) {
                if (MessageBox.Show("Czy na pewno chcesz usunąć tę dostawę", "Usuwanie dostawy", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    try
                    {

                        SqliteDataAccess.DataAccess.DeleteDostawaWithName(cbDostawa.Text);
                        MessageBox.Show("Udało się usuąć dostawę: " + cbDostawa.Text);
                        loadDostaw();
                        wripeUp();
                    }
                    catch (Exception ex)
                    {

                    }
                }

        }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
