using AutoLux.Application.Abstractions;
using AutoLux.Domain.Common;
using AutoLux.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLux.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AutoLuxDbContext _context;
        public GenericRepository(AutoLuxDbContext context) => _context = context;

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table.AsQueryable();

        public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);

        public async Task AddAsync(T entity) => await Table.AddAsync(entity);

        public void Update(T entity) => Table.Update(entity);

        public void Delete(T entity) => Table.Remove(entity);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
