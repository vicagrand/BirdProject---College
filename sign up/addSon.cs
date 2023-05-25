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
using System.Collections;

namespace sign_up
{
    public partial class addSon : Form
    {
        string num1;
        string specis1;
        string sub1;
        string cage1;
        string gender1;
        string head1;
        string brest1;
        string body1;

        public addSon()
        {

        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users1.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        public addSon(string num, string specis, string sub, string cage, string gender,string head,string brest,string body)
        {
            InitializeComponent();
            num1 = num;
            specis1 = specis;
            sub1 = sub;
            cage1 = cage;
            gender1 = gender;
            head1 = head;
            brest1 = brest;
            body1 = body;

        }

        private void addSon_Load(object sender, EventArgs e)
        {
            con.Open();
        }

     
        private bool IsValidNumber(string number)
        {

            return int.TryParse(number, out _);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] finalColors = new string[3];

            if (!IsValidNumber(textBox1.Text))
                {
                    MessageBox.Show("Invalid Serial number. please use just Numbers.");
                    return;
                }
                string parent = "SELECT * FROM tbl_birds WHERE serialnumber='" + textBox2.Text + "' ";
                cmd = new OleDbCommand(parent, con);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read() != true)
                {
                    MessageBox.Show("Your other parent serial number is wrong.");
                    return;
                }
                else
                {
                    if (gender1 == "Female")
                    {
                        finalColors= GetBabyColors(comboBox3.SelectedItem.ToString(), dr["headcolor"].ToString(), dr["brestcolor"].ToString(), dr["bodycolor"].ToString(), head1, brest1, body1);
                        string son = "INSERT INTO tbl_birds VALUES('" + textBox1.Text + "','" + specis1 + "','" + sub1 + "','" + comboBox3.SelectedItem + "','" + dateTimePicker1.Text + "','" + cage1 + "','" + num1 + "','" + textBox2.Text + "','" + finalColors[0] + "','" + finalColors[1] + "','" + finalColors[2] + "')";
                        cmd = new OleDbCommand(son, con);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                    finalColors = GetBabyColors(comboBox3.SelectedItem.ToString(),head1,brest1,body1, dr["headcolor"].ToString(), dr["brestcolor"].ToString(), dr["bodycolor"].ToString());
                    string son = "INSERT INTO tbl_birds VALUES('" + textBox1.Text + "','" + specis1 + "','" + sub1 + "','" + comboBox3.SelectedItem + "','" + dateTimePicker1.Text + "','" + cage1 + "','" + num1 + "','" + textBox2.Text + "','" + finalColors[0] + "','" + finalColors[1] + "','" + finalColors[2] + "')";
                    cmd = new OleDbCommand(son, con);
                        cmd.ExecuteNonQuery();
                    }

                }
                this.Hide();
                new MainPage().Show();
                con.Close();

            
        }
        public string[] GetBabyColors(string babyGender, string fatherHead, string fatherBreast, string fatherBody, string motherHead, string motherBreast, string motherBody)
        {
            string[] finalColors = new string[3];
            Random random = new Random();
            string[] offspringHeadF = { };
            string[] offspringHeadM = { };

            if ((fatherHead == "Red" && motherHead == "Yellow"))
            {
                offspringHeadM = new string[] { "Red", "Yellow" };
                offspringHeadF = new string[] { "Yellow", "Red" };
            }
            else if ((fatherHead == "Yellow" && motherHead == "Red"))
            {
                offspringHeadM = new string[] { "Red", "Yellow" };
                offspringHeadF = new string[] { "Yellow", "Red" };
            }
            else if ((fatherHead == "Red" && motherHead == "Black"))
            {
                offspringHeadM = new string[] { "Red", "Black" };
                offspringHeadF = new string[] { "Red" };
            }
            else if ((fatherHead == "Black" && motherHead == "Red"))
            {
                offspringHeadM = new string[] { "Red", "Black" };
                offspringHeadF = new string[] { "Black" };
            }
            else if ((fatherHead == "Black" && motherHead == "Yellow"))
            {
                offspringHeadM = new string[] { "Red", "Black", "Yellow" };
                offspringHeadF = new string[] { "Yellow", "Black" };
            }
            else if ((fatherHead == "Yellow" && motherHead == "Black"))
            {
                offspringHeadM = new string[] { "Red", "Yellow", "Black" };
                offspringHeadF = new string[] { "Yellow", "Red" };
            }
            else
            {
                offspringHeadF = new string[] { motherHead };
                offspringHeadM = new string[] { motherHead };
            }

            string[] offspringBreastF = { };
            string[] offspringBreastM = { };

            if ((fatherBreast == "Purple" && motherBreast == "White"))
            {
                offspringBreastM = new string[] { "Purple", "White" };
                offspringBreastF = new string[] { "Purple", "White" };
            }
            else if ((fatherBreast == "White" && motherBreast == "Purple"))
            {
                offspringBreastM = new string[] { "Purple", "White" };
                offspringBreastF = new string[] { "Purple", "White" };
            }
            else if ((fatherBreast == "Purple" && motherBreast == "Lilac"))
            {
                offspringBreastM = new string[] { "Purple", "Lilac" };
                offspringBreastF = new string[] { "Purple", "Lilac" };
            }
            else if ((fatherBreast == "Lilac" && motherBreast == "Purple"))
            {
                offspringBreastM = new string[] { "Purple", "Lilac" };
                offspringBreastF = new string[] { "Purple", "Lilac" };
            }
            else if ((fatherBreast == "White" && motherBreast == "Lilac"))
            {
                offspringBreastM = new string[] { "Lilac", "White" };
                offspringBreastF = new string[] { "Lilac", "White" };
            }
            else if ((fatherBreast == "Lilac" && motherBreast == "White"))
            {
                offspringBreastM = new string[] { "Lilac", "White" };
                offspringBreastF = new string[] { "Lilac", "White" };
            }
            else
            {
                offspringBreastF = new string[] { motherBreast };
                offspringBreastM = new string[] { motherBreast };
            }

            ArrayList colors = new ArrayList();
            string[] offspringBodyF = { };
            string[] offspringBodyM = { };

            if ((fatherBody == "Green" && motherBody == "Yellow"))
            {
                offspringBodyM = new string[] { "Yellow" };
                offspringBodyF = new string[] { "Green" };
            }
            else if ((fatherBody == "Yellow" && motherBody == "Green"))
            {
                offspringBodyM = new string[] { "Yellow" };
                offspringBodyF = new string[] { "Yellow" };
            }
            else if ((fatherBody == "Green" && motherBody == "Blue"))
            {
                offspringBodyM = new string[] { "Green", "Blue" };
                offspringBodyF = new string[] { "Green", "Blue" };
            }
            else if ((fatherBody == "Blue" && motherBody == "Green"))
            {
                offspringBodyM = new string[] { "Green", "Blue" };
                offspringBodyF = new string[] { "Green", "Blue" };
            }
            else if ((fatherBody == "Blue" && motherBody == "Yellow"))
            {
                offspringBodyM = new string[] { "Yellow", "Blue" };
                offspringBodyF = new string[] { "Green", "Blue" };
            }
            else if ((fatherBody == "Yellow" && motherBody == "Blue"))
            {
                offspringBodyM = new string[] { "Yellow", "Blue" };
                offspringBodyF = new string[] { "Yellow", "Blue" };
            }//silver
            else if ((fatherBody == "Silver" && motherBody == "Blue"))
            {
                offspringBodyM = new string[] { "Blue" };
                offspringBodyF = new string[] { "Silver" };
            }
            else if ((fatherBody == "Silver" && motherBody == "Yellow"))
            {
                offspringBodyM = new string[] { "Yellow", "Blue" };
                offspringBodyF = new string[] { "Yellow", "Blue" };
            }
            else if ((fatherBody == "Silver" && motherBody == "Green"))
            {
                offspringBodyM = new string[] { "Yellow", "Blue" };
                offspringBodyF = new string[] { "Yellow", "Blue" };
            }
            else if ((fatherBody == "Green" && motherBody == "Silver"))
            {
                offspringBodyM = new string[] { "Yellow", "Blue" };
                offspringBodyF = new string[] { "Green", "Blue" };
            }
            else if ((fatherBody == "Blue" && motherBody == "Silver"))
            {
                offspringBodyM = new string[] { "Blue" };
                offspringBodyF = new string[] { "Blue" };
            }
            else if ((fatherBody == "Yellow" && motherBody == "Silver"))
            {
                offspringBodyM = new string[] { "Yellow", "Blue" };
                offspringBodyF = new string[] { "Yellow", "Blue" };
            }
            else
            {
                offspringBodyF = new string[] { motherBody };
                offspringBodyM = new string[] { motherBody };
            }

            if (babyGender == "Male")
            {
                colors.Add(offspringHeadM);
                colors.Add(offspringBreastM);
                colors.Add(offspringBodyM);
            }
            else if (babyGender == "Female")
            {
                colors.Add(offspringHeadF);
                colors.Add(offspringBreastF);
                colors.Add(offspringBodyF);
            }

            int i = 0;
            foreach (string[] partColor in colors)
            {
                finalColors[i] = partColor[random.Next(partColor.Length)];
                i++;
            }
            return finalColors;
        }
    }
}