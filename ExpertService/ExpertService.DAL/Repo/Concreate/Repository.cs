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
    public class Repository<Entity> :
        IRepository<Entity> where Entity : class
    {
        public DbEntity Db { get; } = DbManager.DB;
        public void Add(Entity entity)
        {
            Db.Set<Entity>().Add(entity);
        }
        public void Add(IEnumerable<Entity> entity)
        {
            Db.Set<Entity>().AddRange(entity);

        }
        public IEnumerable<Entity> GetAll()
        {

            return Db.Set<Entity>().ToList();
        }
        public IEnumerable<Entity> QueryGetAll(Expression<Func<Entity, bool>> expression)
        {
            return Db.Set<Entity>().Where(expression).ToList();
        }
        public void Remove(Entity entity)
        {
            Db.Set<Entity>().Remove(entity);
        }
        public void Remove(IEnumerable<Entity> entity)
        {
            Db.Set<Entity>().RemoveRange(entity);

        }
        public Entity GetbyQuery(Expression<Func<Entity, bool>> expression)
        {
       
            return Db.Set<Entity>().FirstOrDefault(expression);

        }

    }
}
