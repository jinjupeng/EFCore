using System;
using System.ComponentModel;
using Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using Service;
using Utils;

namespace EFCore.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	[Filters.UserAuthorizeAttribute(Filters.AuthorizeLevel.Low)]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _student;

		public StudentController(IStudentService student)
		{
			_student = student;
		}

		[HttpGet]
		[Description("查询学生信息")]
		public JsonResult Get(int id)
		{
			return new JsonResult(new ResponseDataHelper2<Student>
			{
				ResponseData = _student.GetById(id)
			});
		}

		[HttpPost]
		[Description("新增学生信息")]
		public JsonResult Add(Student student)
		{
			var result = "";
			if (student == null)
			{
				throw new BaseException(1000, "数据不能为空");
			}

			student.CreateDate = DateTime.Now;
			result = _student.Insert(student) ? "新增成功" : "新增失败";

			return new JsonResult(new ResponseDataHelper2<string>
			{
				ResponseData = result
			});
		}

		[HttpPost]
		[Description("更新学生信息")]
		public JsonResult Update(Student student)
		{
			var result = "";
			if (student == null)
			{
				throw new BaseException(1000, "数据不能为空");
			}

			result = _student.Update(student) ? "更新成功" : "更新失败";

			return new JsonResult(new ResponseDataHelper2<string>
			{
				ResponseData = result
			});
		}

		[HttpPost]
		[Description("新增或更新学生信息")]
		public JsonResult CreateOrUpdate(Student student)
		{
			var result = "";
			if (student.Id > 0)
			{
				student.IsDelete = false;
				student.UpdateDate = DateTime.Now;
				result = _student.Update(student) ? "新增成功" : "新增失败";
				
			}
			else
			{
				student.IsDelete = false;
				student.CreateDate = DateTime.Now;
				result = _student.Insert(student) ? "更新成功" : "更新失败";
			}
			return new JsonResult(new ResponseDataHelper2<string>
			{
				ResponseData = result
			});
		}

		[HttpDelete]
		[Description("删除学生信息")]
		public JsonResult Delete(int id)
		{
			return new JsonResult(new ResponseDataHelper2<string>
			{
				ResponseData = _student.Delete(id) ? "删除成功" : "删除失败"
			});
		}
	}
}