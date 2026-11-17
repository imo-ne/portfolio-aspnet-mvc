using System.ComponentModel.DataAnnotations;

namespace Web_IB.Entities
{
    public class Experience : Base
    {
        [Required, StringLength(120)]
        public string Poste { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string Entreprise { get; set; } = string.Empty;

        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }

        [StringLength(1000)]
        public string? Description { get; set; }

        public int PersonneId { get; set; }
        public Personne? Personne { get; set; }
    }
}
