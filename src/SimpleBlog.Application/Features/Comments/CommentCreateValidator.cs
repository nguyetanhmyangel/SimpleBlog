using FluentValidation;

namespace SimpleBlog.Application.Features.Comments
{
    public class CommentCreateValidator : AbstractValidator<CommentCreateRequest>
    {
        public CommentCreateValidator()
        {
            RuleFor(x => x.ArticleId).GreaterThan(0)
                 .WithMessage("Mã bài đăng không đúng");

            RuleFor(x => x.Content).NotEmpty().WithMessage("Chưa nhập nội dung");

            RuleFor(x => x.CaptchaCode).NotEmpty()
              .WithMessage("Nhập mã xác nhận");
        }
    }
}