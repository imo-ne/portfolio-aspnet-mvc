namespace Web_IB.Models
{
    public class ProfilDetailsViewModel
    {
        public int Id { get; set; }
        public string NomComplet { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public string? Bio { get; set; }
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
    }
}
