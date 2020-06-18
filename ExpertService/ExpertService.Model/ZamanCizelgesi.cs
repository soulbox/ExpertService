using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExpertService.Model.Tanımlamalar;

namespace ExpertService.Model
{
    public class ZamanCizelgesi : BaseEntity
    {

        public Günler Gün { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan RestTime { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed )]
        //public TimeSpan? TotalTime { get => EndTime.Subtract(StartTime).Subtract(RestTime); private set { } }
        public TimeSpan NetTime { get => WorkTime.Subtract(RestTime); }
        public TimeSpan WorkTime { get => EndTime.Subtract(StartTime); }
        public int CalismaDonemiId { get; set; }
        public CalismaDonemi CalismaDonemi { get; set; }
    }
}
