using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Common.DomainObjects.Interfaces
{
    public interface ICmdRepository<T> : IRepository<T> where T : EntityDO
    {
        #region Refresh

        void RefreshEntity(T entity);
        Task RefreshEntityAsync(T entity);
        #endregion Refresh

        #region Add

        T Add(T newEntity);
        Task<T> AddAsync(T newEntity);
        Task AddRangeAsync(IEnumerable<T> newEntities);

        #endregion Add

        #region Update
        void UpdateRange(IEnumerable<T> existsEntity);
        T Update(T updateEntity);
        void Update(T updateEntity, params string[] changedProperties);
        void Update(T updateEntity, params Expression<Func<T, object>>[] changedProperties);
        void UpdateWhere(Expression<Func<T,bool>> predicate,T entityNewData, params Expression<Func<T,object>>[] changedProperties);
        void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params string[] changedProperties);
        #endregion Update

        #region Delete

        T Remove(T deleteEntity);
        void RemoveRange(List<T> newEntities);
        void Remove(Expression<Func<T, bool>> predicate);

        #endregion Delete

        #region Get

        Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        #endregion Get

        #region Check

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        #endregion Check
        #region Helpers
        Task<int> BaseCheckPermistion(int RecordId = 0, int AccountId = 0, int ActionId = 0, string TableName = "", int @FunctionCUD = 0);
        #endregion Helpers
    }

}