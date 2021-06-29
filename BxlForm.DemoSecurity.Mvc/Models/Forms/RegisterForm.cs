using BxlForm.DemoSecurity.Mvc.Infrastructure;
using BxlForm.DemoSecurity.Mvc.Infrastructure.Validation;
using System.ComponentModel.DataAnnotations;

namespace BxlForm.DemoSecurity.Mvc.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-=]).{8,20}$")]  
        public string Passwd { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Passwd))]
        public string Confirm { get; set; }
    }
}
