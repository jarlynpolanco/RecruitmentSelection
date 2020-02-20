using FluentValidation;

namespace RecruitmentSelection.UI.Models.Validators
{
    public class TrainingValidator : AbstractValidator<Training>
    {
        public TrainingValidator() 
        {
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.InitialDate).LessThan(x => x.EndDate);
            RuleFor(x => x.EndDate).GreaterThan(x => x.InitialDate);
            RuleFor(x => x.Institution).NotEmpty().NotNull();
        }
    }
}
