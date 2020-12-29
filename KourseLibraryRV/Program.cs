using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KourseLibraryRV
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new WydachaKnigAdmin());

            // Application.Run(new UsersInfo());
            // Application.Run(new WydachaKnigAdmin());
            // Application.Run(new TableShow_Katalog_Admin());
            Application.Run(new Readers());

        }
    }
}
