using System.ComponentModel.DataAnnotations;

namespace ReferToEarnMVC.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string ReferralCode { get; set; }

        public string ReferredBy { get; set; }

        public int Points { get; set; }
    }
}