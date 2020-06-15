namespace ExpertService.DAL.Migrations
{
    using ExpertService.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;

    internal sealed class Configuration : DbMigrationsConfiguration<DbEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ExpertService.Model.DbEntity";
            //Seed(DbManager.DB);

        }

        protected override void Seed(DbEntity context)
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
                });
            context.Dosya.AddOrUpdate(x => x.DosyaId,
                new Dosya()
                {
                    DosyaId = 1,
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
                    DosyaId = 2,
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
                    DosyaId = 3,
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
                    DosyaId = 4,
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
                    DosyaId = 5,
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
                    DosyaId = 6,
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
                    DosyaId = 7,
                    UserId = 1,
                    AnaDosyaID = 5,
                    Adı = "Kadir",
                    DavaTarihi = new DateTime(2019, 02, 28),

                    Açıklama = "DENEME7",
                    DosyaNo = "GLF20200007",
                    Soyadı = "Aygün7",
                    ZamanAsimi = false,
                    TCNO = 0

                }
                );
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
                    liste.Add(new ZamanCizelgesi()
                    {
                        ZamanId = index,
                        DonemId = i,
                        Gün = (Tanımlamalar.Günler)j,
                        StartTime = j == 6 ? new TimeSpan(9, 0, 0) : j == 7 ? new TimeSpan(0, 0, 0) : new TimeSpan(9, 0, 0),
                        EndTime = j == 6 ? new TimeSpan(16, 0, 0) : j == 7 ? new TimeSpan(0, 0, 0) : new TimeSpan(20, 30, 0),
                        RestTime = j == 6 ? new TimeSpan(1, 0, 0) : j == 7 ? new TimeSpan(0, 0, 0) : new TimeSpan(1, 30, 0),

                    });

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
                    TalepId = 1,
                    TalepTipi = item,
                    Hesapla = false,
                });
            }
            context.Talepler.AddOrUpdate(x => x.TalepId, taleps.ToArray());

            context.UcretBilgileri.AddOrUpdate(x => x.UcretId,
                new UcretBilgileri()
                {
                    DosyaId = 1,
                    UcretId = 1,
                    Açıklama = Tanımlamalar.ÜcretTipi.ÇıplakBrüt,
                    Tutar = 7000,

                });

        }
    }
}
