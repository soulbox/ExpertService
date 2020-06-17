using ExpertService.DAL.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL
{
    public interface IUnitofWork
    {
        IDosyaRepository DosyaRepo { get; }
        IUserRepository UserRepo { get; }

        int Complete();

    }
}
