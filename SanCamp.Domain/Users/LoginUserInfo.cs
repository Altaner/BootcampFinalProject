using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SanCamp.Domain.Users
{
    public class LoginUserInfo
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Agency { get; set; }
    }
}
