using SanCamp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SanCamp.Data.Repositories.Interfaces
{
    public interface ILoginUserRepository
    {
        public LoginUserInfo GetUserById(int id);
    }
}
