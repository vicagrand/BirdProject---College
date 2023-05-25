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
    public partial class ShowCage : Form
    {
        private string textBoxValue;

        public ShowCage(string valueFromFirstForm)
        {
            InitializeComponent();
            textBoxValue = valueFromFirstForm; // Store the value from the first form
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void ShowCage_Load(object sender, EventArgs e)
        {
            con.Open();
            string cage = "SELECT * FROM tbl_cages WHERE serialnumber= '" + textBoxValue + "' ";
            cmd = new OleDbCommand(cage, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                string column1Value = dr["serialnumber"].ToString();
                string column2Value = dr["length"].ToString();
                string column3Value = dr["width"].ToString();
                string column4Value = dr["height"].ToString();
                string column5Value = dr["material"].ToString();



                label1.Text = $"Cage Serial number: {column1Value}\nlength: {column2Value}\nwidth: {column3Value}\nheight: {column4Value}\nmaterial: {column5Value}\n";
                showConectedBirds();
                con.Close();
            }
            else
            {
                MessageBox.Show("Cage with serial number " + textBoxValue + " not found.");
            }
        }

        private void showConectedBirds()
        {
            string cage = "SELECT * FROM tbl_birds WHERE cagenumber='" + textBoxValue + "' ";
            cmd = new OleDbCommand(cage, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int serialNumber = int.Parse(dr["serialnumber"].ToString());
                dataGridView2.Rows.Add(serialNumber, dr["speices"].ToString(), dr["subspeices"].ToString(), dr["gender"].ToString(), dr["dateofhatching"].ToString(), dr["cagenumber"].ToString(), dr["mothernumber"].ToString(), dr["fathernumber"].ToString(), dr["headcolor"].ToString(), dr["brestcolor"].ToString(), dr["bodycolor"].ToString());
            }
            dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);
            dataGridView2.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string bird = "DELETE FROM tbl_cages WHERE serialnumber= '" + textBoxValue + "' ";
            cmd = new OleDbCommand(bird, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            MessageBox.Show("This cage has been deleted.");
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SearchCage().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new editCage(textBoxValue).Show();
        }
    }
}