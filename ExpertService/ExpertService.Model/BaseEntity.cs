using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class BaseEntity
    {
        bool active = true;
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        //new DateTime(2020,6,13);
        public DateTime? DeletedDate { get;  set; }
        public DateTime? UpdatedDate { get; set; }
        public bool isActive { get; set; } = true;


    }
}
