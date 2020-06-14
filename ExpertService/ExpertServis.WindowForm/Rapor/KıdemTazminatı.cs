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
        public DateTime işeBaşlamatarihi { get; private set; }
        public DateTime iştençıkıştarihi { get; private set; }
        public int HizmetYıl { get; private set; }
        public int HizmetAy { get; private set; }
        public int HizmetGün { get; private set; }
        public decimal Tavan { get; private set; }
        public decimal Brüt { get; private set; }
        public decimal TazminatYıllıkÜcret { get => Brüt > Tavan ? Tavan : Brüt; }

        public decimal YıllıkToplamÜcret { get => TazminatYıllıkÜcret * HizmetYıl; }
        public decimal AylıkToplamÜcret { get => TazminatYıllıkÜcret * HizmetAy / 12; }
        public decimal GünlükToplamÜcret { get => TazminatYıllıkÜcret * HizmetGün / 365; }
        public decimal ToplamBrütKıdemTazminatı { get => (YıllıkToplamÜcret + AylıkToplamÜcret + GünlükToplamÜcret); }
        public decimal DamgaVergisi { get => 0.00759m * ToplamBrütKıdemTazminatı; }
        public decimal NetKıdemTazminatı { get => ToplamBrütKıdemTazminatı + DamgaVergisi; }
        public decimal MahsupEdilicekTutar { get; set; }
        public decimal ÖdenecekNetKıdemTazminatı { get => NetKıdemTazminatı - MahsupEdilicekTutar; }
        public Boolean FasılalıÇalışma { get; set; }
        public KıdemTazminatı(List<TavanDonem> tavanDonemi, Dosya dosya, Boolean fasılalı)
        {
            TavanUcretler = tavanDonemi;
            Dosya = dosya;
            //todo fasılalı durum işebaşlama
            FasılalıÇalışma = fasılalı;
            Hesapla();
        }
        public void Hesapla()
        {
            ToplamÇalışma();
            işeBaşlamatarihi = Dosya.CalismaDonemis.Min(x => x.StartDate);
            iştençıkıştarihi = Dosya.CalismaDonemis.Max(x => x.FinishDate);
            Brüt = Dosya.UcretBilgileris.Select(x => x.Tutar).Sum();
            Tavan = TavanUcretler
                .FirstOrDefault(x => x.StartDate >= iştençıkıştarihi && x.EndDate <= iştençıkıştarihi).Tutar;

        }
        void ToplamÇalışma()
        {

            if (Dosya?.CalismaDonemis?.Count > 0)
            {
                //string str = "";
                var a = Dosya.CalismaDonemis.Select(x => new
                {
                    x.FinishDate,
                    x.StartDate,
                    Fark = (x.FinishDate - x.StartDate),
                    pr = NodaTime.Period.Between(x.StartDate.ToLocalDate(), x.FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.YearMonthDay),
                    //str= $"{x.StartDate.ToShortDateString()}-{x.FinishDate.ToShortDateString()} [{pr.Years} yıl {x.pr.Months } ay {x.pr.Days } gün] {x.Fark.TotalDays} Toplam Gün\r\n"
                }).ToList();
                HizmetYıl = a.Sum(x => x.pr.Years);
                HizmetAy = a.Sum(x => x.pr.Months);
                HizmetGün = a.Sum(x => x.pr.Days);


                //a.ForEach(x =>
                //{
                //    str += $"{x.StartDate.ToShortDateString()}-{x.FinishDate.ToShortDateString()} [{x.pr.Years} yıl {x.pr.Months } ay {x.pr.Days } gün] {x.Fark.TotalDays} Toplam Gün\r\n";
                //});

            }
        }

    }
    public static class MyExtensions
    {
        public static LocalDate ToLocalDate(this DateTime dateTime)
        {
            return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}
