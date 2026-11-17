using System.ComponentModel.DataAnnotations;

namespace Web_IB.Entities
{
    public class Message : Base
    {
        [Required, StringLength(1200)]
        public string Contenu { get; set; } = string.Empty;

        public int ExpediteurId { get; set; }
        public Personne? Expediteur { get; set; }

        public int DestinataireId { get; set; }
        public Personne? Destinataire { get; set; }
    }
}
