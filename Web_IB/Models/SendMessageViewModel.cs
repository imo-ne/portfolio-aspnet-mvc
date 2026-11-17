using System.ComponentModel.DataAnnotations;

namespace Web_IB.Models
{
    public class SendMessageViewModel
    {
        public int DestinataireId { get; set; }
        public string DestinataireNom { get; set; } = string.Empty;

        [Required, StringLength(1200)]
        public string Contenu { get; set; } = string.Empty;
    }
}
