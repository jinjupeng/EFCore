using Models.Pagination;

namespace Models.DTO
{
    public class StudentDto: PaginatedRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
    }
}