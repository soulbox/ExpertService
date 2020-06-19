using ExpertService.DAL.Repo.Abstract;
using ExpertService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL.Repo.Concreate
{
    public class UserRepository
        : Repository<UserTable>, IUserRepository
    {
        public UserTable GetWithDosya(Expression<Func<UserTable, bool>> expression )
        {
            return Db.UserTable
                .Include(x => x.Dosya)
                    .ThenInclude(x => x.CalismaDonemi)
                        .ThenInclude(x => x.ZamanCizelgesi)
                 .Include(x => x.Dosya)
                    .ThenInclude(x => x.UcretBilgileri)
                .Include(x => x.Dosya)
                    .ThenInclude(x => x.Talepler)
                .Include(x => x.Dosya)
                    .ThenInclude(x => x.EkDosya)
                .FirstOrDefault(expression);
        }
    }
}
