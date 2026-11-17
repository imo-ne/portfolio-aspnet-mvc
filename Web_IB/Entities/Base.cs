using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_IB.Entities
{
    public class Base
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        public int? CreePar { get; set; }
        public bool? EstSupprime { get; set; }
        public DateTime? SupprimeA { get; set; }
        public int? SupprimePar { get; set; }
    }
}
