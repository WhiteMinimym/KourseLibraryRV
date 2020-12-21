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
    public partial class EnterLikeAdmin : Form
    {
        public EnterLikeAdmin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TableShow_Katalog_Admin show = new TableShow_Katalog_Admin();
            show.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Readers show = new Readers();
            show.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RegistrPeople show = new RegistrPeople();
            show.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WydachaKnigAdmin show = new WydachaKnigAdmin();
            show.ShowDialog();
        }
    }
}
