using RecruitmentSelection.UI.Models.Abtract;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    //Experiencia Laboral
    public class JobExperience:BaseEntity
    {
        [Required]
        [Display(Name = "Empresa")]
        public string Bussiness { get; set; }

        [Required]
        [Display(Name = "Posición")]
        public string JobPosition { get; set; }

        [Required]
        [Display(Name = "Fecha Ingreso")]
        public DateTime InitialDate { get; set; }

        [Required]
        [Display(Name = "Fecha Egreso")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "Salario")]
        public double Salary { get; set; }

        [Required]
        [Display(Name = "Candidato")]
        public int CandidateID { get; set; }

        [Display(Name = "Candidato")]
        public Candidate Candidate { get; set; }
    }
}
