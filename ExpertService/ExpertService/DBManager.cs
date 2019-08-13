using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService
{
    public class DBManager
    {
        static ExperDBEntities db;

        public static  ExperDBEntities Db {
            get
            {
                return db = db ?? new ExperDBEntities();
            }
        }

        static  DBManager()
        {
          
        }

    }
}
