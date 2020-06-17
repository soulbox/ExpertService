using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class UserTable : BaseEntity
    {

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Adres { get; set; }
        public string Tel { get; set; }
        public ICollection<Dosya> Dosya { get; set; }


    }
}
