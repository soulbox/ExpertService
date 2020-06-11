using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.Model
{
    public class DbManager
    {
        static DbEntity entity;
        public static DbEntity DB { get => entity; }
        static DbManager()
        {
            entity = new DbEntity();
        }
    }
}
