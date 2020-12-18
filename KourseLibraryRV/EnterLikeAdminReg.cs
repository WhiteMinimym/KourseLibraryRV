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
    public partial class EnterLikeAdminReg : Form
    {
        private SqlConnection sqlConnection;

        public EnterLikeAdminReg()
        {
            InitializeComponent();
        }

        private async void EnterLikeAdminReg_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (label5.Visible)
                label5.Visible = false;
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {

                SqlCommand command = new SqlCommand("SELECT (SELECT [Username],[Pass],[Ogranichenia] FROM [Autorization] WHERE [Username] = '@Name' AND [Pass] = '@Pass' AND Ogranichenia = 'admin') FROM Autorization", sqlConnection);

                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Pass", textBox2.Text);


                EnterLikeAdmin show = new EnterLikeAdmin();
                show.ShowDialog();
                await command.ExecuteNonQueryAsync();
            }

            else
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Autorization WHERE (SELECT Username,Pass,Ogranichenia FROM Autorization WHERE Username = '@Name' AND Pass = '@Pass' AND Ogranichenia='admin') IS NULL", sqlConnection);
                command.Parameters.AddWithValue("Name", textBox1.Text);
                command.Parameters.AddWithValue("Pass", textBox2.Text);
               

                label5.Visible = true;
                label5.Text = "Заполните поля";
            }
        }
    }
}
