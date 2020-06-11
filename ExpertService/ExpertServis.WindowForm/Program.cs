//using ExpertServis.Model;
using ExpertService.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ExpertServis.WindowForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var gg = DbManager.DB.Dosya.Count();
            Application.Run(new Main());
        }
    }
}
