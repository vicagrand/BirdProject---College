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
    public partial class showBirds : Form
    {
        private string textBoxValue;

        public showBirds(string valueFromFirstForm)
        {
            InitializeComponent();
            textBoxValue = valueFromFirstForm; // Store the value from the first form

        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void showBirds_Load(object sender, EventArgs e)
        {
            con.Open();
            if (textBoxValue.Equals("Female") || textBoxValue.Equals("Male"))
            {
                string gender = "SELECT * FROM tbl_birds WHERE gender='" + textBoxValue + "' ";
                cmd = new OleDbCommand(gender, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int serialNumber = int.Parse(dr["serialnumber"].ToString());
                    dataGridView1.Rows.Add(serialNumber, dr["speices"].ToString(), dr["subspeices"].ToString(), dr["gender"].ToString(), dr["dateofhatching"].ToString(), dr["cagenumber"].ToString(), dr["mothernumber"].ToString(), dr["fathernumber"].ToString(), dr["headcolor"].ToString(), dr["brestcolor"].ToString(), dr["bodycolor"].ToString());
                }
                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                dataGridView1.Refresh();

            }
            else if (textBoxValue.Equals("American Gouldian") || textBoxValue.Equals("European Gouldian") || textBoxValue.Equals("Australian Gouldian"))
            {
                string speices = "SELECT * FROM tbl_birds WHERE speices='" + textBoxValue + "' ";
                cmd = new OleDbCommand(speices, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int serialNumber = int.Parse(dr["serialnumber"].ToString());
                    dataGridView1.Rows.Add(serialNumber, dr["speices"].ToString(), dr["subspeices"].ToString(), dr["gender"].ToString(), dr["dateofhatching"].ToString(), dr["cagenumber"].ToString(), dr["mothernumber"].ToString(), dr["fathernumber"].ToString(), dr["headcolor"].ToString(), dr["brestcolor"].ToString(), dr["bodycolor"].ToString());
                }

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                dataGridView1.Refresh();

            }
            else
            {
                string dateofhatching = "SELECT * FROM tbl_birds WHERE dateofhatching='" + textBoxValue + "' ";
                cmd = new OleDbCommand(dateofhatching, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int serialNumber = int.Parse(dr["serialnumber"].ToString());
                    dataGridView1.Rows.Add(serialNumber, dr["speices"].ToString(), dr["subspeices"].ToString(), dr["gender"].ToString(), dr["dateofhatching"].ToString(), dr["cagenumber"].ToString(), dr["mothernumber"].ToString(), dr["fathernumber"].ToString(), dr["headcolor"].ToString(), dr["brestcolor"].ToString(), dr["bodycolor"].ToString());

                }

                dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                dataGridView1.Refresh();

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SearchBird().Show();
        }


    }
}