﻿using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public delegate void ItemAdded(object item);
    public class SqlRepository <T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContext;
        private readonly ItemAdded _itemAddedCallBack;

        public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallBack = null)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
            _itemAddedCallBack = itemAddedCallBack;
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T GetById (int id)
        {
            return _dbSet.Find(id);
        }
        public void Add (T item)
        {
            _dbSet.Add(item);
            _itemAddedCallBack.Invoke(item);
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
