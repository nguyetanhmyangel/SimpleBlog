using FluentValidation;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.AppPermissions
{
    public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionRequest>
    {
        public UpdatePermissionValidator()
        {
            RuleFor(x => x.Permissions).NotNull()
                .WithMessage(string.Format(Messages.Required, nameof(UpdatePermissionRequest.Permissions)));

            RuleFor(x => x.Permissions).Must(x => x.Count > 0)
                .When(x => true)
                .WithMessage(string.Format(Messages.Required, nameof(UpdatePermissionRequest.Permissions)));

            RuleForEach(x => x.Permissions).ChildRules(permission =>
            {
                permission.RuleFor(x => x.CommandId).NotEmpty()
                .WithMessage(string.Format(Messages.Required, nameof(PermissionResponse.CommandId)));

                permission.RuleFor(x => x.FunctionId).NotEmpty()
               .WithMessage(string.Format(Messages.Required, nameof(PermissionResponse.FunctionId)));

                permission.RuleFor(x => x.RoleId).NotEmpty()
               .WithMessage(string.Format(Messages.Required, nameof(PermissionResponse.RoleId)));
            });
        }
    }
}