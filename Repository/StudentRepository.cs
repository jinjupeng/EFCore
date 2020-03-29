using Models;
using Models.Model;

namespace Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(EfCoreContext context): base(context)
        {

        }
    }
}