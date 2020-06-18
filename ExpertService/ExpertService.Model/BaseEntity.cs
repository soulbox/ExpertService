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
        public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;        //new DateTime(2020,6,13);
        public DateTime? DeletedDate { get; private set; }
        public DateTime? ModifiedDate { get; private set; }
        public bool isActive
        {
            get => active;
            set
            {
                active = value;
                if (Id > 0 && active && CreatedDate < DateTime.UtcNow)
                    ModifiedDate = DateTime.UtcNow;
                else if (Id > 0 && !active)
                    DeletedDate = DateTime.UtcNow;
            }
        }

    }
}
