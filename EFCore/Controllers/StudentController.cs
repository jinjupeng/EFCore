using Microsoft.AspNetCore.Mvc;
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
			var id = 1;
			return new JsonResult(_student.GetById(id));
		}
	}
}