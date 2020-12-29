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
      
        public WydachaKnig()
        {
            InitializeComponent();
        }

        private async void WydachaKnig_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kourseWorkDataSet.Katalog". При необходимости она может быть перемещена или удалена.
            this.katalogTableAdapter.Fill(this.kourseWorkDataSet.Katalog);
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");

            await sqlConnection.OpenAsync();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {

            /*if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) )
            {
                SqlCommand command = new SqlCommand("INSERT INTO Vudachia (ReadCardNum,InvNBook,LibNBook,DateVudachi,Condition,DateBack,ID_vudachi,RealDateBack) VALUES  (@NReader,@InvNB,@LibNB,@IDvudachi,@DateVud,@Condition,@DateBack,@RealDateBack)" +
                    "Update Book_Fond SET HowMany = @Ostachia", sqlConnection);
                command.Parameters.AddWithValue("NReader", textBox4.Text);
                command.Parameters.AddWithValue("InvNB", textBox3.Text);
                command.Parameters.AddWithValue("LibNB", textBox2.Text);
                command.Parameters.AddWithValue("IDvudachi", textBox1.Text);
                command.Parameters.AddWithValue("DateVud", textBox5.Text);
                command.Parameters.AddWithValue("DateBack", textBox6.Text);
                command.Parameters.AddWithValue("Ostachia", textBox9.Text);



                await command.ExecuteNonQueryAsync();

            }
            else*/
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
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
                    "Update Book_Fond SET HowMany = @Ostachia" +
                    "WHERE InvNBook = 'InvNB', LibNBook = 'LibNBook'", sqlConnection);
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
                SqlCommand command = new SqlCommand("SELECT HowMany FROM BookFond WHERE BookFond = '@BookFond'", sqlConnection);
                command.Parameters.AddWithValue("Ostachia", textBox9.Text);
            }
            else if (!string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                SqlCommand command = new SqlCommand("SELECT HowMany FROM BookFond WHERE BookFond = 1", sqlConnection);
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
            Doljniki show = new Doljniki();
            show.ShowDialog();
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



        private void button6_Click_1(object sender, EventArgs e)
        {
            Vudano_Vsiem show = new Vudano_Vsiem();
            show.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TopBook show = new TopBook();
            show.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WydachaKnigAdmin show = new WydachaKnigAdmin();
            show.ShowDialog();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox12.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE Vudachia SET Condition = '@Condition', RealDateBack = '@RealDateBack'" +
                    "WHERE ID_vudachi = '@IDvudachi' AND LibNBook = '@LibNB', ReadCardNum = '@NReader'" +
                    "Update Book_Fond SET HowMany = HowMany + 1" +
                    "WHERE LibNBook = '@LibNB'", sqlConnection);

                command.Parameters.AddWithValue("NReader", textBox12.Text);
                command.Parameters.AddWithValue("IDvudachi", textBox10.Text);
                command.Parameters.AddWithValue("LibNB", textBox11.Text);
                command.Parameters.AddWithValue("Condition", textBox7.Text);
                command.Parameters.AddWithValue("DateBack", textBox8.Text);


                await command.ExecuteNonQueryAsync();

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Sklad show = new Sklad();
            show.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Выдача_книг show = new Выдача_книг();
            show.ShowDialog();
        }
    }
}
