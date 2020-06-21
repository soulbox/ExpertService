using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpertService.Data
{
    public static class AsgariUcret
    {
        static readonly HttpClient client = new HttpClient()
        {
            Timeout = new TimeSpan(2, 0, 0),
            BaseAddress = new Uri("https://www.isvesosyalguvenlik.com/")
        };
        static List<AsgariUcretListesi> listAsgari { get; set; }
        public static List<AsgariUcretListesi> AsgariDonemleri { get => listAsgari = listAsgari ?? GetList(); }

        static AsgariUcret()
        {
            //TavanDonemleri = new List<TavanDonem>();
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");

            client.DefaultRequestHeaders.Add("Accept-Language", "tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
        }
        static List<AsgariUcretListesi> GetList()
        {

            List<AsgariUcretListesi> liste = new List<AsgariUcretListesi>();
            var tr = GetTrListAsgari().Result;
            tr.Where(x =>
                        !x.Descendants("td").FirstOrDefault().InnerText.Contains("Yıllar İtibariyle Brüt") &&
                        !x.Descendants("td").FirstOrDefault().InnerText.Contains("DÖNEM"))
                .ToList().ForEach(x =>
            {
                var td = x.Descendants("td").ToList();
                var Donemtd = td[0];
                var güntd = td[1];
                var aytd = td[2];
                var DonemText = Donemtd.InnerText.Replace("&#8211;", "-");
                var GünText = güntd.InnerText;
                var AyText = aytd.InnerText;
                var donemSplit = Regex.Split(DonemText, @" - ");
                var StartDate = DateTime.ParseExact(donemSplit[0], "dd.MM.yyyy", CultureInfo.CreateSpecificCulture("tr-TR"));
                var EndDate = DateTime.ParseExact(donemSplit[1], "dd.MM.yyyy", CultureInfo.CreateSpecificCulture("tr-TR"));
                var TutarGün = Convert.ToDecimal(GünText, CultureInfo.CreateSpecificCulture("tr-TR"));
                var TutarAy = Convert.ToDecimal(AyText, CultureInfo.CreateSpecificCulture("tr-TR"));

                liste.Add(new AsgariUcretListesi()
                {
                    BitişçDönemi = EndDate,
                    BaşlangıçDönemi = StartDate,
                    GünlükBrüt = TutarGün,
                    AylıkBrüt = TutarAy,

                });


            });

            return liste;
        }
        static async Task<List<HtmlNode>> GetTrListAsgari()
        {
            var res = await client.GetStringAsync("https://www.isvesosyalguvenlik.com/yillar-itibariyle-brut-asgari-ucret-tutarlari/");
            var str = new string[] {"371","369" };
            var document = new HtmlDocument();
            document.LoadHtml(res);
            var tr = document.DocumentNode
                .Descendants("table")
                .Where(x => str.Contains(x.GetAttributeValue("width", null)))
                .SelectMany(x => x.Descendants("tbody")).SelectMany(x => x.Descendants("tr")).ToList();
                //.Descendants("tbody").FirstOrDefault()
                //.SelectNodes("tr").ToList();
            return tr;
        }
    }
    //    Yıllar İtibariyle Brüt Asgari Ücret Tutarları
    //(1 Ocak 2014 tarihinden itibaren 16 yaşını dolduran ve doldurmayanlar için tek asgari ücret belirlenmektedir.)
    public class AsgariUcretListesi
    {
        public DateTime BaşlangıçDönemi { get; set; }
        public DateTime BitişçDönemi { get; set; }
        public decimal GünlükBrüt { get; set; }
        public decimal AylıkBrüt { get; set; }



    }
}
