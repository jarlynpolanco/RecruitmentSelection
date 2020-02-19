using System.ComponentModel.DataAnnotations;

namespace RecruitmentSelection.UI.Models.Abtract
{
    public abstract class BaseEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
