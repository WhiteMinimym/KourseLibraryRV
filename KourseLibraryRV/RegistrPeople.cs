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
                            dataSet.Tables["Readers"].Rows[rowIndex].Delete();

                            dataAdapter.Update(dataSet, "Readers");


                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;

                        DataRow row = dataSet.Tables["Readers"].NewRow();
                        row["ReadCardNum"] = dataGridView1.Rows[rowIndex].Cells["ReadCardNum"].Value;
                        row["Adress"] = dataGridView1.Rows[rowIndex].Cells["Adress"].Value;
                        row["CellPhone"] = dataGridView1.Rows[rowIndex].Cells["CellPhone"].Value;
                        row["Phone"] = dataGridView1.Rows[rowIndex].Cells["Phone"].Value;
                        row["FIO"] = dataGridView1.Rows[rowIndex].Cells["FIO"].Value;

                        dataSet.Tables["Readers"].Rows.Add(row);
                        dataSet.Tables["Readers"].Rows.RemoveAt(dataSet.Tables["Readers"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";

                        dataAdapter.Update(dataSet, "Readers");
                        NewRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        if (MessageBox.Show("Обновить строку?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int r = e.RowIndex;

                            dataSet.Tables["Readers"].Rows[r]["ReadCardNum"] = dataGridView1.Rows[r].Cells["ReadCardNum"].Value;
                            dataSet.Tables["Readers"].Rows[r]["Adress"] = dataGridView1.Rows[r].Cells["Adress"].Value;
                            dataSet.Tables["Readers"].Rows[r]["CellPhone"] = dataGridView1.Rows[r].Cells["CellPhone"].Value;
                            dataSet.Tables["Readers"].Rows[r]["Phone"] = dataGridView1.Rows[r].Cells["Phone"].Value;
                            dataSet.Tables["Readers"].Rows[r]["FIO"] = dataGridView1.Rows[r].Cells["FIO"].Value;


                            dataAdapter.Update(dataSet, "Readers");
                            dataGridView1.Rows[e.RowIndex].Cells[5].Value = "Delete";
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
                    dataGridView1[6, lastRaw] = linkCell;
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
                    dataGridView1[5, rowIndex] = linkCell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column_KeyPress);

            if (dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
        }
    }
}
