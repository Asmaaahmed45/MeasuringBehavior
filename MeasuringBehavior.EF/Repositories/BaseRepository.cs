using MeasuringBehavior.Core.Models;
using MeasuringBehavior.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetById(Expression<Func<T, bool>> criteria)
        {
            return _dbContext.Set<T>().Where(criteria).ToList();
        }

        public T GetByEmail(Expression<Func<T, bool>> criteria)
        {
            return (_dbContext.Set<T>().Where(criteria).FirstOrDefault());
        }

        public bool IsExist(Expression<Func<T, bool>> criteria)
        {
            return _dbContext.Set<T>().Any(criteria);
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
