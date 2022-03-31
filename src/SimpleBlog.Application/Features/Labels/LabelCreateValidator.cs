using FluentValidation;
using SimpleBlog.Share.Wrapper;

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