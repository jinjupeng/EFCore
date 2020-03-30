using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Models.DTO;
using Models.Model;
using Utils;

namespace Service
{
	public interface IStudentService
	{
		Student GetById(int id);

		PaginatedList<Student> GetList(int pageIndex, int pageSize, Expression<Func<Student, DateTime>> keySelector, Expression<Func<Student, bool>> predicate, params Expression<Func<Student, object>>[] includeProperties);
		bool Insert(Student student);

		bool Update(Student student);

		bool Delete(int id);
	}
}