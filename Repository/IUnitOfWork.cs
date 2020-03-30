using System;

namespace Repository
{
	public interface IUnitOfWork : IDisposable
	{ 
		IStudentRepository StudentRepository { get; }
		int Save();
		void Save(Action action);
	}
}