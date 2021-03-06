﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class Dosya : BaseEntity
    {
        public Dosya() 
        {
            CalismaDonemi = new HashSet<CalismaDonemi>();
            UcretBilgileri = new HashSet<UcretBilgileri>();
            Talepler = new HashSet<Talepler>();
            EkDosya = new HashSet<Dosya>();
            //AnaDosya = new Dosya();
        }


        public Int64 TCNO { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public string DosyaNo { get; set; }
        public string Açıklama { get; set; }
        public DateTime DavaTarihi { get; set; }
        public Boolean ZamanAsimi { get; set; }
        public ICollection<CalismaDonemi> CalismaDonemi { get; set; }
        public ICollection<UcretBilgileri> UcretBilgileri { get; set; }
        public ICollection<Talepler> Talepler { get; set; }
        public int UserId { get; set; }
        public UserTable User { get; set; }
        //Ek Dosyalar  
        //[Key ]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("AnaDosya")]
        public int? AnaDosyaID { get; set; }
        public DateTime? CompleteDate { get; set; } = (DateTime?)null;
        //[ForeignKey("AnaDosyaID")]
        public ICollection<Dosya> EkDosya { get; set; }
        public Dosya AnaDosya { get; set; }

    }
}
