using ExpertService.Model.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class DbEntity : DbContext
    {
        public DbEntity()
            : base("name=ExperDBEntities")
        {


            //Database.Connection.ConnectionString="Data Source=213.142.144.186;Initial Catalog=ExpertDb;User Id=ExpertDb;Password=Power2020!;Integrated Security=true";
            //Database.SetInitializer<DbEntity>(new DropCreateDatabaseIfModelChanges<DbEntity>());
            Database.SetInitializer<DbEntity>(new DropCreateDatabaseAlways <DbEntity>());

            Database.SetInitializer<DbEntity>(new MigrateDatabaseToLatestVersion<DbEntity, Migrations.Configuration>());
        }

        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<Dosya> Dosya { get; set; }
        public DbSet<CalismaDonemi> CalismaDonemi { get; set; }
        public DbSet<ZamanCizelgesi> ZamanCizelgesi { get; set; }
        public DbSet<UcretBilgileri> UcretBilgileri { get; set; }
        public DbSet<Talepler> Talepler { get; set; }



        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Dosya>()
        //        .HasMany(x => x.CalismaDonemis);                ;
        //    base.OnModelCreating(modelBuilder); 
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Dosya>()
            //    .HasMany(x => x.EkDosya)
            //    .WithRequired(x => x.AnaDosya)
            //    .HasForeignKey(x => x.AnaDosyaID);
            base.OnModelCreating(modelBuilder);
        }


    }
}
