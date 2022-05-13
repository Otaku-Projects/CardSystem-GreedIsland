using System.Linq.Expressions;
using WebAPI.DataModel;

namespace WebAPI.Repository
{
    public interface IGenericRepository<T> where T : BaseDataModel
    {
        IQueryable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool? isActive = true);
        IQueryable<T> GetById(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            bool? isActive = true);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Delete(T obj);
        void Save();
    }
}
