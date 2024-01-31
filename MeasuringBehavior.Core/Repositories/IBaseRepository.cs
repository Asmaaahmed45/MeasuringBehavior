using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetById(Expression<Func<T, bool>> criteria);
        T GetById(int id);
        T GetByEmail(Expression<Func<T, bool>> criteria);
        IEnumerable<T> GetAll();
        bool IsExist(Expression<Func<T, bool>> criteria);
        T Add(T entity);
        T Update(T entity);


    }
}
