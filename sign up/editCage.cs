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
    public partial class editCage : Form
    {
        string number;
        public editCage()
        {
            
        }

        public editCage(string value)
        {
            InitializeComponent();
            number = value;
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void editCage_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cage= "UPDATE tbl_cages SET serialnumber='" + textBox1.Text + "',length='" + textBox2.Text+ "',width='" + textBox3.Text + "',height='" + textBox4.Text + "',material='" + comboBox2.SelectedItem + "' where serialnumber='" + number + "'"; ;
            cmd = new OleDbCommand(cage, con);
            cmd.ExecuteNonQuery();
            DialogResult dialogResult = MessageBox.Show("Your cage details updated.");
            this.Hide();
            new MainPage().Show();
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
