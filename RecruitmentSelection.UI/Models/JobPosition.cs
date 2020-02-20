using RecruitmentSelection.UI.Models.Abtract;
using RecruitmentSelection.UI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    public class JobPosition:BaseEntity
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Riesgo")]
        public RiskLevel Risk { get; set; }

        [Required]
        [Display(Name = "Salario Mínimo")]
        public double MinimumSalary { get; set; }

        [Required]
        [Display(Name = "Salario Máximo")]
        public double MaximumSalary { get; set; }

        [Required]
        [Display(Name =  "Estado")]
        public bool Status { get; set; }
    }
}
