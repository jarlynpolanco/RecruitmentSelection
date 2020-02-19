using RecruitmentSelection.UI.Models.Abtract;
using RecruitmentSelection.UI.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    //Capacitaciones
    public class Training: BaseEntity
    {
        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Nivel")]
        public Level Level { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime InitialDate { get; set; }

        [Required]
        [Display(Name = "Fecha Termino")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Institución")]
        public string Institution { get; set; }

        [Required]
        [Display(Name = "Candidato")]
        public int CandidateID { get; set; }
        [Display(Name = "Candidato")]
        public Candidate Candidate { get; set; }
    }
}
