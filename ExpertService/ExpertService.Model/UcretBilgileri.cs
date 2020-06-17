using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class UcretBilgileri : BaseEntity
    {

        public int DosyaId { get; set; }
        public Tanımlamalar.ÜcretTipi  Açıklama { get; set; }
        public decimal Tutar { get; set; }
        public Dosya Dosya { get; set; }
    }
}
