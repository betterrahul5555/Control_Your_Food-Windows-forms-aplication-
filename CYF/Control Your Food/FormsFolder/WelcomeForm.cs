using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control_Your_Food.FormsFolder;

namespace Control_Your_Food.FormsFolder
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

    
        private void button1_Click(object sender, EventArgs e)
        {
            WyborDniaForm wyborDniaForm = new WyborDniaForm();
            wyborDniaForm.Show();


            this.Hide();
        }
    }
}
