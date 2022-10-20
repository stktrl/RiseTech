using Microsoft.EntityFrameworkCore;
using RiseTech.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.DataAccess.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        private ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            var addEntity = _context.Entry(entity);
            addEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            var deleteEntity = _context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public bool Exist(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            var data = _context.Set<T>();
            return data.Any(filter);
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(x=>x.IsDeleted==false).SingleOrDefault(filter);
        }

        public IList<T> GetList(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                   ? _context.Set<T>().ToList()
                   : _context.Set<T>().Where(filter).Where(x=>x.IsDeleted==false).ToList();
        }

        public IList<T> Pagination(int page, int pageSize)
        {
            return _context.Set<T>().Where(x=>x.IsDeleted==false).Skip(page).Take(pageSize).ToList();
        }

        public void Update(T entity)
        {
            var deleteEntity = _context.Entry(entity);
            deleteEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
