using System;
using Exceptions;
using Models.Model;
using Repository;

namespace Service
{
	public class StudentService: IStudentService
	{
		private readonly IUnitOfWork _unitOfWork;
		public StudentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public Student GetById(int id)
		{
			if (id != 0)
			{
				// throw new BaseException(1234, "全局异常过滤测试"); // BaseException异常是可以返回前端让用户看到的
				throw new BaseException();
				// throw new Exception("全局异常过滤测试"); // Exception异常只能在日志中看到，禁止前端用户查看
			}
			return _unitOfWork.StudentRepository.GetById(id);
			// return _studentRepository.GetByID(id);
		}
	}
}
