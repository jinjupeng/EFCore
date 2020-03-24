using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
	public class PaginatedList<T> : List<T>
	{
		/// <summary>
		/// 第几页
		/// </summary>
		public int PageIndex { get; private set; }

		/// <summary>
		/// 每页大小
		/// </summary>
		public int PageSize { get; private set; }

		/// <summary>
		/// 总条数
		/// </summary>
		public int TotalCount { get; private set; }

		/// <summary>
		/// 总页数
		/// </summary>
		public int TotalPageCount { get; private set; }

		/// <summary>
		/// 是否有上一页
		/// </summary>
		public bool HasPreviousPage => this.PageIndex > 1;

		/// <summary>
		/// 是否有下一页
		/// </summary>
		public bool HasNextPage => this.PageIndex < this.TotalPageCount;

		/// <summary>
		/// 分页
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <param name="totalCount"></param>
		public PaginatedList(int pageIndex, int pageSize, int totalCount)
		{
			this.PageIndex = pageIndex;
			this.PageSize = pageSize;
			this.TotalCount = totalCount;
			this.TotalPageCount = (int)Math.Ceiling((double)totalCount / (double)pageSize);
		}


		public PaginatedList(int pageIndex, int pageSize, int totalCount, IQueryable<T> source) : this(pageIndex, pageSize, totalCount)
		{
			base.AddRange(source);
		}


		public PaginatedList(int pageIndex, int pageSize, int totalCount, IEnumerable<T> source) : this(pageIndex, pageSize, totalCount)
		{
			base.AddRange(source);
		}
	}
}
