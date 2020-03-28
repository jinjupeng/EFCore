using System;

namespace Repository
{
	public interface IUnitOfWork : IDisposable
	{ 
		IStudentRepository StudentRepository { get; }
	}
}