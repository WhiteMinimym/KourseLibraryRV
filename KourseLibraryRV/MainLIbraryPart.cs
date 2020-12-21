using System;
using System.Windows.Forms;

namespace KourseLibraryRV
{
    public partial class MainLIbraryPart : Form
    {
        public MainLIbraryPart()
        {
            InitializeComponent();
        }

        private void MainLIbraryPart_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterLikeUserReg open = new EnterLikeUserReg();
            open.ShowDialog();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            Registration open = new Registration();
            open.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EnterLikeAdminReg open = new EnterLikeAdminReg();
            open.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
