using System.ComponentModel.DataAnnotations;
using Web_IB.shared;

namespace Web_IB.Entities
{
    public class Competence : Base
    {
        [Required, StringLength(80)]
        public string Nom { get; set; } = string.Empty;

        [StringLength(40)]
        public NiveauCompetence? Niveau { get; set; }

        public int PersonneId { get; set; }
        public Personne? Personne { get; set; }
    }
}
