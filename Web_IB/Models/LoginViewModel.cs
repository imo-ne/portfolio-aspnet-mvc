using System.ComponentModel.DataAnnotations;

namespace Web_IB.Models
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password)]
        public string MotDePasse { get; set; } = string.Empty;
    }
}
