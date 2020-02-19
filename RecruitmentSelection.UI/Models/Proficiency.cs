using RecruitmentSelection.UI.Models.Abtract;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    //Competencias
    public class Proficiency: BaseEntity
    {
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool Status { get; set; }

        [Required]
        [Display(Name = "Candidato")]
        public int CandidateID { get; set; }

        [Display(Name = "Candidato")]
        public Candidate Candidate { get; set; }
    }
}
