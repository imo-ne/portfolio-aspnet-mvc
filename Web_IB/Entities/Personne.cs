using System.ComponentModel.DataAnnotations;

namespace Web_IB.Entities
{
    public class Personne : Base
    {
        [Required, StringLength(50)]
        public string Nom { get; set; } = string.Empty;

        [StringLength(100)]
        public string Prenom { get; set; } = string.Empty;

        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string MotDePasse { get; set; } = string.Empty;

        public string? Photo { get; set; } 

        [StringLength(1000)]
        public string? Bio { get; set; }

        [StringLength(200)]
        public string? LinkedIn { get; set; }

        [StringLength(200)]
        public string? GitHub { get; set; }
    }
}
