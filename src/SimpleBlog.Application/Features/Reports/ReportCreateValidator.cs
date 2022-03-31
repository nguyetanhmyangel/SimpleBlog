using FluentValidation;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.Reports
{
    public class ReportCreateValidator : AbstractValidator<ReportCreateRequest>
    {
        public ReportCreateValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Phải nhập nội dung");

            RuleFor(x => x.ArticleId)
                .NotNull()
                .WithMessage("Chưa có mã bài đăng")
                .GreaterThan(0).WithMessage(string.Format(Messages.Required, "Mã bài đăng"));
        }
    }
}