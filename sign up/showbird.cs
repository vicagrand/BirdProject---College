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
	public partial class showbird : Form
	{

		private string textBoxValue;
		string column1Value;
		string column2Value;
		string column3Value;
		string column4Value;
		string column5Value;
		string column6Value;
		string column7Value;
		string column8Value;
		string column9Value;
		string column10Value;
		string column11Value;

		public showbird(string valueFromFirstForm)
		{
			InitializeComponent();
			textBoxValue = valueFromFirstForm; // Store the value from the first form
		}
		OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
		OleDbCommand cmd = new OleDbCommand();
		OleDbDataAdapter da = new OleDbDataAdapter();

		private void showbird_Load(object sender, EventArgs e)
		{
			con.Open();
			string bird = "SELECT * FROM tbl_birds WHERE serialnumber= '" + textBoxValue + "' ";
			cmd = new OleDbCommand(bird, con);
			OleDbDataReader dr = cmd.ExecuteReader();
			if (dr.Read() == true)
			{
				column1Value = dr["serialnumber"].ToString();
				column2Value = dr["speices"].ToString();
				column3Value = dr["subspeices"].ToString();
				column4Value = dr["gender"].ToString();
				column5Value = dr["dateofhatching"].ToString();
				column6Value = dr["cagenumber"].ToString();
				column7Value = dr["mothernumber"].ToString();
				column8Value = dr["fathernumber"].ToString();
				column9Value = dr["headcolor"].ToString();
				column10Value = dr["brestcolor"].ToString();
				column11Value = dr["bodycolor"].ToString();


				label1.Text = $"Serial number: {column1Value}\nSpeices: {column2Value}\nSubspeices: {column3Value}\nGender: {column4Value}\nDate of hatching: {column5Value}\ncage number: {column6Value}\nMother serial number: {column7Value}\nFather serial number: {column8Value}\nHead color: {column9Value}\nBrest color: {column10Value}\nBody color: {column11Value}\n";
			}
			con.Close();

		}

		private void label1_Click(object sender, EventArgs e)
		{


		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Hide();
			new addSon(column1Value, column2Value, column3Value, column6Value, column4Value,column9Value,column10Value,column11Value).Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
			new MainPage().Show();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			this.Hide();
			new editBird(textBoxValue).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
			con.Open();
			string bird = "DELETE FROM tbl_birds WHERE serialnumber= '" + textBoxValue + "' ";
			cmd = new OleDbCommand(bird, con);
			OleDbDataReader dr = cmd.ExecuteReader();
			MessageBox.Show("This bird has been deleted.");
			con.Close();
		}
    }
}