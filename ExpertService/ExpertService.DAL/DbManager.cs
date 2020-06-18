using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL
{
    public static  class DbManager
    {
        static DbEntity entity;
        static UnitOfWork unit;
        public static UnitOfWork UnitWork { get => unit = unit ?? new UnitOfWork(); }
        public static DbEntity DB { get => entity = entity ?? new DbEntity(); }
        static DbManager()
        {

            entity = new DbEntity();
            unit = new UnitOfWork();
            //entity.c
        }
    }
}
