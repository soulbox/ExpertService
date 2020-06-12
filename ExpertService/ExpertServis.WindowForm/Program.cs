//using ExpertServis.Model;
using ExpertService.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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

            var aaaa = DbManager.DB.UserTables.Count();
            Thread.Sleep(1000);
            var user = DbManager.DB.UserTables
                //.Include(x => x.Dosyalar)
                //.Include(x => x.Dosyalar)
                //.Where(x)
                .Include(x => x.Dosyalar.Select(a => a.CalismaDonemis))
                .Include(x => x.Dosyalar.Select(a => a.UcretBilgileris))
                .Include(x => x.Dosyalar.Select(a => a.CalismaDonemis.Select(c => c.ZamanCizelgesis)))
                .Include(x => x.Dosyalar.Select(a => a.Taleplers))
                .Include(x => x.Dosyalar.Select(a => a.EkDosya))

                //.Include(x=>x.Dosyalar.Select(a=>a.))

                //.Include("Dosyalar.CalismaDonemis")
                //.Include("Dosyalar.UcretBilgileris")
                //.Include("Dosyalar.Taleplers")
                .FirstOrDefault();
            Application.Run(new Main(user));
        }
    }
}
