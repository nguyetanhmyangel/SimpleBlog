using FluentValidation;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.Categories
{
    public class CategoryCreateValidator : AbstractValidator<CategoryCreateRequest>
    {
        public CategoryCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(string.Format(Messages.Required, "Tên"));

            RuleFor(x => x.SeoAlias).NotEmpty().WithMessage(string.Format(Messages.Required, "Seo alias"));
        }
    }
}