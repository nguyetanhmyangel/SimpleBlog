using FluentValidation;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.Roles
{
    public class RoleRequestValidator : AbstractValidator<RoleRequest>
    {
        public RoleRequestValidator()
        {
            RuleFor(x => x.RoleNames).NotNull()
                .WithMessage(string.Format(Messages.Required, "Tên quyền"));

            RuleFor(x => x.RoleNames).Must(x => x.Length > 0)
                .When(x => x.RoleNames != null)
             .WithMessage(string.Format(Messages.Required, "Tên quyền"));

            RuleForEach(x => x.RoleNames).NotEmpty()
                .WithMessage(string.Format(Messages.Required, "Tên quyền"));
        }
    }
}