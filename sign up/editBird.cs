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
    public partial class editBird : Form
    {
        string number;
        public editBird()
        {
            
        }
        public editBird(string text)
        {
            InitializeComponent();
            number = text;
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void editBird_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string bird = "UPDATE tbl_birds SET serialnumber='" + textBox1.Text + "',speices='" + comboBox1.SelectedItem + "',subspeices='" + comboBox2.SelectedItem + "',gender='" + comboBox3.SelectedItem + "',dateofhatching='" + dateTimePicker1.Text + "',cagenumber='" + textBox5.Text + "',mothernumber='" + textBox6.Text + "',fathernumber='" + textBox2.Text + "',headcolor='" + comboBox4.SelectedItem + "',brestcolor='" + comboBox5.SelectedItem + "',bodycolor='" + comboBox6.SelectedItem + "' where serialnumber='" + number + "'"; ;
            cmd = new OleDbCommand(bird, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Bird details updated.");
            this.Hide();
            new MainPage().Show();
            con.Close();

        }
        private void PopulateSecondComboBox()
        {
            // Clear existing options in the second combobox
            comboBox2.Items.Clear();

            // Get the selected item from the first combobox
            string selectedItem = comboBox1.SelectedItem.ToString();

            // Generate and add new options to the second combobox based on the selected item
            if (selectedItem == "American Gouldian")
            {
                comboBox2.Items.Add("North America");
                comboBox2.Items.Add("Center America");
                comboBox2.Items.Add("South America");

            }
            else if (selectedItem == "European Gouldian")
            {
                comboBox2.Items.Add("East Europe");
                comboBox2.Items.Add("West Europe");
            }
            else if (selectedItem == "Australian Gouldian")
            {
                comboBox2.Items.Add("Central Australia");
                comboBox2.Items.Add("Coastal cities");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSecondComboBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
