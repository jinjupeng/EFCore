using System;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;
using Utils;

namespace EFCore.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _student;

		public StudentController(IStudentService student)
		{
			_student = student;
		}
		[HttpGet]
		public JsonResult Get()
		{
			var id = 1;
			return new JsonResult(_student.GetById(id));
		}

		[HttpGet]
		public JsonResult Set()
		{
			var student = new Student
			{
				Name = "张三",
				Grade = 100,
				Age = 18,
				IsDelete = false,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				CreateUserId = "",
				UpdateUserId = ""
			};
			return new JsonResult(new ResponseDataHelper2<Student>
			{
				ResponseData = _student.SaveStudent(student)
			});
		}

		[HttpGet]
		public JsonResult Update()
		{
			var student = _student.GetById(1);
			student.Age = 28;
			student.Name = "孙悟空";
			return new JsonResult(new ResponseDataHelper2<Student>
			{
				ResponseData = _student.Update(student)
			});
		}

		[HttpGet]
		public JsonResult Delete()
		{
			return new JsonResult(new ResponseDataHelper2<Student>
			{
				ResponseData = _student.Delete(3)
			});
		}
	}
}