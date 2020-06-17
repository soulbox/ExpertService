using ExpertService.DAL.Repo.Abstract;
using ExpertService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL.Repo.Concreate
{
    public class DosyaRepository : Repository<Dosya>, IDosyaRepository
    {
        public bool RemoveChilds()
        {
            throw new NotImplementedException();
        }
    }
}
