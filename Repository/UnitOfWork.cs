using System;
using Exceptions;
using Models;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfCoreContext _context;

        public UnitOfWork(EfCoreContext context)
        {
            _context = context;
        }

        private IStudentRepository _studentRepository;
        public IStudentRepository StudentRepository => _studentRepository ?? (_studentRepository = new StudentRepository(_context));

        private bool _disposed;

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
		}

        /// <summary>
        /// 保存事务方法
        /// </summary>
        /// <param name="action"></param>
        public void Save(Action action)
        {
            using var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                action();
                _context.SaveChanges();
                dbContextTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                if (ex is BaseException ex2)
                {
                    throw ex2;
                }
                throw new Exception("保存事务时发生错误", ex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
