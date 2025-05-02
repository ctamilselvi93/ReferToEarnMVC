using System.ComponentModel.DataAnnotations;

namespace ReferToEarnMVC.Models
{
    public class RegisterView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string MobileNumber { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReferralCode { get; set; }
    }
}