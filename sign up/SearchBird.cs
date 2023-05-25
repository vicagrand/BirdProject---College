using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace sign_up
{
    public partial class SearchBird : Form
    {
        public SearchBird()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void SearchBird_Load(object sender, EventArgs e)
        {
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                showBird();
            }
            else
            {
               
                showBirds();
            }

        }
        private void showBird()
        {
                this.Hide();

                new showbird(textBox1.Text).Show();

            
        }
        private void showBirds()
        {
     
            if (comboBox1.SelectedItem != null)
            {
          
                this.Hide();

                new showBirds(comboBox1.SelectedItem.ToString()).Show();

            }
            else if (comboBox2.SelectedItem!= null)
            {
                new showBirds(comboBox2.Text.ToString()).Show();
            }
            else if (dateTimePicker1.Value!= null)
            {
                new showBirds(dateTimePicker1.Text.ToString()).Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainPage().Show();
        }
    }

       
    
}
    
    

