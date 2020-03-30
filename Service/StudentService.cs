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
			if (id == 0)
			{
				throw new BaseException(1000, "全局异常过滤测试"); // BaseException异常是可以返回前端让用户看到的
				// throw new BaseException();
				// throw new Exception("全局异常过滤测试"); // Exception异常只能在日志中看到，禁止前端用户查看
			}
			return _unitOfWork.StudentRepository.GetById(id);
		}

		public Student SaveStudent(Student student)
		{
			// 插入一条数据，主键id自增加1，并返回给实体对象student
			_unitOfWork.StudentRepository.Insert(student);
			// 保存到数据库
			_unitOfWork.Save();
			return _unitOfWork.StudentRepository.GetById(student.Id);
		}

		public Student Update(Student student)
		{
			_unitOfWork.StudentRepository.Update(student);
			_unitOfWork.Save();
			return student;
		}

		public Student Delete(int id)
		{
			// 事务删除
			_unitOfWork.Save(delegate { _unitOfWork.StudentRepository.Delete(id); });
			
			return _unitOfWork.StudentRepository.GetById(id);
		}
	}
}
