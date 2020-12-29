using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KourseLibraryRV
{
    public  partial class Registration : Form
    {
        SqlConnection sqlConnection;
       


        public Registration()
        {
            InitializeComponent();
        }
        private async void Registration_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label3.Visible)
                label3.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO [Autorization] (Username,Pass,Ogranichenia) VALUES  (@Name,@Pass,@Something)", sqlConnection);

                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Pass", textBox2.Text);
                command.Parameters.AddWithValue("Something", textBox3.Text);

                await command.ExecuteNonQueryAsync();
                label3.Visible = true;
                label3.Text = "Закройте форму";
            }
            else
            {
                label3.Visible = true;

                label3.Text = "Все поля должны быть заполнены!";
            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {   
           
            this.Close();
        }
    }
}
