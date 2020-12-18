using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace KourseLibraryRV
{
    public partial class TableShow_Katalog_Admin : Form
    {
        private SqlConnection sqlConnection = null;       
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        private bool NewRowAdding = false;
        public TableShow_Katalog_Admin()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try 
            {
                dataAdapter = new SqlDataAdapter("SELECT * , 'Delete' AS [Command] FROM Katalog ",sqlConnection);
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
                MessageBox.Show(ex.Message, "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void TableShow_Katalog_Admin_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            sqlConnection.Open();
            LoadData();
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

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }
            
        
       
        private void Column_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Katalog"].Rows[rowIndex].Delete();

                            dataAdapter.Update(dataSet, "Katalog");


                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;

                        DataRow row = dataSet.Tables["Katalog"].NewRow();
                        row["BookName"] = dataGridView1.Rows[rowIndex].Cells["BookName"].Value;
                        row["YearPublish"] = dataGridView1.Rows[rowIndex].Cells["YearPublish"].Value;
                        row["KolPages"] = dataGridView1.Rows[rowIndex].Cells["KolPages"].Value;
                        row["Theme"] = dataGridView1.Rows[rowIndex].Cells["Theme"].Value;
                        row["LibNBook"] = dataGridView1.Rows[rowIndex].Cells["LibNBook"].Value;
                        row["ID_Izd"] = dataGridView1.Rows[rowIndex].Cells["ID_Izd"].Value;
                        row["Price"] = dataGridView1.Rows[rowIndex].Cells["Price"].Value;

                        dataSet.Tables["Katalog"].Rows.Add(row);
                        dataSet.Tables["Katalog"].Rows.RemoveAt(dataSet.Tables["Katalog"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Delete";

                        dataAdapter.Update(dataSet, "Katalog");
                        NewRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        if (MessageBox.Show("Обновить строку?", "Обновление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int r = e.RowIndex;

                            dataSet.Tables["Katalog"].Rows[r]["BookName"] = dataGridView1.Rows[r].Cells["BookName"].Value;
                            dataSet.Tables["Katalog"].Rows[r]["YearPublish"] = dataGridView1.Rows[r].Cells["YearPublish"].Value;
                            dataSet.Tables["Katalog"].Rows[r]["KolPages"] = dataGridView1.Rows[r].Cells["KolPages"].Value;
                            dataSet.Tables["Katalog"].Rows[r]["Theme"] = dataGridView1.Rows[r].Cells["Theme"].Value;
                            dataSet.Tables["Katalog"].Rows[r]["LibNBook"] = dataGridView1.Rows[r].Cells["LibNBook"].Value;
                            dataSet.Tables["Katalog"].Rows[r]["ID_Izd"] = dataGridView1.Rows[r].Cells["ID_Izd"].Value;
                            dataSet.Tables["Katalog"].Rows[r]["Price"] = dataGridView1.Rows[r].Cells["Price"].Value;

                            dataAdapter.Update(dataSet, "Katalog");
                            dataGridView1.Rows[e.RowIndex].Cells[7].Value = "Delete";
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

        private void dataGridView1_UserAddedRow_1(object sender, DataGridViewRowEventArgs e)
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
                    dataGridView1[7, rowIndex] = linkCell;
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

            if (dataGridView1.CurrentCell.ColumnIndex == 5)
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
