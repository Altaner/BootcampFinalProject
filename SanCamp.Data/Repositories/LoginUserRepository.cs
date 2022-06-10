using SanCamp.Data.Repositories.Interfaces;
using SanCamp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SanCamp.Data.Repositories
{
    public class LoginUserRepository : Repository<LoginUserInfo>, ILoginUserRepository
    {
        private readonly UserDbContext _context;

        public LoginUserRepository(UserDbContext context) : base(context)
        {
            _context = context;
        }

        public LoginUserInfo GetUserById(int id)
        {
            return _context.LoginUsers.FirstOrDefault(x => x.Id == id);
        }

    }
}
