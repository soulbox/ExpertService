using ExpertService.DAL.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL
{
    public class UnitOfWork : IUnitofWork
    {
        public IDosyaRepository DosyaRepo => throw new NotImplementedException();

        public IUserRepository UserRepo => throw new NotImplementedException();

        public int Complete()
        {
            throw new NotImplementedException();
        }
    }
}
