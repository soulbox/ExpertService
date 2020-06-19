using ExpertService.Data;
using ExpertService.Model;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertServis.WindowForm.Rapor
{
    public class KıdemTazminatı
    {
        public List<TavanDonem> TavanUcretler { get; set; }//ctor
        public Dosya Dosya { get; set; }//ctor
        public DateTime? işeBaşlamatarihi { get => Dosya?.CalismaDonemi?.Min(x => x.StartDate); }
        public DateTime? iştençıkıştarihi { get => Dosya?.CalismaDonemi?.Max(x => x.FinishDate); }
        public int? HizmetYıl { get => Dosya?.CalismaDonemi?.Sum(x => x.Yıl); }
        public int? HizmetAy { get => Dosya?.CalismaDonemi?.Sum(x => x.Ay); }
        public int? HizmetGün { get => Dosya?.CalismaDonemi?.Sum(x => x.Gün); }
        public decimal Tavan { get => TavanDönemi.Tutar; }
        public decimal Brüt { get; private set; }
        public decimal TazminatEsasAylık { get => Brüt > Tavan ? Tavan : Brüt; }
        public decimal YıllıkToplamÜcret { get => TazminatEsasAylık * (HizmetYıl ?? 0); }
        public decimal AylıkToplamÜcret { get => TazminatEsasAylık * (HizmetAy ?? 0) / 12; }
        public decimal GünlükToplamÜcret { get => TazminatEsasAylık * (HizmetGün ?? 0) / 365; }
        public decimal ToplamBrütKıdemTazminatı { get => (YıllıkToplamÜcret + AylıkToplamÜcret + GünlükToplamÜcret); }
        public decimal DamgaVergisi { get => 0.00759m * ToplamBrütKıdemTazminatı; }
        public decimal NetKıdemTazminatı { get => ToplamBrütKıdemTazminatı - DamgaVergisi; }
        public decimal MahsupEdilicekTutar { get; set; }
        public decimal ÖdenecekNetKıdemTazminatı { get => NetKıdemTazminatı - MahsupEdilicekTutar; }
        public Boolean FasılalıÇalışma { get; private set; }
        public TavanDonem TavanDönemi { get; private set; } = new TavanDonem();
        public KıdemTazminatı(List<TavanDonem> tavanDonemi, Dosya dosya)
        {
            TavanUcretler = tavanDonemi;
            Dosya = dosya;

            Hesapla();
        }
        public void Hesapla()
        {
            if (Dosya.CalismaDonemi == null) return;
            ToplamÇalışma();
            if (Dosya.CalismaDonemi?.Count > 1)
                FasılalıÇalışma = true;
            Brüt = Dosya.UcretBilgileri.Select(x => x.Tutar).Sum();
            TavanDönemi = TavanUcretler
                .FirstOrDefault(x => iştençıkıştarihi >= x.StartDate && iştençıkıştarihi <= x.EndDate);

        }
        void ToplamÇalışma()
        {

            if (Dosya?.CalismaDonemi?.Count > 0)
            {
                //string str = "";
                //var a = Dosya.CalismaDonemis.OrderByDescending(x => x.DonemId)
                //    .Select(x => new Dönem
                //    {
                //        DönemBaşlangıç = x.StartDate,
                //        DönemBitiş = x.FinishDate,
                //        Fark = (x.FinishDate - x.StartDate.AddDays(1)),
                //        Period = NodaTime.Period.Between(x.StartDate.ToLocalDate(), x.FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.YearMonthDay),
                //        Yıl = NodaTime.Period.Between(x.StartDate.ToLocalDate(), x.FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.YearMonthDay).Years,
                //        Gün = NodaTime.Period.Between(x.StartDate.ToLocalDate(), x.FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.YearMonthDay).Days,
                //        Ay = NodaTime.Period.Between(x.StartDate.ToLocalDate(), x.FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.YearMonthDay).Days,
                //    })
                //    .ToList();



                //a.ForEach(x =>
                //{
                //    str += $"{x.StartDate.ToShortDateString()}-{x.FinishDate.ToShortDateString()} [{x.pr.Years} yıl {x.pr.Months } ay {x.pr.Days } gün] {x.Fark.TotalDays} Toplam Gün\r\n";
                //});

            }
        }

    }

}
