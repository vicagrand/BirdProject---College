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
    public partial class add_bird : Form
    {
        public add_bird()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void add_bird_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!IsValidNumber(textBox1.Text))
            {
                MessageBox.Show("Invalid Serial number. please use just Numbers.");
                return;
            }
            if (!IsValidNumber(textBox6.Text))
            {
                MessageBox.Show("Invalid Mother Serial number. please use just Numbers.");
                return;
            }
            if (!IsValidNumber(textBox2.Text))
            {
                MessageBox.Show("Invalid Father Serial number. please use just Numbers.");
                return;
            }
            string cage = "SELECT * FROM tbl_cages WHERE serialnumber='" + textBox5.Text + "' ";
            cmd = new OleDbCommand(cage, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() != true)
            {
                MessageBox.Show("This cage number doesnt exist.");
                return;
            }
            string mother = "SELECT * FROM tbl_birds WHERE serialnumber='" + textBox6.Text + "' ";
            cmd = new OleDbCommand(mother, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() != true)
            {
                MessageBox.Show("Your mother serial number is wrong.");
                return;
            }
            string father = "SELECT * FROM tbl_birds WHERE serialnumber='" + textBox2.Text + "' ";
            cmd = new OleDbCommand(father, con);
            dr = cmd.ExecuteReader();
            if (dr.Read() != true)
            {
                MessageBox.Show("Your father serial number is wrong.");
                return;
            }

            else
            {
                string bird = "INSERT INTO tbl_birds VALUES('" + textBox1.Text + "','" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + comboBox3.SelectedItem + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + comboBox4.SelectedItem + "','" + comboBox5.SelectedItem + "','" + comboBox6.SelectedItem + "')";
                cmd = new OleDbCommand(bird, con);
                cmd.ExecuteNonQuery();

            }
            this.Hide();
            new MainPage().Show();
            con.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSecondComboBox();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

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
        private bool IsValidNumber(string number)
        {

            return int.TryParse(number, out _);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainPage().Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}