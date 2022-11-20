using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Contact_Information.IRepository
{
    public interface IGenericRepository
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                    List<string> includes = null);

            Task<T> Get(Expression<Func<T, bool>> expression = null,
                                   List<string> includes = null);

            Task Insert(T entity);

            Task InsertRange(IEnumerable<T> entities);

            void Update(T entity);
            //IList<T> GetPaginagedResult(IList<T> source, PaginationParams paginationParams);
            Task GetAll(string includes);
            // IList<T> GetPaginagedResult(IList<T> source, PaginationParams paginationParams);

        }
    }
}
