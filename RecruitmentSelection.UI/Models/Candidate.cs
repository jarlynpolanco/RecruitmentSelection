using RecruitmentSelection.UI.Models.Abtract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    public class Candidate:BaseEntity
    {
        [Required]
        [Display(Name = "Cédula")]
        public string DocumentNumber { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Posición Laboral")]
        public int JobPositionID { get; set; }
        public JobPosition JobPosition { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "Salario deseado")]
        public double SalaryWished { get; set; }

        [Required]
        [Display(Name = "Idioma")]
        public string Languages { get; set; }

        public virtual ICollection<Proficiency> Proficiencies { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<JobExperience> JobExperiences { get; set; }
        public virtual ICollection<Languages> LanguagesList { get; set; }

        [Required]
        [Display(Name = "Recomendado por")]
        public string RecommendedBy { get; set; }

    }
}
