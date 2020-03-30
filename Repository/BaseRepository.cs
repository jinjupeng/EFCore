using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Base;
using Utils;

namespace Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
	{
        protected internal EfCoreContext Context;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(EfCoreContext context)
        {
            this.Context = context;
            DbSet = context.Set<TEntity>();
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filter"></param>
		/// <param name="orderBy"></param>
		/// <param name="includeProperties"></param>
		/// <returns></returns>
		public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
		{
			IQueryable<TEntity> queryable = DbSet;
			if (filter != null)
			{
				queryable = queryable.Where(filter);
			}
			string[] array = includeProperties.Split(new char[1]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			foreach (string path in array)
			{
				queryable = queryable.Include(path);
			}
			if (orderBy != null)
			{
				return orderBy(queryable).ToList();
			}
			return queryable.ToList();
		}

		public virtual IQueryable<TEntity> Set()
		{
			return Context.Set<TEntity>();
		}

		public virtual bool Any(Expression<Func<TEntity, bool>> filter = null)
		{
			if (filter != null)
			{
				return DbSet.Any(filter);
			}
			return false;
		}

		public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
		{
			return Context.Set<TEntity>().Where(predicate);
		}

		public virtual int Count(Expression<Func<TEntity, bool>> filter = null)
		{
			if (filter != null)
			{
				return DbSet.Count(filter);
			}
			return DbSet.Count();
		}

		public virtual IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> queryable = Context.Set<TEntity>();
			foreach (Expression<Func<TEntity, object>> path in includeProperties)
			{
				queryable = queryable.Include(path);
			}
			return queryable;
		}

		public virtual PaginatedList<TEntity> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> keySelector, Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
		{
			IQueryable<TEntity> queryable = AllIncluding(includeProperties).OrderByDescending(keySelector);
			queryable = ((predicate == null) ? queryable : queryable.Where(predicate));
			return queryable.ToPaginatedList(pageIndex, pageSize);
		}

		public virtual TEntity GetById(object id)
		{
			return DbSet.Find(id);
		}

		public virtual void Insert(TEntity entity)
		{
			try
			{
				DbSet.Add(entity);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual void InsertRange(IEnumerable<TEntity> entities)
		{
			try
			{
				DbSet.AddRange(entities);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public virtual void Delete(object id)
		{
			TEntity entityToDelete = DbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (Context.Entry(entityToDelete).State == EntityState.Detached)
			{
				DbSet.Attach(entityToDelete);
			}
			DbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			DbSet.Attach(entityToUpdate);
			Context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public virtual void Update(TEntity entityToUpdate, Expression<Func<TEntity, object>> propertySelector)
		{
			DbSet.Attach(entityToUpdate);
			NewExpression newExpression = propertySelector.Body as NewExpression;
			if (newExpression != null)
			{
				foreach (MemberInfo member in newExpression.Members)
				{
					Context.Entry(entityToUpdate).Property(member.Name).IsModified = true;
				}
			}
		}

		public virtual void Restore(TEntity entityToUpdate)
		{
			Context.Entry(entityToUpdate).State = EntityState.Unchanged;
		}

		public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
		{
			return DbSet.FromSqlRaw(query, parameters).ToList();
		}

		public void ExecSql(string sql, Dictionary<string, object> paramDic)
		{
			List<SqlParameter> list = new List<SqlParameter>();
			if (paramDic != null)
			{
				foreach (string key in paramDic.Keys)
				{
					list.Add(new SqlParameter(key, paramDic[key]));
				}
			}
			Context.Database.ExecuteSqlRaw(sql, list.ToArray());
		}

	}

}