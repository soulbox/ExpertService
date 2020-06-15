
using System;
using System.Data.Entity;
//using System.Data.Entity.Include;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using ExpertService.DAL;
using ExpertService.Data;
using ExpertService.Model;

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

            var aaaa = DbManager.DB.UserTables.FirstOrDefault();
            Thread.Sleep(1000);
            var anadosya = DbManager.DB.Dosya.Where(x => x.AnaDosyaID == null).ToList();
            var user = DbManager.DB.UserTables 
                .Include(x => x.Dosyalar.Select(a => a.CalismaDonemis))
                .Include(x => x.Dosyalar.Select(a => a.UcretBilgileris))
                .Include(x => x.Dosyalar.Select(a => a.CalismaDonemis.Select(c => c.ZamanCizelgesis)))
                .Include(x => x.Dosyalar.Select(a => a.Taleplers))
                .Include(x => x.Dosyalar.Select(a => a.EkDosya))
                //.Where(x => x.Dosyalar.Any (a => a.AnaDosyaID==null))
                //.Select(x => new
                //{
                //    x,
                //    Dosyalar = x.Dosyalar.Where(a => a.AnaDosyaID == null)
                //})
                .FirstOrDefault();
            user.Dosyalar = user.Dosyalar.Where(x => x.AnaDosyaID == null).ToList();
            var an = TavanUcreti.TavanDonemleri;
            Application.Run(new Main(user));


        }
    }
}
