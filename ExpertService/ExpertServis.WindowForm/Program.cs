
using System;
//using System.Data.Entity;
//using System.Data.Entity.Include;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ExpertService.DAL;
using ExpertService.Data;
using ExpertService.Model;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

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


            Thread.Sleep(1000);
            var db = DbManager.DB;
            var user = db.UserTable
                .Include(x => x.Dosya)
                    .ThenInclude(x => x.UcretBilgileris)
                .Include(x => x.Dosya)
                    .ThenInclude(x => x.Taleplers)
                .Include(x => x.Dosya )
                    .ThenInclude(x => x.CalismaDonemis )
                        .ThenInclude(x=>x.ZamanCizelgesis)
                .Include(x => x.Dosya)
                    .ThenInclude(x => x.EkDosya)
                    .FirstOrDefault();
            var an = TavanUcreti.TavanDonemleri;         
            Application.Run(new Main(user));


        }
    }
}
