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
    public partial class UsersInfo : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;

        public UsersInfo()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * , 'Delete' AS [Command] FROM Katalog ", sqlConnection);
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
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ReLoadData()
        {
            try
            {
                dataSet.Tables["Katalog"].Clear();
                dataAdapter.Fill(dataSet, ("Katalog"));
                dataGridView1.DataSource = dataSet.Tables["Katalog"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UsersInfo_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
