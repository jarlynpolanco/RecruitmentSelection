using RecruitmentSelection.UI.Models.Abtract;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    public class Languages : BaseEntity
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool State { get; set; }

        [Required]
        [Display(Name = "Candidato")]
        public int CandidateID { get; set; }

        [Display(Name = "Candidato")]
        public Candidate Candidate { get; set; }
    }
}
