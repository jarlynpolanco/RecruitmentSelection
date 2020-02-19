using RecruitmentSelection.UI.Models.Abtract;
using System;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models
{
    public class Employee:BaseEntity
    {
        [Required]
        [Display(Name = "Cédula")]
        public string DocumentNumber { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Fecha Ingreso")]
        public DateTime InitialDate { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "Posición Laboral")]
        public int JobPositionID { get; set; }

        [Display(Name = "Posición Laboral")]
        public JobPosition JobPosition { get; set; }

        [Required]
        [Display(Name = "Salario")]
        public double Salary { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool Status { get; set; }
    }
}
