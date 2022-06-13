using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SanCamp.Domain.Users
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Kullanıcı adınız 6 ile 50 karakter arasında olmalıdır!")]
        public string UserName { get; set; }
        [Required]
        [StringLength(254, ErrorMessage = "E-posta adresiniz çok uzun!")]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Parolanız 6 ile 20 karakter arasında olmalıdır!")]
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        [AllowNull]
        public bool IsActive { get; set; }
    }
}
