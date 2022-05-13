using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.DataContext;
using WebAPI.DataModel;

namespace WebAPI.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : BaseDataModel
    {
        protected readonly CardSystemDataContext context = null;
        private DbSet<T> table = null;

        public GenericRepository(CardSystemDataContext _context)
        {
            this.context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll_old()
        {
            return table.ToList();
        }
        public IQueryable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? isActive = true)
        {
            var query = this.GetQueryable(filter, orderBy, String.Empty, isActive);
            //var result = query.ToListAsync();

            return query;
        }

        public IQueryable<T> GetById(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            bool? isActive = true)
        {
            var query = this.GetQueryable(filter, orderBy, includeProperties, isActive);
            //var result = query
            //    .FirstOrDefaultAsync();

            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> GetQueryable(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            bool? isActive = true)
        {
            IQueryable<T> query = table;
            /***
             * query returns all of the records and is done in memory later if using IEnumberable collection
             * query sent to SQL server with search criteria if using IQueryable 
             * */

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
                query = orderBy(query);
            }

            // IsActive is a soft-delete column, only select the record that with IsActive = true
            query = query.Where(p=>p.IsActive == isActive );

            return query;
        }

        public void Insert(T obj)
        {
            // default value: set sort delete flag = inactive
            obj.IsActive = true;
            obj.CreatedDate = DateTime.Now;
            obj.UpdatedDate = DateTime.Now;
            table.Add(obj);
        }
        public void Update(T obj)
        {
            obj.UpdatedDate = DateTime.Now;

            table.Attach(obj);
            this.context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T entityToDelete = table.Find(id);
            if (entityToDelete != null)
            {
                entityToDelete.UpdatedDate = DateTime.Now;

                // this is really delete
                //this.table.Remove(entityToDelete);

                // this is soft delete
                entityToDelete.IsActive = false;
                this.Update(entityToDelete);
            }
        }
        public virtual void Delete(T entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.table.Attach(entityToDelete);
            }
            entityToDelete.UpdatedDate = DateTime.Now;

            // this is really delete
            //this.table.Remove(entityToDelete);

            // this is soft delete
            entityToDelete.IsActive = false;

            this.Update(entityToDelete);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
