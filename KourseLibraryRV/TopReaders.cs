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
    public partial class TopReaders : Form
    {
        public TopReaders()
        {
            InitializeComponent();
        }

        private async void TopReaders_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            await sqlConnection.OpenAsync();

            string query = "SELECT ReadCardNum, FIO FROM Readers  WHERE ReadCardNum = (SELECT Top 1  ReadCardNum FROM Vudachia )";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
               
            }

            reader.Close();
            sqlConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

    }
}

