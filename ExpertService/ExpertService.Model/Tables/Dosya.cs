using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model.Tables
{
    public class Dosya
    {
        [Key]
        public int DosyaId { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string DosyaNo { get; set; }
        public string Açıklama { get; set; }
        public DateTime DavaTarihi { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public Boolean ZamanAsimi { get; set; }
        public ICollection<CalismaDonemi> CalismaDonemis { get; set; }
        public ICollection<UcretBilgileri > UcretBilgileris  { get; set; }
        public ICollection<Talepler> Taleplers { get; set; }
        public int UserId { get; set; }
        public UserTable UserTable { get; set; }


    }
}
