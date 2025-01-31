using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AccessData.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace AccessData.Generico
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal BdInfraccionesContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(BdInfraccionesContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> ObtenerTodo(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity ObtenerTodoPorId(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Crear(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Borrar(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Borrar(entityToDelete);
        }

        public virtual void Borrar(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Actualizar(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}