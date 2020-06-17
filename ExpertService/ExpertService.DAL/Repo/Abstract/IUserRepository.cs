using ExpertService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL.Repo.Abstract
{
    public interface IUserRepository
        : IRepository<UserTable>
    {
        UserTable GetWithDosya(Expression<Func<UserTable,bool>> expression );
    }
}
