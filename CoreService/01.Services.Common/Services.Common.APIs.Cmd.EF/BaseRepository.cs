using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Services.Common.APIs.Cmd.EF.Extensions;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Common.APIs.Cmd.EF
{
    public class BaseRepository<T> : ICmdRepository<T> where T : EntityDO
    {
        public BaseRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }

        protected readonly DbSet<T> _dbSet;
        protected readonly BaseDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        #region Refresh

        public virtual void RefreshEntity(T entity)
        {
            _dbContext.Entry(entity).Reload();
        }
        public async Task RefreshEntityAsync(T entity)
        {
            await _dbContext.Entry(entity).ReloadAsync();
        }

        #endregion Refresh

        #region Add

        public virtual async Task AddRangeAsync(IEnumerable<T> newEntities)
        {
            try
            {
                await _dbSet.AddRangeAsync(newEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual T Add(T newEntity)
        {
            try
            {
                return _dbContext.Add(newEntity).Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<T> AddAsync(T newEntity)
        {
            try
            {
                return (await _dbContext.AddAsync(newEntity)).Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Add

        #region Update
        public void UpdateRange(IEnumerable<T> existsEntities)
        {
            try
            {
                _dbSet.UpdateRange(existsEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual T Update(T updateEntity)
        {
            try
            {
                return _dbContext.Update(updateEntity).Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual void Update(T updateEntity, params string[] changedProperties)
        {
            TryAttach(updateEntity);
            changedProperties = changedProperties?.Distinct().ToArray();
            if (changedProperties?.Any() == true)
            {
                foreach (var property in changedProperties)
                {
                    _dbContext.Entry(updateEntity).Property(property).IsModified = true;
                }
            }
            else
            {
                _dbContext.Entry(updateEntity).State = EntityState.Modified;
            }
        }
        public virtual void Update(T updateEntity, params Expression<Func<T, object>>[] changedProperties)
        {
            TryAttach(updateEntity);
            changedProperties = changedProperties?.Distinct().ToArray();
            if (changedProperties?.Any() == true)
            {
                foreach (var property in changedProperties)
                {
                    _dbContext.Entry(updateEntity).Property(property).IsModified = true;
                }
            }
            else
            {
                _dbContext.Entry(updateEntity).State = EntityState.Modified;
            }
        }
        public void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params Expression<Func<T, object>>[] changedProperties)
        {
            throw new NotImplementedException();
        }
        public void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params string[] changedProperties)
        {
            throw new NotImplementedException();
        }

        #endregion Update

        #region Delete

        public virtual T Remove(T deleteEntity)
        {
            try
            {
                return _dbContext.Remove(deleteEntity).Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Remove(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveRange(List<T> newEntities)
        {
            try
            {
                _dbContext.RemoveRange(newEntities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Delete

        #region Get
        public virtual Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(predicate).ToListAsync();
        }
        public virtual Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().SingleOrDefaultAsync(predicate);
        }
        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().FirstOrDefaultAsync(predicate);
        }
        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().CountAsync(predicate);
        }
        public virtual IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbSet.AsNoTracking();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);

            }
            return query;
        }
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbSet.AsNoTracking();
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() == true)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }

            return predicate == null ? query : query.Where(predicate);
        }
        public virtual T GetSingle(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(predicate, includeProperties).FirstOrDefault();
        }
        public virtual Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbSet.AsQueryable().Where(predicate);
            var queryable = includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return queryable.SingleOrDefaultAsync();
        }
        #endregion Get
        #region Store Procedure
        public DbCommand GetStoredProcedure(
           string name,
           params (string, object)[] nameValueParams)
        {
            return _dbContext
                .LoadStoredProcedure(name)
                .WithSqlParams(nameValueParams);
        }
        public DbCommand GetStoredProcedure(string name)
        {
            return _dbContext.LoadStoredProcedure(name);
        }
       
        //public virtual Task<Object> ExecuteSQLDefaultAsync(string StoreProcedure, List<SqlParameter> Parameters)
        //{
        //    var cmd = _dbContext.Database.GetDbConnection().CreateCommand());

        //    cmd.Connection.OpenAsync();
        //    cmd.CommandText = StoreProcedure;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    foreach (var parameter in Parameters)
        //    {
        //        cmd.Parameters.Add(parameter);
        //    }

        //    return await cmd.ExecuteScalarAsync().ConfigureAwait(false);

        //    //return queryable.SingleOrDefaultAsync();
        //}
        #endregion Store Procedure
        #region Any

        public virtual Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AsQueryable().AnyAsync(predicate);
        }

        #endregion Any

        #region Helpers

        protected virtual void TryAttach(T entity)
        {
            try
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public virtual int BaseCheckPermistion(List<SqlParameter> Parameters)
        {
            //var cmd = _dbContext.Database.GetDbConnection().CreateCommand();
            //cmd.Connection.OpenAsync();
            //cmd.CommandText = StoreProcedure;
            //cmd.CommandType = CommandType.StoredProcedure;
            //foreach (var parameter in Parameters)
            //{
            //    cmd.Parameters.Add(parameter);
            //}

            //return await cmd.ExecuteScalarAsync().ConfigureAwait(false);

            ////return queryable.SingleOrDefaultAsync();
            return 1;
        }
        #endregion Helpers
    }
}