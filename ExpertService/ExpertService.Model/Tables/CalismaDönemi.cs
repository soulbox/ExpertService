using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model.Tables
{
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
}
