using SanCamp.Data.Repositories.Interfaces;
using SanCamp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanCamp.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }

        public List<User> GetActive()
        {
            return _context.Users
                .Where(user => user.IsActive == user.IsActive)
                .ToList();
        }
    }
}
