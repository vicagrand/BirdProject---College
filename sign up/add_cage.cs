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
    public partial class add_cage : Form
    {
        public add_cage()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox2.SelectedItem.ToString();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||textBox4.Text==""||comboBox2.SelectedItem==null) {
                MessageBox.Show("There are missing details to your cage", "please Try again", MessageBoxButtons.OK);

            }
            if (!IsValidNumber(textBox2.Text))
            {
                MessageBox.Show("Invalid length. please use just Numbers.");
                return;
            }
            if (!IsValidNumber(textBox3.Text))
            {
                MessageBox.Show("Invalid width. please use just Numbers.");
                return;
            }
            if (!IsValidNumber(textBox4.Text))
            {
                MessageBox.Show("Invalid height. please use just Numbers.");
                return;
            }
            else
            {
                con.Open();
                string cage = "INSERT INTO tbl_cages VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox2.SelectedItem + "')";
                cmd = new OleDbCommand(cage, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            this.Hide();
            new MainPage().Show();
        }

        private void add_cage_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainPage().Show();
        }
        private bool IsValidNumber(string number)
        {

            return int.TryParse(number, out _);

        }
    }
}
