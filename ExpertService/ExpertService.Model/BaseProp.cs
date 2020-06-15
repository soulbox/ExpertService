using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class BaseProp
    {
        public DateTime CreatedDate { get; private  set; } = new DateTime(2020,6,13);
        public DateTime? DeletedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool isActive { get; set; } = true;


    }
}
