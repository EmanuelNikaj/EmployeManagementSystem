using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_MS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void EmployeeBtn_Click(object sender, EventArgs e)
        {
            EmployeeDesign obj = new EmployeeDesign();
            obj.Show();
            this.Hide();
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            View obj = new View();
            obj.Show();
            this.Hide();
        }
    }
}
