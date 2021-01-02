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
    public partial class RegistrPeople : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private bool NewRowAdding = false;
        public RegistrPeople()
        {
            InitializeComponent();
        }

        private void RegistrPeople_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source = MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dataAdapter = new SqlDataAdapter("SELECT * , 'Delete' AS [Command] FROM  Autorization", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(dataAdapter);


                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetDeleteCommand();
                sqlBuilder.GetUpdateCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, ("Autorization"));
                dataGridView1.DataSource = dataSet.Tables["Autorization"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
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
                dataSet.Tables["Autorization"].Clear();
                dataAdapter.Fill(dataSet, ("Autorization"));
                dataGridView1.DataSource = dataSet.Tables["Autorization"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Autorization"].Rows[rowIndex].Delete();

                            dataAdapter.Update(dataSet, "Autorization");


                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;

                        DataRow row = dataSet.Tables["Readers"].NewRow();
                        row["Username"] = dataGridView1.Rows[rowIndex].Cells["Username"].Value;
                        row["Pass"] = dataGridView1.Rows[rowIndex].Cells["Pass"].Value;
                        row["Ogranichenia"] = dataGridView1.Rows[rowIndex].Cells["Ogranichenia"].Value;

                        dataSet.Tables["Autorization"].Rows.Add(row);
                        dataSet.Tables["Autorization"].Rows.RemoveAt(dataSet.Tables["Autorization"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";

                        dataAdapter.Update(dataSet, "Autorization");
                        NewRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        if (MessageBox.Show("Обновить строку?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int r = e.RowIndex;

                            dataSet.Tables["Autorization"].Rows[r]["Username"] = dataGridView1.Rows[r].Cells["Username"].Value;
                            dataSet.Tables["Autorization"].Rows[r]["Pass"] = dataGridView1.Rows[r].Cells["Pass"].Value;
                            dataSet.Tables["Autorization"].Rows[r]["Ogranichenia"] = dataGridView1.Rows[r].Cells["Ogranichenia"].Value;

                            dataAdapter.Update(dataSet, "Autorization");
                            dataGridView1.Rows[e.RowIndex].Cells[3].Value = "Delete";
                        }
                    }

                    ReLoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

            try
            {
                if (NewRowAdding == false)
                {
                    NewRowAdding = true;
                    int lastRaw = dataGridView1.Rows.Count - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRaw];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, lastRaw] = linkCell;
                    row.Cells["Command"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (NewRowAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[3, rowIndex] = linkCell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void Column_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        //    {
        //        e.Handled = true;
        //    }
        //}
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }
    }
}
