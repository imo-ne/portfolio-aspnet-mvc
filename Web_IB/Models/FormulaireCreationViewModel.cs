using System.ComponentModel.DataAnnotations;

namespace Web_IB.Models
{
    public class FormulaireCreationViewModel
    {
        [Required, StringLength(50)]
        public string Nom { get; set; } = string.Empty;

        [StringLength(100)]
        public string Prenom { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, DataType(DataType.Password), StringLength(200)]
        public string MotDePasse { get; set; } = string.Empty;

        public string? Photo { get; set; }
        public string? Bio { get; set; }
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
    }
}
