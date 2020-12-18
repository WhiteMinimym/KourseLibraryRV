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
    public partial class WydachaKnig : Form
    {
        private SqlConnection sqlConnection = null;
       // private SqlCommand SqlCommand = null;
        
        public WydachaKnig()
        {
            InitializeComponent();
        }

        private async void WydachaKnig_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            
            await sqlConnection.OpenAsync();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Vudachia (ReadCardNum,InvNBook,LibNBook,DateVudachi,Condition,DateBack,ID_vudachi,RealDateBack) VALUES  (@NReader,@InvNB,@LibNB,@IDvudachi,@DateVud,@Condition,@DateBack,@RealDateBack)", sqlConnection);
                command.Parameters.AddWithValue("NReader", textBox4.Text);
                command.Parameters.AddWithValue("InvNB", textBox3.Text);
                command.Parameters.AddWithValue("LibNB", textBox2.Text);
                command.Parameters.AddWithValue("IDvudachi", textBox1.Text);
                command.Parameters.AddWithValue("DateVud", textBox5.Text);
                command.Parameters.AddWithValue("Condition", textBox7.Text);
                command.Parameters.AddWithValue("DateBack", textBox6.Text);
                command.Parameters.AddWithValue("RealDateBack", textBox8.Text);


                await command.ExecuteNonQueryAsync();

            }
            else if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) &&
                !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) &&
                !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) &&
                !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Vudachia (ReadCardNum,InvNBook,LibNBook,DateVudachi,Condition,DateBack,ID_vudachi,RealDateBack) VALUES  (@NReader,@InvNB,@LibNB,@IDvudachi,@DateVud,Null,@DateBack,Null)" +
                    "Update Book_Fond SET HowMany = @Ostachia", sqlConnection);
                command.Parameters.AddWithValue("NReader", textBox4.Text);
                command.Parameters.AddWithValue("InvNB", textBox3.Text);
                command.Parameters.AddWithValue("LibNB", textBox2.Text);
                command.Parameters.AddWithValue("IDvudachi", textBox1.Text);
                command.Parameters.AddWithValue("DateVud", textBox5.Text);
                command.Parameters.AddWithValue("Condition", textBox7.Text);
                command.Parameters.AddWithValue("DateBack", textBox6.Text);
                command.Parameters.AddWithValue("RealDateBack", textBox8.Text);
                command.Parameters.AddWithValue("Ostachia", textBox9.Text);

                await command.ExecuteNonQueryAsync();

            }
            else if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("SELECT HowMany FROM BookFond WHERE BookFond = '@BookFond' AND BookFond = '1'", sqlConnection);
                command.Parameters.AddWithValue("Ostachia", textBox9.Text);

                label13.Text = "Когда на складе осталась одна книга, то её не можем выдать";
            }
            else
            {
                label10.Visible = true;
                label10.Text = "Все поля должны быть заполнены! Впишите значение Null в колонку 'Состояние' если книгу не вернули";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Выдача_книг show = new Выдача_книг();
            show.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT ReadCardNum, FIO FROM Readers  WHERE ReadCardNum = (SELECT ReadCardNum FROM Vudachia  WHERE RealDateBack IS NULL) ";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[1]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                //data[data.Count - 1][2] = reader[2].ToString();
                //data[data.Count - 1][3] = reader[3].ToString();
                //data[data.Count - 1][4] = reader[4].ToString();
                //data[data.Count - 1][5] = reader[5].ToString();
                //data[data.Count - 1][6] = reader[6].ToString();
            }

            reader.Close();
            sqlConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sklad show = new Sklad();
            show.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TopReaders show = new TopReaders();
            show.ShowDialog();
        }
    }
}
