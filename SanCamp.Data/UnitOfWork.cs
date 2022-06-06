using SanCamp.Data.Repositories;
using SanCamp.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanCamp.Data
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository Users { get; }
        void Complete();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _context;
        public IUserRepository Users { get; private set; }
        public UnitOfWork(UserDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
