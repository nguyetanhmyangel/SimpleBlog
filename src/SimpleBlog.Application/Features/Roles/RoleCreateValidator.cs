using FluentValidation;

namespace SimpleBlog.Application.Features.Roles
{
    public class RoleCreateValidator : AbstractValidator<RoleCreateRequest>
    {
        public RoleCreateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id value is required")
                .MaximumLength(50).WithMessage("Role id cannot over limit 50 characters");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Role name is required");
        }
    }
}