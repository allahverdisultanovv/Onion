﻿using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using System.Linq.Expressions;

namespace ProniaOnion.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public IQueryable<T> GetAll(
            Expression<Func<T, bool>>? whereExpression = null,
            Expression<Func<T, object>>? orderExpression = null,
            int skip = 0,
            int take = 0,
            bool isDescending = false,
            bool isTracking = false,
            params string[]? includes
            )
        {
            IQueryable<T> query = _table;

            if (whereExpression != null)
                query = query.Where(whereExpression);


            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }


            if (orderExpression != null)
                query = isDescending ? query.OrderByDescending(orderExpression) : query.OrderBy(orderExpression);


            query = query.Skip(skip);

            if (take != 0)
                query = query.Take(take);


            return isTracking ? query : query.AsNoTracking();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FirstOrDefaultAsync(c => c.Id == id);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }
    }
}
