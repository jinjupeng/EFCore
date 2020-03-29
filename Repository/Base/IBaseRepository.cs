using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Utils;

namespace Repository.Base
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");

		IQueryable<TEntity> Set();
		bool Any(Expression<Func<TEntity, bool>> filter = null);
		IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
		int Count(Expression<Func<TEntity, bool>> filter = null);
		IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);

		PaginatedList<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector,
			Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

		TEntity GetById(object id);
		void Insert(TEntity entity);
		void InsertRange(IEnumerable<TEntity> entities);
		void Delete(object id);
		void Update(TEntity entityToUpdate);
		void Update(TEntity entityToUpdate, Expression<Func<TEntity, object>> propertySelector);
		void Restore(TEntity entityToUpdate);
		IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters);
		void ExecSql(string sql, Dictionary<string, object> paramDic);

	}
}