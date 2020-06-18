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


            Database.EnsureDeleted();
            //Database.
            Database.EnsureCreated();
            Database.Migrate();

            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.AutoDetectChangesEnabled = false;
            //Configuration.ProxyCreationEnabled = false;
            //Database.Connection.ConnectionString="Data Source=213.142.144.186;Initial Catalog=ExpertDb;User Id=ExpertDb;Password=Power2020!;Integrated Security=true";
            //Database.SetInitializer<DbEntity>(new DropCreateDatabaseIfModelChanges<DbEntity>());
            //Database.SetInitializer<DbEntity>(new DropCreateDatabaseAlways<DbEntity>());

            //Database.SetInitializer<DbEntity>(new MigrateDatabaseToLatestVersion<DbEntity, Migrations.Configuration>());
        }
       
        public DbSet<UserTable> UserTable { get; set; }
        public DbSet<Dosya> Dosya { get; set; }
        public DbSet<CalismaDonemi> CalismaDonemi { get; set; }
        public DbSet<ZamanCizelgesi> ZamanCizelgesi { get; set; }
        public DbSet<UcretBilgileri> UcretBilgileri { get; set; }
        public DbSet<Talepler> Talepler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=213.142.144.186;Initial Catalog=ExpertDb;User Id=ExpertDb;Password=Power2020!;Integrated Security=false");
            optionsBuilder.EnableSensitiveDataLogging();
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            TestSeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        void TestSeedData(ModelBuilder modelBuilder)
        {

            #region User
            modelBuilder.Entity<UserTable>()
            .HasData(
        new UserTable()
        {
            Id = 1,
            UserName = "admin",
            Password = "admin",
            Adres = "admin",
            Name = "admin",
            Surname = "admin",
            Tel = "admin",
        });
            #endregion
            #region Dosyalar
            modelBuilder.Entity<Dosya>()
           .HasData(new Dosya()
           {
               Id = 1,
               UserId = 1,
               Adı = "Kadir",
               DavaTarihi = new DateTime(2019, 01, 31),
               Açıklama = "DENEME1",
               DosyaNo = "GLF20200001",
               Soyadı = "Aygün1",
               ZamanAsimi = false,
               TCNO = 0
           },
        new Dosya()
        {
            Id = 2,
            UserId = 1,
            AnaDosyaID = 1,
            Adı = "Kadir",
            DavaTarihi = new DateTime(2019, 02, 28),
            Açıklama = "DENEME2",
            DosyaNo = "GLF20200002",
            Soyadı = "Aygün2",
            ZamanAsimi = false,
            TCNO = 0

        },
        new Dosya()
        {
            Id = 3,
            UserId = 1,
            AnaDosyaID = 1,
            Adı = "Kadir",
            DavaTarihi = new DateTime(2019, 02, 28),
            Açıklama = "DENEME3",
            DosyaNo = "GLF20200003",
            Soyadı = "Aygün3",
            ZamanAsimi = false,
            TCNO = 0

        },
        new Dosya()
        {
            Id = 4,
            UserId = 1,
            AnaDosyaID = 2,
            Adı = "Kadir",
            DavaTarihi = new DateTime(2019, 02, 28),

            Açıklama = "DENEME4",
            DosyaNo = "GLF20200004",
            Soyadı = "Aygün4",
            ZamanAsimi = false,
            TCNO = 0

        },
        new Dosya()
        {
            Id = 5,
            UserId = 1,
            AnaDosyaID = 2,
            Adı = "Kadir",
            DavaTarihi = new DateTime(2019, 02, 28),

            Açıklama = "DENEME5",
            DosyaNo = "GLF20200005",
            Soyadı = "Aygün5",
            ZamanAsimi = false,
            TCNO = 0

        },
        new Dosya()
        {
            Id = 6,
            UserId = 1,
            //AnaDosyaID = 4,
            Adı = "Kadir",
            DavaTarihi = new DateTime(2019, 02, 28),

            Açıklama = "DENEME6",
            DosyaNo = "GLF20200006",
            Soyadı = "Aygün6",
            ZamanAsimi = false,
        },
        new Dosya()
        {
            Id = 7,
            UserId = 1,
            AnaDosyaID = 5,
            Adı = "Kadir",
            DavaTarihi = new DateTime(2019, 02, 28),

            Açıklama = "DENEME7",
            DosyaNo = "GLF20200007",
            Soyadı = "Aygün7",
            ZamanAsimi = false,
            TCNO = 0

        });
            #endregion
            #region CalışmaDönemi
            modelBuilder.Entity<CalismaDonemi>()
 .HasData(
        new CalismaDonemi()
        {
            Id = 1,
            DosyaId = 1,
            FazlaMesaiAlındı = true,
            ihbarAlındı = true,
            KıdemAlındı = true,
            StartDate = new DateTime(2013, 1, 1),
            FinishDate = new DateTime(2013, 4, 30),

        },
        new CalismaDonemi()
        {
            Id = 2,
            DosyaId = 1,
            FazlaMesaiAlındı = true,
            ihbarAlındı = true,
            KıdemAlındı = true,
            StartDate = new DateTime(2013, 6, 1),
            FinishDate = new DateTime(2013, 6, 30),

        },
        new CalismaDonemi()
        {
            Id = 3,
            DosyaId = 1,
            FazlaMesaiAlındı = true,
            ihbarAlındı = true,
            KıdemAlındı = true,
            StartDate = new DateTime(2013, 9, 1),
            FinishDate = new DateTime(2013, 9, 30),

        },
        new CalismaDonemi()
        {
            Id = 4,
            DosyaId = 1,
            FazlaMesaiAlındı = true,
            ihbarAlındı = true,
            KıdemAlındı = true,
            StartDate = new DateTime(2013, 10, 1),
            FinishDate = new DateTime(2013, 11, 2),

        },
        new CalismaDonemi()
        {
            Id = 5,
            DosyaId = 1,
            FazlaMesaiAlındı = true,
            ihbarAlındı = true,
            KıdemAlındı = true,
            StartDate = new DateTime(2014, 1, 1),
            FinishDate = new DateTime(2017, 1, 31),
        });
            #endregion
            #region ZamanÇizelgesi
            List<ZamanCizelgesi> liste = new List<ZamanCizelgesi>();
            int index = 1;
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    liste.Add(new ZamanCizelgesi()
                    {
                        Id = index,
                        CalismaDonemiId = i,
                        Gün = (Tanımlamalar.Günler)j,
                        StartTime = j == 6 ? new TimeSpan(9, 0, 0) : j == 7 ? new TimeSpan(0, 0, 0) : new TimeSpan(9, 0, 0),
                        EndTime = j == 6 ? new TimeSpan(16, 0, 0) : j == 7 ? new TimeSpan(0, 0, 0) : new TimeSpan(20, 30, 0),
                        RestTime = j == 6 ? new TimeSpan(1, 0, 0) : j == 7 ? new TimeSpan(0, 0, 0) : new TimeSpan(1, 30, 0),

                    });

                    index++;
                }

            }
            modelBuilder.Entity<ZamanCizelgesi>().HasData(liste);
            #endregion
            #region Talepler
            List<Talepler> taleps = new List<Talepler>();
            foreach (Tanımlamalar.TalepTipi item in Enum.GetValues(typeof(Tanımlamalar.TalepTipi)))
            {
                taleps.Add(new Talepler()
                {
                    Id = (int)item + 1,
                    DosyaId = 1,
                    TalepTipi = item,
                    Hesapla = false,
                });
            }
            modelBuilder.Entity<Talepler>().HasData(taleps);
            #endregion
            #region ÜcretBilgileri
            modelBuilder.Entity<UcretBilgileri>().HasData(new UcretBilgileri()
            {
                Id = 1,
                DosyaId = 1,
                Açıklama = Tanımlamalar.ÜcretTipi.ÇıplakBrüt,
                Tutar = 7000,

            });
            #endregion

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
