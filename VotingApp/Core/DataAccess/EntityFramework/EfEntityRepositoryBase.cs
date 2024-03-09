using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> 
        where TContext: DbContext, new() 
        where TEntity: class, IEntity ,new()
    {
        //Add, Delete, Update, GetAll, GetByID
        public void Add(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context=new TContext())
            {
                var updatedEntry = context.Entry(entity);
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity GetById(int id)
        {
            using (TContext context=new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(x => x.ID == id);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity,bool>> filter=null)
        {
            using (TContext context = new TContext())
            {
                var result = filter == null ? context.Set<TEntity>() : context.Set<TEntity>().Where(filter);
                return result.ToList();
            }
        }
    }
}
