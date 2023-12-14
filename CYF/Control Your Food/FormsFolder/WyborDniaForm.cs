using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Control_Your_Food.Classes;
using Control_Your_Food.FormsFolder;
using CYFLibrary;
namespace Control_Your_Food
{

    public partial class WyborDniaForm : Form
    {
        public DateTime dzisiejsza_Data = new DateTime(); 

        public WyborDniaForm()
        {
            InitializeComponent();
        
       
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EntryDate entryDat = new EntryDate();
            entryDat.data = dateTimePicker1.Value.ToShortDateString();
            CYFLibrary.SqliteDataAccess.DataAccess.SaveEntryDate(entryDat);
            MenuF menu = new MenuF();
            menu.Show();
            this.Close();
        
        }
    }
}
