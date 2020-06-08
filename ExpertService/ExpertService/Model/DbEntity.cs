using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class DbEntity : DbContext
    {
        public DbEntity() :
            base("name=ExperDBEntities")
        {
            Database.SetInitializer<DbEntity>(new DropCreateDatabaseIfModelChanges<DbEntity>());
        }
        public DbSet<Dosya> Dosya { get; set; }
        public DbSet<CalismaDonemi > CalismaDonemi { get; set; }
        public DbSet<ZamanCizelgesi> ZamanCizelgesi { get; set; }
        public DbSet<Odenenler> Odenenler { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Dosya>()
        //        .HasMany(x => x.CalismaDonemis);                ;
        //    base.OnModelCreating(modelBuilder); 
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
