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
    public partial class Sklad : Form
    {
        private SqlConnection sqlConnection = null;
        public Sklad()
        {
            InitializeComponent();
        }

        private void Sklad_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kourseWorkDataSet.Book_Fond". При необходимости она может быть перемещена или удалена.
            this.book_FondTableAdapter.Fill(this.kourseWorkDataSet.Book_Fond);
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {


            SqlCommand com = new SqlCommand("$SELECT * FROM Book_Fond WHERE HowMany = '0'", sqlConnection);

        }
    }
}
