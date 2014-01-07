namespace GenericEfRepository
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(DbContext dbContext)
        {
            this.Context = dbContext;
            this.DbSet = this.Context.Set<T>();
        }

        public DbSet<T> DbSet { get; set; }

        public DbContext Context { get; set; }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> GetAll(T filter)
        {
            throw new System.NotImplementedException();
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public object Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }
    }
}
