using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Exceptions;
using Models.DTO;
using Models.Model;
using Repository;
using Utils;

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

		public bool Insert(Student student)
		{
			// 插入一条数据，主键id自增加1，并返回给实体对象student
			_unitOfWork.StudentRepository.Insert(student);
			// 保存到数据库
			return _unitOfWork.Save() > 0;
		}

		public bool Update(Student student)
		{
			_unitOfWork.StudentRepository.Update(student);
			return _unitOfWork.Save() > 0;
		}

		public bool Delete(int id)
		{
			_unitOfWork.StudentRepository.Delete(id);
			// 事务删除
			return _unitOfWork.Save() > 0;
		}

		public PaginatedList<Student> GetList(int pageIndex, int pageSize, Expression<Func<Student, DateTime>> keySelector, Expression<Func<Student, bool>> predicate, params Expression<Func<Student, object>>[] includeProperties)
		{
			return _unitOfWork.StudentRepository.Paginate(pageIndex, pageSize, keySelector, predicate, includeProperties);
		}
	}
}
