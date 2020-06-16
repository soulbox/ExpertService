using ExpertService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Migrations;
//using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL
{
    public class DbEntity : DbContext
    {
        public DbEntity()
            : base()
        {

           //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            //Database.Connection.ConnectionString="Data Source=213.142.144.186;Initial Catalog=ExpertDb;User Id=ExpertDb;Password=Power2020!;Integrated Security=true";
            //Database.SetInitializer<DbEntity>(new DropCreateDatabaseIfModelChanges<DbEntity>());
            //Database.SetInitializer<DbEntity>(new DropCreateDatabaseAlways<DbEntity>());

            //Database.SetInitializer<DbEntity>(new MigrateDatabaseToLatestVersion<DbEntity, Migrations.Configuration>());
        }

        public DbSet<UserTable> UserTables { get; set; }
        public DbSet<Dosya> Dosya { get; set; }
        public DbSet<CalismaDonemi> CalismaDonemi { get; set; }
        public DbSet<ZamanCizelgesi> ZamanCizelgesi { get; set; }
        public DbSet<UcretBilgileri> UcretBilgileri { get; set; }
        public DbSet<Talepler> Talepler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=213.142.144.186;Initial Catalog=ExpertDb;User Id=ExpertDb;Password=Power2020!;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Entity<Dosya>()
        //         .HasOptional(b => b.AnaDosya)
        //         .WithMany(b => b.EkDosya)
        //         .HasForeignKey(a => a.AnaDosyaID);

        //    base.OnModelCreating(modelBuilder);
        //}


    }
}
