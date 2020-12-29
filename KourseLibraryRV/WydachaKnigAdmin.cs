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
    public partial class WydachaKnigAdmin : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private bool NewRowAdding = false;

        public WydachaKnigAdmin()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            try
            {

                dataAdapter = new SqlDataAdapter("SELECT * , 'Delete' AS [Command] FROM Vudachia ", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(dataAdapter);


                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetDeleteCommand();
                sqlBuilder.GetUpdateCommand();

                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, ("Vudachia"));
                dataGridView1.DataSource = dataSet.Tables["Vudachia"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[8, i] = linkCell;
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
                dataSet.Tables["Vudachia"].Clear();
                dataAdapter.Fill(dataSet, ("Vudachia"));
                dataGridView1.DataSource = dataSet.Tables["Vudachia"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[8, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WydachaKnigAdmin_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }
        private void Column_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 8)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Vudachia"].Rows[rowIndex].Delete();
                            dataAdapter.Update(dataSet, "Vudachia"); 
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Vudachia"].NewRow();

                        row["ReadCardNum"] = dataGridView1.Rows[rowIndex].Cells["ReadCardNum"].Value;
                        row["InvNBook"] = dataGridView1.Rows[rowIndex].Cells["InvNBook"].Value;
                        row["LibNBook"] = dataGridView1.Rows[rowIndex].Cells["LibNBook"].Value;
                        row["DateVudachi"] = dataGridView1.Rows[rowIndex].Cells["DateVudachi"].Value;
                        row["Condition"] = dataGridView1.Rows[rowIndex].Cells["Condition"].Value;
                        row["DateBack"] = dataGridView1.Rows[rowIndex].Cells["DateBack"].Value;
                        row["ID_vudachi"] = dataGridView1.Rows[rowIndex].Cells["ID_vudachi"].Value;
                        row["ID_vudachi"] = dataGridView1.Rows[rowIndex].Cells["ID_vudachi"].Value;

                        dataSet.Tables["Vudachia"].Rows.Add(row);
                        dataSet.Tables["Vudachia"].Rows.RemoveAt(dataSet.Tables["Vudachia"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = "Delete";

                        dataAdapter.Update(dataSet, "Vudachia");
                        NewRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        if (MessageBox.Show("Обновить строку?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int r = e.RowIndex;
                            
                            dataSet.Tables["Vudachia"].Rows[r]["ReadCardNum"] = dataGridView1.Rows[r].Cells["ReadCardNum"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["InvNBook"] = dataGridView1.Rows[r].Cells["InvNBook"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["LibNBook"] = dataGridView1.Rows[r].Cells["LibNBook"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["DateVudachi"] = dataGridView1.Rows[r].Cells["DateVudachi"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["Condition"] = dataGridView1.Rows[r].Cells["Condition"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["DateBack"] = dataGridView1.Rows[r].Cells["DateBack"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["ID_vudachi"] = dataGridView1.Rows[r].Cells["ID_vudachi"].Value;
                            dataSet.Tables["Vudachia"].Rows[r]["RealDateBack"] = dataGridView1.Rows[r].Cells["RealDateBack"].Value;

                            dataAdapter.Update(dataSet, "Vudachia");
                            dataGridView1.Rows[e.RowIndex].Cells[8].Value = "Delete";
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
                    dataGridView1[8, lastRaw] = linkCell;
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
                    dataGridView1[8, rowIndex] = linkCell;
                    editingRow.Cells["Command"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(Column_KeyPress);
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex == 6)
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
