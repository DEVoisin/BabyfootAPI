using BabyfootAPI.Models;
using FluentValidation;

namespace BabyfootAPI.Validators
{
    public class RankValidator : AbstractValidator<Rank>
    {
        public RankValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EloMin).GreaterThanOrEqualTo(0);
            RuleFor(x => x.EloMax).GreaterThan(x => x.EloMin).WithMessage("EloMax doit être plus grand que EloMin");
        }
    }
}
