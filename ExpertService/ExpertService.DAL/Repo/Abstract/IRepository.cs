using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL.Repo.Abstract
{
    public interface IRepository<Entity> where Entity : class
    {
       
        Entity GetbyQuery(Expression<Func<Entity, bool>> expression);

        IEnumerable<Entity> GetAll();        
        IEnumerable<Entity> QueryGetAll(Expression<Func<Entity, bool>> expression);
        void Add(Entity entity);
        void Add(IEnumerable<Entity> entity);
        void Remove(Entity entity);
        void Remove(IEnumerable<Entity> entity);
        
    }
}
