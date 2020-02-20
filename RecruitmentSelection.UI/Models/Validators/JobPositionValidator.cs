using FluentValidation;

namespace RecruitmentSelection.UI.Models.Validators
{
    public class JobPositionValidator : AbstractValidator<JobPosition>
    {
        public JobPositionValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.MinimumSalary).GreaterThan(0).LessThan(x => x.MaximumSalary);
            RuleFor(x => x.MaximumSalary).GreaterThan(0).GreaterThan(x => x.MinimumSalary);
        }
    }
}
