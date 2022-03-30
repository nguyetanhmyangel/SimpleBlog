using FluentValidation;
using SimpleBlog.Application.Wrapper;

namespace SimpleBlog.Application.Features.Labels
{
    public class LabelCreateValidator : AbstractValidator<LabelCreateRequest>
    {
        public LabelCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(string.Format(Messages.Required, "Tên"));
        }
    }
}