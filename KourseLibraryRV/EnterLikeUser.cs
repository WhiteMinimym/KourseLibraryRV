using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KourseLibraryRV
{
    public partial class EnterLikeUser : Form
    {
        public EnterLikeUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableShow_Katalog show = new TableShow_Katalog();
            show.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WydachaKnig show = new WydachaKnig();
            show.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Readers show = new Readers();
            show.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WydachaKnigAdmin show = new WydachaKnigAdmin();
            show.ShowDialog();
        }

       
        private void EnterLikeUser_Load(object sender, EventArgs e)
        {

        }
    }
}
