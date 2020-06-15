using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class CalismaDonemi : BaseProp
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
        public Period Period { get => NodaTime.Period.Between(StartDate.ToLocalDate(), FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.YearMonthDay); }
        public int Yıl { get => Period.Years; }
        public int Ay { get => Period.Months; }
        public int Gün { get => Period.Days; }
        public int ToplamGün { get => NodaTime.Period.Between(StartDate.ToLocalDate(), FinishDate.AddDays(1).ToLocalDate(), PeriodUnits.Days).Days; }

    }
    public static class MyExtensions
    {
        public static LocalDate ToLocalDate(this DateTime dateTime)
        {
            return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }
    }
}
