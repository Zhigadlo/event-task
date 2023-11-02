using Entities;
using FluentValidation;

namespace event_web_api.BLL.Validation
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(e => e.Theme).NotEmpty().WithMessage("Theme can't be empty");
            RuleFor(e => e.Place).NotEmpty().WithMessage("Place can't be empty");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description can't be empty");
            RuleFor(e => e.Date).NotEmpty().WithMessage("Date can't be empty")
                                .GreaterThan(DateTime.Now).WithMessage("Date can't be less than the current one");
        }
    }
}
