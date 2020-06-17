using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class Talepler : BaseEntity
    {

        public int DosyaId { get; set; }

        //public decimal Tutar { get; set; }
        public Dosya Dosya { get; set; }
        public bool  Hesapla { get; set; }
        //public TalepKalemi TalepKalemi { get; set; }
        //public int KalemId { get; set; }
        public Tanımlamalar.TalepTipi TalepTipi { get; set; }


    }

    public class TalepKalemi
    {
        [Key]
        public int KalemId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        public string TalepAdı { get; set; }
        public Tanımlamalar.TalepTipi TalepTipi { get; set; }
        public string Açıklama { get; set; }


    }
}
