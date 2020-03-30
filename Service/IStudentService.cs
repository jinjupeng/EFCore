using Models.Model;

namespace Service
{
	public interface IStudentService
	{
		Student GetById(int id);
		Student SaveStudent(Student student);
	}
}