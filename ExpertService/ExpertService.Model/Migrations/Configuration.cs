namespace ExpertService.Model.Migrations
{
    using ExpertService.Model.Tables;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpertService.Model.DbEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ExpertService.Model.DbEntity";
            //Seed(DbManager.DB);

        }

        protected override void Seed(ExpertService.Model.DbEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.UserTables.AddOrUpdate(
                x => x.UserId,
                new UserTable()
                {
                    UserId = 1,
                    UserName = "admin",
                    Password = "admin",
                    Adres = "admin",
                    Name = "admin",
                    Surname = "admin",
                    Tel = "admin",
                    KayıtTarihi = new DateTime(2020, 06, 11)
                });
            context.Dosya.AddOrUpdate(x => x.DosyaId,
                new Dosya()
                {
                    DosyaId = 1,
                    UserId = 1,
                    Adı = "Kadir",
                    DavaTarihi = new DateTime(2019, 01, 31),
                    KayıtTarihi = DateTime.Now,
                    Açıklama = "DENEME",
                    DosyaNo = "GLF20200005",
                    Soyadı = "Aygün",
                    ZamanAsimi = false,
                });
            context.CalismaDonemi.AddOrUpdate(x => x.DonemId
            , new CalismaDonemi()
            {
                DonemId = 1,
                DosyaId = 1,
                FazlaMesaiAlındı = true,
                ihbarAlındı = true,
                KıdemAlındı = true,
                StartDate = new DateTime(2013, 1, 1),
                FinishDate = new DateTime(2013, 4, 30),

            }, new CalismaDonemi()
            {
                DonemId = 2,
                DosyaId = 1,
                FazlaMesaiAlındı = true,
                ihbarAlındı = true,
                KıdemAlındı = true,
                StartDate = new DateTime(2013, 6, 1),
                FinishDate = new DateTime(2013, 6, 30),

            }, new CalismaDonemi()
            {
                DonemId = 3,
                DosyaId = 1,
                FazlaMesaiAlındı = true,
                ihbarAlındı = true,
                KıdemAlındı = true,
                StartDate = new DateTime(2013, 9, 1),
                FinishDate = new DateTime(2013, 9, 30),

            }, new CalismaDonemi()
            {
                DonemId = 4,
                DosyaId = 1,
                FazlaMesaiAlındı = true,
                ihbarAlındı = true,
                KıdemAlındı = true,
                StartDate = new DateTime(2013, 10, 1),
                FinishDate = new DateTime(2013, 11, 2),

            }, new CalismaDonemi()
            {
                DonemId = 5,
                DosyaId = 1,
                FazlaMesaiAlındı = true,
                ihbarAlındı = true,
                KıdemAlındı = true,
                StartDate = new DateTime(2014, 1, 1),
                FinishDate = new DateTime(2017, 1, 31),
            });
            List<ZamanCizelgesi> liste = new List<ZamanCizelgesi>();
            int index = 1;
            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    if (j == 6)
                    {
                        liste.Add(new ZamanCizelgesi()
                        {
                            ZamanId = index,
                            DonemId = i,
                            Gün = (Model.Tables.Tanımlamalar.Günler)j,
                            StartTime = new TimeSpan(9, 0, 0),
                            EndTime = new TimeSpan(16, 0, 0),
                            RestTime = new TimeSpan(1, 0, 0),

                        });
                    }
                    else
                    {
                        liste.Add(new ZamanCizelgesi()
                        {
                            ZamanId = index,
                            DonemId = i,
                            Gün = (Model.Tables.Tanımlamalar.Günler)j,
                            StartTime = new TimeSpan(9, 0, 0),
                            EndTime = new TimeSpan(20, 30, 0),
                            RestTime = new TimeSpan(1, 30, 0),

                        });
                    }


                    index++;
                }

            }
            context.ZamanCizelgesi.AddOrUpdate(x => x.ZamanId, liste.ToArray());
            List<Talepler> taleps = new List<Talepler>();
            foreach (Tanımlamalar.TalepTipi item in Enum.GetValues(typeof(Tanımlamalar.TalepTipi)))
            {
                taleps.Add(new Talepler()
                {
                    DosyaId = 1,
                    TalepId=1,
                    TalepTipi = item,
                    Hesapla = false,                    
                });
            }
            context.Talepler.AddOrUpdate(x=>x.TalepId, taleps.ToArray());

        }
    }
}
