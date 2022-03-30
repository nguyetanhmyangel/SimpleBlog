using FluentValidation;
using SimpleBlog.Application.Wrapper;

namespace SimpleBlog.Application.Features.Articles
{
    public class ArticleCreateValidator : AbstractValidator<ArticleCreateRequest>
    {
        public ArticleCreateValidator()
        {
            RuleFor(x => x.CategoryId).GreaterThan(0)
                .WithMessage(string.Format(Messages.Required, "Danh mục"));

            RuleFor(x => x.Title).NotEmpty().WithMessage(string.Format(Messages.Required, "Tiêu đề"));

            RuleFor(x => x.Problem).NotEmpty().WithMessage(string.Format(Messages.Required, "Vấn đề"));

            RuleFor(x => x.Note).NotEmpty().WithMessage(string.Format(Messages.Required, "Giải pháp"));
        }
    }
}