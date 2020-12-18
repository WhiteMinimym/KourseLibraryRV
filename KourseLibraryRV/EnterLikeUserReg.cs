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
    public partial class EnterLikeUserReg : Form
    {
        SqlConnection sqlConnection;
        public EnterLikeUserReg()
        {
            InitializeComponent();
        }

        private async void user_Load(object sender, EventArgs e)
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
                SqlCommand command = new 
                SqlCommand("SELECT (SELECT Username,Pass,Ogranichenia FROM Autorization WHERE Username = '@Name' AND Pass = '@Pass') FROM Autorization WHERE Ogranichenia IN 'user'", sqlConnection);

                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Pass", textBox2.Text);
                

                EnterLikeUser show = new EnterLikeUser();
                show.ShowDialog();
                await command.ExecuteNonQueryAsync();
            } 
            else
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Autorization WHERE (SELECT Username,Pass,Ogranichenia FROM Autorization WHERE Username = '@Name' AND Pass = '@Pass' AND Ogranichenia='user') IS NULL", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Pass", textBox2.Text);
                

                label3.Visible = true;
                label3.Text = "Заполните поля";
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}