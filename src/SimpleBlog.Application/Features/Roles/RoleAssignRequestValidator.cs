using FluentValidation;
using SimpleBlog.Application.Wrapper;

namespace Application.Features.Roles
{
    public class RoleAssignRequestValidator : AbstractValidator<RoleAssignRequest>
    {
        public RoleAssignRequestValidator()
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