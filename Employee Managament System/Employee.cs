using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_MS
{
    public partial class EmployeeDesign : Form
    {
        public EmployeeDesign()
        {
            InitializeComponent();
            DisplayEmp();
        }

        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\emanu\OneDrive\Έγγραφα\EMS.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayEmp()
        {
            try
            {
                Con.Open();
                string Query = "select * from ETBL";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ResetBtn_Load(object sender, EventArgs e)
        {
            DisplayEmp();
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text ==" " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string Query = "INSERT into ETBL values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox2.SelectedItem.ToString() + "', '" + dateTimePicker1.Value.Date + "', '" + textBox4.Text + "', '" + comboBox1.SelectedItem.ToString() + "', '" + comboBox4.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Succesfully");
                    DisplayEmp();

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Employee Id");
                }
                else
                {
                    Con.Close();
                    string Query = "DELETE FROM ETBL WHERE EmpID = '" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(Query,Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Deleted Succesfully");
                    DisplayEmp();

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            textBox3.Text = " ";
            comboBox2.Text = " ";
            textBox4.Text = " ";
            comboBox4.Text = " ";

        }

       

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            Con.Open();
            string query = "UPDATE ETBL SET EmpName = @EmpName,EmpAdd = @EmpAdd,  EmpPos = @EmpPos ,EmpDob = @EmpDob, EmpPhone=@EmpPhone, EmpGender =@EmpGender, EmpEdu=@EmpEdu, WHERE EmpID= @EmpID";
            SqlCommand cmd = new SqlCommand(query, Con);

            cmd.Parameters.AddWithValue("@EmpName", textBox2.Text);
            cmd.Parameters.AddWithValue("@EmpAdd", textBox3.Text);
            cmd.Parameters.AddWithValue("@EmpPos", comboBox2.Text);
            cmd.Parameters.AddWithValue("@EmpDob", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@EmpPhone", textBox4.Text);
            cmd.Parameters.AddWithValue("@EmpGender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@EmpEdu", comboBox4.Text);
            cmd.Parameters.AddWithValue("@EmpID", textBox1.Text);

            cmd.ExecuteNonQuery();
            Con.Close();
            MessageBox.Show("Record Updated Succesfully");
            DisplayEmp();

               
        }
    }
}

namespace Employee
{
    class cs
    {
    }
}