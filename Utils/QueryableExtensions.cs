using System.Linq;

namespace Utils
{
	public static class QueryableExtensions
	{
		/// <summary>
		/// 分页
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="query"></param>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> query, int pageIndex, int pageSize)
		{
			int totalCount = query.Count<T>();
			IQueryable<T> source = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
			return new PaginatedList<T>(pageIndex, pageSize, totalCount, source);
		}
	}
}