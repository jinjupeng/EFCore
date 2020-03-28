using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

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
		public JsonResult Get()
		{
			var id = "236d37d4f3c14dd489b1c7270c7670ad";
			return new JsonResult(_student.GetById(id));
		}
	}
}