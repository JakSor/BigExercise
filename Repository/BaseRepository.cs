using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Data.DataAccessLayer;
using Domain.Parameters;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace Repository
{
    public  class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async void Delete(int id)
        {
            var entity = await GetTById(id);
            _dbSet.Remove(entity);            
        }

        public async virtual Task<T> GetTById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual IEnumerable<T> GetTs()
        {
            
            return _dbSet.ToList(); 
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public async virtual Task<bool> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
            
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
           
        }
        public async virtual Task<int> Save()
        {
            return await _context.SaveChangesAsync();


        }
        public virtual int ReturnCount()
        {
            return _dbSet.Count();
        }
    }
}
