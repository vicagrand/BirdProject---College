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
    public partial class showCages : Form
    {
        private string textBoxValue;
        public showCages(string valueFromFirstForm)
        {
            InitializeComponent();
            textBoxValue = valueFromFirstForm; // Store the value from the first form
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void showCages_Load(object sender, EventArgs e)
        {
               con.Open();
                {
                    string material = "SELECT * FROM tbl_cages WHERE material='" + textBoxValue + "' ";
                    cmd = new OleDbCommand(material, con);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                    dataGridView1.Rows.Add(dr["serialnumber"].ToString(), dr["length"].ToString(), dr["width"].ToString(), dr["height"].ToString(), dr["material"].ToString());
                    }
                    dataGridView1.Sort(dataGridView1.Columns["column1"], ListSortDirection.Ascending);

                }
        }  
    }
}
