using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model.Tables
{
    public class UcretBilgileri
    {
        [Key]
        public int UcretId { get; set; }
        public int DosyaId { get; set; }
        public int Açıklama { get; set; }
        public decimal Tutar { get; set; }
        public Dosya Dosya { get; set; }
    }
}
