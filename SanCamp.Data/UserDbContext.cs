using Microsoft.EntityFrameworkCore;
using SanCamp.Domain.Users;
using System;

namespace SanCamp.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LoginUserInfo> LoginUsers { get; set; }
    }
}
