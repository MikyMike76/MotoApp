﻿using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;

namespace MotoApp.Repositories
{
    //public delegate void ItemAdded<T>(T item);
    public class SqlRepository <T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        private readonly Action<T>? _itemAddedCallBack;
        public EventHandler<T>? itemAdded;

        public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallBack = null)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _itemAddedCallBack = itemAddedCallBack;
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T? GetById (int id)
        {
            return _dbSet.Find(id);
        }
        public void Add (T item)
        {
            _dbSet.Add(item);
            _itemAddedCallBack?.Invoke(item);
            itemAdded?.Invoke(this, item);
        }
        public void Remove (T item)
        {
            _dbSet.Remove(item);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
