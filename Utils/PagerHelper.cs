using System;

namespace Utils
{
	[Serializable]
	public class PagerHelper
	{
		public PagerHelper()
		{
			this.pageSize = 1;
			this.dataCount = 0;
		}




		public int PageSize
		{
			get
			{
				return this.pageSize;
			}
			set
			{
				this.pageSize = value;
			}
		}




		public int DataCount
		{
			get
			{
				return this.dataCount;
			}
			set
			{
				this.dataCount = value;
			}
		}



		public int PageCount
		{
			get
			{
				return this.DataCount / this.PageSize + ((this.DataCount % this.PageSize == 0) ? 0 : 1);
			}
		}


		private int pageSize;


		private int dataCount;

	}
}