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
    public partial class Выдача_книг : Form
    {
       // private SqlConnection sqlConnection = null;
       
        public Выдача_книг()
        {
            InitializeComponent();
           
        }

        private void Выдача_книг_Load(object sender, EventArgs e)
        {
             LoadData();
        }
        private void LoadData()
        {
            string connectString = @"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(connectString);
            sqlConnection.Open();
            string query = "SELECT * FROM Vudachia";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[8]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
                data[data.Count - 1][7] = reader[7].ToString();
            }

            reader.Close();
            sqlConnection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
    }
}
