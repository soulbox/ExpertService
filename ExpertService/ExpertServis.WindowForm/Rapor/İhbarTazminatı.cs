using ExpertService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertServis.WindowForm.Rapor
{
    public class İhbarTazminatı
    {
        public Dosya Dosya { get; set; }
        //base

        public DateTime? İşeBaşlama { get => Dosya?.CalismaDonemi?.Min(x => x.StartDate); }
        public DateTime? İştenÇıkış { get => Dosya?.CalismaDonemi?.Max(x => x.FinishDate); }
        public int? ToplamGün { get => Dosya?.CalismaDonemi?.Sum(x => x.ToplamGün); }
        public int? ToplamAy { get => Dosya?.CalismaDonemi?.Sum(x => x.ToplamAy); }
        public decimal? Brüt { get => Dosya?.UcretBilgileri?.Sum(x => x.Tutar); }
        //base end

        public decimal GünlükÜcret { get => (Brüt ?? 0m) / 30m; }
        public decimal Brütİhbar { get => ÖneliSüresi * GünlükÜcret; }
        public decimal Gelirvergisi { get => hesapla(Brütİhbar).Sum(x => x.Vergi); }
        public decimal DamgaVergisi { get => Brütİhbar * 0.00759m; }
        public decimal Netİhbar { get => Brütİhbar - Gelirvergisi - DamgaVergisi; }
        public decimal MahsupEdilicek { get; set; }
        public decimal IslahZATutar { get; set; }
        public decimal ÖdenecekNetİhbar { get => Netİhbar - MahsupEdilicek + IslahZATutar; }
        //kötü niyet
        public decimal ÖneliSüresiKötü { get => ÖneliSüresi * 2; }
        public decimal BrütİhbarKötü { get => ÖneliSüresiKötü * GünlükÜcret; }
        public decimal GelirvergisiKötü { get => hesapla(BrütİhbarKötü).Sum(x => x.Vergi); }
        public decimal DamgaVergisiKötü { get => BrütİhbarKötü * 0.00759m; }
        public decimal NetİhbarKötü { get => BrütİhbarKötü - GelirvergisiKötü - DamgaVergisiKötü; }
        public decimal MahsupEdilicekKötü { get; set; }
        public decimal IslahZATutarKötü { get; set; }
        public decimal ÖdenecekNetİhbarKötü { get => NetİhbarKötü - MahsupEdilicekKötü + IslahZATutarKötü; }


        //public decimal ToplamBrütİhbar { get => ÖneliSüresi * EsasGünlük; }

        //public decimal DamgaKötüVergisi { get => toplamb * 0.00759m; }

        //public int KötüÖneliSüresi { get => ÖneliSüresi * 2; }
        //public int KötüToplamBrütİhbar { get => KötüÖneliSüresi; }
        //public decimal KötüGelirvergisi { get => hesapla(KötüToplamBrütİhbar).Sum(x => x.Vergi); }
        //public decimal Netİhbar { get => ToplamBrütİhbar - Gelirvergisi - DamgaVergisi; }
        //public decimal NetKötüİhbar { get => hesapla(KötüToplamBrütİhbar).Sum(x => x.Vergi); }

        //public decimal MahsupEdilicekTutar { get; set; }
        //public decimal MahsupEdilicekKötüTutar { get; set; }
        //public decimal IslahZATutar { get; set; }
        //public decimal IslahZAKötüTutar { get; set; }
        //public decimal ÖdenecekNetİhbar { get => hesapla(KötüToplamBrütİhbar).Sum(x => x.Vergi); }
        //public decimal ÖdenecekNetKötüİhbar { get => hesapla(KötüToplamBrütİhbar).Sum(x => x.Vergi); }


        public int ÖneliSüresi
        {
            get
            {
                int hesap = 0;
                if (ToplamAy is null) return hesap;

                if (ToplamAy < 6)//6 aydan küçükse
                    hesap = 2;
                else if (ToplamAy >= 6 && ToplamAy < 18)
                    hesap = 4;
                else if (ToplamAy >= 18 && ToplamAy < 36)
                    hesap = 6;
                else if (ToplamAy >= 36)
                    hesap = 8;

                return hesap * 7;
            }
        }
        List<VergiTablosu> hesapla(decimal matrah)
        {
            List<decimal> TutarListesi = new List<decimal>() { 22000, 49000, 180000, 600000, 100000000 };
            List<VergiTablosu> liste = new List<VergiTablosu>()
                {
                new VergiTablosu(){ Tutar=TutarListesi[0],Oran=0.15m },
                new VergiTablosu(){ Tutar=TutarListesi[1],Oran=0.20m,},
                new VergiTablosu(){ Tutar=TutarListesi[2],Oran=0.27m  },
                new VergiTablosu(){ Tutar=TutarListesi[3],Oran=0.35m },
                new VergiTablosu(){ Tutar=TutarListesi[4],Oran=0.40m },
                };
            liste.ForEach(x =>
            {
                int index = liste.IndexOf(x);
                int lastindex = liste.Count - 1;

                if (index == 0)
                {
                    x.OranHesabı = index;
                    x.VergiMatrahı = matrah < TutarListesi[index] ? matrah : 0;
                    x.Vergi = x.VergiMatrahı * x.Oran;

                }
                else if (index == 1)
                {
                    x.OranHesabı = TutarListesi[index - 1] * liste[index - 1].Oran;
                    x.VergiMatrahı = matrah >= TutarListesi[index - 1] && matrah < x.Tutar ? matrah : 0;
                    x.Vergi = x.VergiMatrahı > 0 ? ((x.VergiMatrahı - TutarListesi[index - 1]) * x.Oran) + x.OranHesabı : 0;
                }
                else if (index == lastindex)
                {
                    x.OranHesabı = TutarListesi[index - 1] * liste[index - 1].Oran;
                    x.VergiMatrahı = matrah > TutarListesi[index - 1] ? matrah : 0;
                    x.Vergi = x.VergiMatrahı > 0 ? ((x.VergiMatrahı - TutarListesi[index - 1]) * x.Oran) + x.OranHesabı : 0;
                }
                else
                {
                    x.OranHesabı = ((TutarListesi[index - 1] - TutarListesi[index - 2]) * liste[index - 1].Oran) + liste[index - 1].OranHesabı;

                    x.VergiMatrahı = matrah >= TutarListesi[index - 1] && matrah < x.Tutar ? matrah : 0;
                    x.Vergi = x.VergiMatrahı > 0 ? ((x.VergiMatrahı - TutarListesi[index - 1]) * x.Oran) + x.OranHesabı : 0;

                }

            });
            return liste;
        }
        class VergiTablosu
        {
            public decimal Tutar { get; set; }
            public decimal OranHesabı { get; set; }
            public decimal Oran { get; set; }
            public decimal VergiMatrahı { get; set; }
            public decimal Vergi { get; set; }


        }


        public İhbarTazminatı(Dosya dosya)
        {
            Dosya = dosya;
        }
    }
}
