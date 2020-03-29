using System;
using Models.Model;
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

		public Student GetById(int id)
		{
			return _unitOfWork.StudentRepository.GetById(id);
			// return _studentRepository.GetByID(id);
		}
	}
}
