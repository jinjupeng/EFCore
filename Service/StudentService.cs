using System;
using Model;
using Repository;

namespace Service
{
	public class StudentService: IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		public Student GetById(string id)
		{
			return _studentRepository.GetByID(id);
		}
	}
}
