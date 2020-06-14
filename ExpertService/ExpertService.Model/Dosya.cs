﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class Dosya : BaseProp
    {
        public Dosya()
        {
            CalismaDonemis = new List<CalismaDonemi>();
            UcretBilgileris = new List<UcretBilgileri>();
            Taleplers = new List<Talepler>();
            EkDosya = new List<Dosya>();
            AnaDosya = new Dosya();
        }
        [Key]
        public int DosyaId { get; set; }

        public Int64 TCNO { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string DosyaNo { get; set; }
        public string Açıklama { get; set; }
        public DateTime DavaTarihi { get; set; }
        public Boolean ZamanAsimi { get; set; }
        public ICollection<CalismaDonemi> CalismaDonemis { get; set; }
        public ICollection<UcretBilgileri> UcretBilgileris { get; set; }
        public ICollection<Talepler> Taleplers { get; set; }
        public int UserId { get; set; }
        public UserTable UserTable { get; set; }
        //Ek Dosyalar  
        //[ForeignKey("DosyaId")]
        public int? AnaDosyaID { get; set; }
        //[ForeignKey("AnaDosyaID")]
        public virtual ICollection<Dosya> EkDosya { get; set; }

        public virtual Dosya AnaDosya { get; set; }

    }
}