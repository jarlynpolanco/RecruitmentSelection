using FluentValidation;

namespace RecruitmentSelection.UI.Models.Validators
{
    public class JobExperienceValidator : AbstractValidator<JobExperience>
    {
        public JobExperienceValidator() 
        {
            RuleFor(x => x.Bussiness).NotEmpty().NotNull();
            RuleFor(x => x.JobPosition).NotEmpty().NotNull();
            RuleFor(x => x.InitialDate).LessThan(x => x.EndDate);
            RuleFor(x => x.EndDate).GreaterThan(x => x.InitialDate);
            RuleFor(x => x.Salary).GreaterThan(0);
        }
    }
}
