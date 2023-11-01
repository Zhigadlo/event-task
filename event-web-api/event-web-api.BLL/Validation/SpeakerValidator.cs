using Entities;
using FluentValidation;

namespace event_web_api.BLL.Validation
{
    public class SpeakerValidator : AbstractValidator<Speaker>
    {
        public SpeakerValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("First name can't be empty");
            RuleFor(s => s.LastName).NotEmpty().WithMessage("Last name can't be empty");
        }
    }
}
