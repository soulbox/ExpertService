using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    #region Tanımlamalar
    public static class Tanımlamalar
    {
        public static List<string> OdemeTanımlama { get; set; } = new List<string>()
        {
            "Çıplak Brüt","Prim","Yol","Yemek"
        };
        public static Dictionary<TalepTipi, string> AlıcakKalemler { get; set; } = new Dictionary<TalepTipi, string>()
        {
           { TalepTipi.KıdemTazminatı ,"Kıdem Tazminatı Alacağı" },
           { TalepTipi.ihbarTazminatı  ,"İhbar Tazminatı Alacağı"},
           { TalepTipi.FazlaMesai , "Fazla Mesai Alacağı"},
           { TalepTipi.UlusalBayram ,  "Ulusal Bayram Alacağı"},
           { TalepTipi.Yıllıkİzin , "Yıllık İzin Ücreti Alacağı"},
           { TalepTipi.HaftaTatili  , "Hafta Tatili Alacağı"},
           { TalepTipi.ÜcretAlacağı , "Ücret Alacağı"},
           { TalepTipi.AgiAlacağı , "AGİ Alacağı"},
           { TalepTipi.işeBaşlatmamaTaz , "İşe Başlatmama Taz."},
           { TalepTipi.BoştaGeçenSüre  , "Boşta Geçen Süre Üc."}
        };
        public enum TalepTipi
        {
            KıdemTazminatı,
            ihbarTazminatı,
            FazlaMesai,
            UlusalBayram,
            Yıllıkİzin,
            HaftaTatili,
            ÜcretAlacağı,
            AgiAlacağı,
            işeBaşlatmamaTaz,
            BoştaGeçenSüre
        }

        public enum Günler
        {
            Pazartesi,
            Salı,
            Çarşamba,
            Perşembe,
            Cuma,
            Cumartesi,
            Pazar
        }

    }
    #endregion
    public class Dosya
    {
        [Key]
        public int DosyaId { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string DosyaNo { get; set; }
        public string Açıklama { get; set; }
        public DateTime DavaTarihi { get; set; }
        public Boolean ZamanAsimi { get; set; }
        public ICollection<CalismaDonemi> CalismaDonemis { get; set; }
        public ICollection<Odenenler> Odenenler { get; set; }
        public ICollection<Talepler> Taleplers { get; set; }


    }

    public class CalismaDonemi
    {
        [Key]
        public int DonemId { get; set; }
        public int DosyaId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public Boolean KıdemAlındı { get; set; }
        public Boolean ihbarAlındı { get; set; }
        public Boolean FazlaMesaiAlındı { get; set; }
        public ICollection<ZamanCizelgesi> ZamanCizelgesis { get; set; }
        public Dosya Dosya { get; set; }
    }
    public class ZamanCizelgesi
    {
        [Key]
        public int ZamanId { get; set; }
        public int DonemId { get; set; }
        public string Gün { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan RestTime { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan TotalTime { get => EndTime.Subtract(StartTime).Subtract(RestTime); private set { } }
        public CalismaDonemi CalismaDonemi { get; set; }
    }
    public class Odenenler
    {
        [Key]
        public int OdeId { get; set; }
        public int DosyaId { get; set; }
        public int Açıklama { get; set; }
        public decimal Tutar { get; set; }
        public Dosya Dosya { get; set; }
    }
    public class Talepler
    {
        [Key ]
        public int TalepId { get; set; }
        public int DosyaId { get; set; }
        public Tanımlamalar.TalepTipi TalepTipi { get; set; }
        public decimal Tutar { get; set; }
        public Dosya Dosya { get; set; }

    }
}
