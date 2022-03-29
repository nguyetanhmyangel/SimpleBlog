using FluentValidation;
using KnowledgeSpace.ViewModels.Contents;
using SimpleBlog.Application.Wrapper;

namespace Application.Features.Votes
{
    public class VoteCreateRequestValidator : AbstractValidator<VoteCreateRequest>
    {
        public VoteCreateRequestValidator()
        {
            RuleFor(x => x.KnowledgeBaseId)
                .GreaterThan(0)
                .WithMessage(string.Format(Messages.Required, "Mã bài đăng"));
        }
    }
}