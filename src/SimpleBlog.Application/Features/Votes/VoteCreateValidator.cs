using FluentValidation;
using SimpleBlog.Application.Wrapper;

namespace SimpleBlog.Application.Features.Votes
{
    public class VoteCreateValidator : AbstractValidator<VoteCreateRequest>
    {
        public VoteCreateValidator()
        {
            RuleFor(x => x.ArticleId)
                .GreaterThan(0)
                .WithMessage(string.Format(Messages.Required, "Mã bài đăng"));
        }
    }
}