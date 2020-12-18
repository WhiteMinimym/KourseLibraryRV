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
    
    public partial class TableShow_Katalog : Form
    {
        public TableShow_Katalog()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string connectString = @"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True";
            SqlConnection myConnection = new SqlConnection(connectString);
            myConnection.Open();
            string query = "SELECT * FROM Katalog ";
            SqlCommand command = new SqlCommand(query, myConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[7]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();
                data[data.Count - 1][6] = reader[6].ToString();
            }

            reader.Close();
            myConnection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        /*  одинаково
          private void LoadData()
        {
            try 
            {
                dataAdapter = new SqlDataAdapter("SELECT * , 'Delete' AS [Delete] FROM Katalog",sqlConnection);
                sqlBuilder = new SqlCommandBuilder(dataAdapter);


                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetDeleteCommand();
                sqlBuilder.GetUpdateCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, ("Katalog"));
                dataGridView1.DataSource = dataSet.Tables["Katalog"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[6, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }*/

        private void TableShow_Load(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}