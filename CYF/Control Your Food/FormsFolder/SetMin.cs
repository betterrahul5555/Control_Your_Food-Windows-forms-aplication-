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
    public partial class SetMin : Form
    {
        public SetMin()
        {
            InitializeComponent();
        }
        public List<WartosciMin> wartoscMin = new List<WartosciMin>();

       
        private void SetMin_Load(object sender, EventArgs e)
        {
            try
            {
                wartoscMin = SqliteDataAccess.DataAccess.LoadWartosc();
                numericUpDownSzutki.Value = Decimal.Parse(wartoscMin.First(p => p.nazwa == "Sztukach").ilosc.ToString());
                numericUpDownKilo.Value = Decimal.Parse(wartoscMin.First(p => p.nazwa == "Kilogramach").ilosc.ToString());
                numericUpDownGramy.Value = Decimal.Parse(wartoscMin.First(p => p.nazwa == "Gramach").ilosc.ToString());
                numericUpDownDeko.Value = Decimal.Parse(wartoscMin.First(p => p.nazwa == "Dekagramach").ilosc.ToString());
            }
            catch
            {

            }
        }

        private void bZmien_Click(object sender, EventArgs e)
        {
            try
            {
                SqliteDataAccess.DataAccess.EditWartisci(numericUpDownSzutki.Value.ToString().Replace(",", "."), "Sztukach");
                SqliteDataAccess.DataAccess.EditWartisci(numericUpDownKilo.Value.ToString().Replace(",", "."), "Kilogramach");
                SqliteDataAccess.DataAccess.EditWartisci(numericUpDownGramy.Value.ToString().Replace(",", "."), "Gramach");
                SqliteDataAccess.DataAccess.EditWartisci(numericUpDownDeko.Value.ToString().Replace(",", "."), "Dekagramach"); 
                MessageBox.Show("Udało się zmienić");
                var mainForm = Application.OpenForms.OfType<MenuF>().Single();
                mainForm.LoadGrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
