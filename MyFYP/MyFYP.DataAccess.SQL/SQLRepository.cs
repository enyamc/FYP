﻿using MyFYP.Core.Contracts;
using MyFYP.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFYP.DataAccess.SQL
{
    //Adapted from -https://www.udemy.com/course/better-web-development-pro-techniques-for-success/learn/lecture/8533944?start=975#overview

    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context;
        internal DbSet<T> dbSet;

        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Comit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = Find(Id);
            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            //Look for modified object and persist to DB
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
