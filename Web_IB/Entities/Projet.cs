using System.ComponentModel.DataAnnotations;

namespace Web_IB.Entities
{
    public class Projet: Base
    {
        [Required, StringLength(120)]
        public string Titre { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(200)]
        public string? Lien { get; set; } 

        public int PersonneId { get; set; }
        public Personne? Personne { get; set; }
    }
}
