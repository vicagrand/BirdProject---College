using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sign_up
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SearchBird().Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new add_bird().Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new add_cage().Show();
        }

    

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new SearchCage().Show();
        }
    }
}
