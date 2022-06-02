using System;

namespace SanCamp.Domain.Users
{
    public class User
    {
        #region Basic info
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
