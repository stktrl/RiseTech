using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.DataAccess.Data
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> Pagination(int page, int pageSize);
        bool Exist(Expression<Func<T, bool>> filter);
    }
}
