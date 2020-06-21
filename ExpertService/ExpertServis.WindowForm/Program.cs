
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
using static ExpertService.DAL.DbManager;

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
         
            var an = TavanUcreti.TavanDonemleri;
            var b = AsgariUcret.AsgariDonemleri;
            var user = UnitWork.UserRepo.GetWithDosya(x => x.Id == 1);
            Application.Run(new Main(user));


        }
    }
}
