using Model;

namespace Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(CoreNotesAutoFacContext context): base(context)
        {

        }
    }
}