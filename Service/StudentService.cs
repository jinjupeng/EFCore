using System;
using Model;
using Repository;

namespace Service
{
	public class StudentService: IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IUnitOfWork _unitOfWork;
		public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
		{
			_studentRepository = studentRepository;
			_unitOfWork = unitOfWork;
		}

		public Student GetById(string id)
		{
			return _unitOfWork.StudentRepository.GetByID(id);
			// return _studentRepository.GetByID(id);
		}
	}
}
