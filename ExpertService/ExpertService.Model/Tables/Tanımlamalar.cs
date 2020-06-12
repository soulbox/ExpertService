using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model.Tables
{
    public static class Tanımlamalar
    {
        
        public enum ÜcretTipi
        {
            ÇıplakBrüt,
            Prim,
            Yol,
            Yemek
        }
         static Dictionary<TalepTipi, string> TalepKalemleri { get; set; } = new Dictionary<TalepTipi, string>()
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
        public static string GetTalepKalemleri(TalepTipi tip) => TalepKalemleri.FirstOrDefault(x => x.Key == tip).Value;
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
}
