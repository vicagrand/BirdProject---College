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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
      

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void txtbuttonRegister_Click(object sender, EventArgs e)
        {
            // Validate username and password
            if (!IsValidUsername(txtUsername.Text))
            {
                MessageBox.Show("Invalid username. Username must contain between 6 to 8 characters with at most 2 digits and the rest letters.");
                return;
            }
            if (!IsValidId(textBox3.Text))
            {
                MessageBox.Show("Invalid Id. Id must contain 9 digits.");
                return;
            }

            if (!IsValidPassword(textBox1.Text))
            {
                MessageBox.Show("Invalid password. Password must contain between 8 to 10 characters and include at least one letter, one digit, and one special character.");
                return;
            }
            if (textBox1.Text != textBox2.Text)
            {
                MessageBox.Show("The confirm password doesnt match to password", "please Try again");
                return;
            }
            if (txtUsername.Text == "" || textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("There are missing details to your register", "please Try again", MessageBoxButtons.OK);
                return;
            }
            else
            {
                con.Open();
                string reg = "INSERT INTO tbl_users VALUES('" + txtUsername.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                cmd = new OleDbCommand(reg, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.Hide();
                new login().Show();
            }

        }
        private bool IsValidUsername(string username)
        {
            // Check username length and character composition
            if (username.Length < 6 || username.Length > 8)
                return false;

            int digitCount = username.Count(char.IsDigit);
            int letterCount = username.Count(char.IsLetter);

            if (digitCount > 2)
                return false;

            return true;
        }

        private bool IsValidPassword(string password)
        {
            // Check password length and character composition
            if (password.Length < 8 || password.Length > 10)
                return false;

            bool hasLetter = password.Any(char.IsLetter);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = System.Text.RegularExpressions.Regex.IsMatch(password, @"[@!$#]");

            if (!hasLetter || !hasDigit || !hasSpecialChar)
                return false;

            return true;
        }
        private bool IsValidId(string id)
        {
            // Check password length and character composition
            if (id.Length != 9)
                return false;

            bool hasLetter = id.Any(char.IsLetter);
           
            if (hasLetter)
                return false;

            return true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void txtbxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
           
                if (txtbxShowPassword.Checked)
                {
                    textBox1.PasswordChar = '\0';
                    textBox2.PasswordChar= '\0';


                }
                else
                {
                   textBox1.PasswordChar = '*';
                   textBox2.PasswordChar = '*';

                }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new login().Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
