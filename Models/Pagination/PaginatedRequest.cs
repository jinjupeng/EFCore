namespace Models.Pagination
{
    public class PaginatedRequest
    {
        public int PageIndex { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public PaginatedRequest()
        {
        }

        public PaginatedRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
	}
}