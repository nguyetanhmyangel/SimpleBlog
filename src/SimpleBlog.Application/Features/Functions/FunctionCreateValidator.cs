using FluentValidation;

namespace SimpleBlog.Application.Features.Functions
{
    public class FunctionCreateValidator : AbstractValidator<FunctionCreateRequest>
    {
        public FunctionCreateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id value is required")
               .WithMessage("Function Id cannot over limit 50 characters");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name value is required")
              .MaximumLength(200).WithMessage("Name cannot over limit 200 characters");

            RuleFor(x => x.Url).NotEmpty().WithMessage("URL value is required")
             .MaximumLength(200).WithMessage("URL cannot over limit 200 characters");
        }
    }
}