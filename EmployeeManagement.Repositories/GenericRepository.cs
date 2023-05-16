using EmployeeManagement.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T:class
    {
        protected readonly ApplicationDbContext _dbContext;
        protected GenericRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task Add(T model)
        {
            await _dbContext.Set<T>().AddAsync(model);
        }

        public void Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public void Update(T model)
        {
            _dbContext.Set<T>().Update(model);
        }
    }
}
