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
    public static class TavanUcreti
    {
        static readonly HttpClient client = new HttpClient()
        {
            Timeout = new TimeSpan(2, 0, 0),
            BaseAddress = new Uri("https://www.verginet.net/")
        };
        static List<TavanDonem> Tavan { get; set; }
        static TavanUcreti()
        {
            //TavanDonemleri = new List<TavanDonem>();
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
          
            client.DefaultRequestHeaders.Add("Accept-Language","tr-TR,tr;q=0.9,en-US;q=0.8,en;q=0.7");
            Tavan = Tavan ?? GetList();
        }
        public static List<TavanDonem> TavanDonemleri { get => Tavan = Tavan ?? GetList(); }

        static List<TavanDonem> GetList()
        {

            List<TavanDonem> liste = new List<TavanDonem>();
            var tr = GetTrListVergi().Result;
            tr
            .Where(x =>
            !x.Descendants("td").FirstOrDefault().InnerText.Contains("Dönemi") &&
            !string.IsNullOrWhiteSpace(x.Descendants("td").FirstOrDefault().InnerText)
            )
            .ToList()
            .ForEach(x =>
            {
                var str = " ";//farklı bir boşluk karakteri 0x32 byte
                var td = x.Descendants("td").ToList();
                var Donemtd = td[0];
                var tutartd = td[1];
                var DonemText = Donemtd.InnerText.Replace("\r\n", "").Replace(str, " ").Replace("&#8211;","-");
                var TutarText = tutartd.InnerText.Replace("\r\n", "").Replace(str, " ").Replace(" TL", "").Replace(" YTL", "");
                var donemSplit = Regex.Split(DonemText, @" - ");       
                var StartDate = DateTime.ParseExact(donemSplit[0], "dd MMMMM yyyy", CultureInfo.CreateSpecificCulture("tr-TR"));
                var EndDate = DateTime.ParseExact(donemSplit[1], "dd MMMMM yyyy", CultureInfo.CreateSpecificCulture("tr-TR"));             
                var Tutar = Convert.ToDecimal(TutarText.Replace(" " ,""), CultureInfo.CreateSpecificCulture("tr-TR"));



                liste.Add(new TavanDonem()
                {
                    EndDate = EndDate,
                    StartDate = StartDate,
                    Tutar = Tutar
                });

            });

            return liste;
        }


        static async Task<List<HtmlNode>> GetTrListVergi()
        {
            var res = await client.GetStringAsync("https://www.verginet.net/dtt/1/kidem-tazminati-tavani.aspx");
            var document = new HtmlDocument();
            document.LoadHtml(res);
            var tr = document.GetElementbyId("dvContent")
                .Descendants("div").FirstOrDefault()
                .Descendants("table").FirstOrDefault()
                .Descendants("tbody").FirstOrDefault()
                .SelectNodes("tr").ToList();
            return tr;
        }


    }
    public class TavanDonem
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Tutar { get; set; }

    }
}
