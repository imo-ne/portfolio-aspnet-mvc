namespace Web_IB.Models
{
    public class PortfolioViewModel
    {
        public List<SkillItemVM> Skills { get; set; } = new();
        public List<ProjectItemVM> Projects { get; set; } = new();
        public List<ExperienceItemVM> Experiences { get; set; } = new();
    }
    public class SkillItemVM
    {
        public int Id { get; set; }
        public string Nom { get; set; } = "";
        public string? Niveau { get; set; }
    }

    public class ProjectItemVM
    {
        public int Id { get; set; }
        public string Titre { get; set; } = "";
        public string? Description { get; set; }
        public string? Lien { get; set; }
    }

    public class ExperienceItemVM
    {
        public int Id { get; set; }
        public string Poste { get; set; } = "";
        public string Entreprise { get; set; } = "";
        public string Periode { get; set; } = "";
        public string? Description { get; set; }
    }
}
