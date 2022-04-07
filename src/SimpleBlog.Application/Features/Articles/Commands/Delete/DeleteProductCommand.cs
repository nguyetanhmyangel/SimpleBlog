using MediatR;
using Microsoft.Extensions.Localization;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.Articles.Commands.Delete
{
    public class DeleteProductCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<int>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<DeleteProductCommandHandler> _localizer;

        public DeleteProductCommandHandler(IUnitOfWork<int> unitOfWork, IStringLocalizer<DeleteProductCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(command.Id);
            if (product != null)
            {
                await _unitOfWork.Repository<Product>().DeleteAsync(product);
                await _unitOfWork.Commit(cancellationToken);
                return await Result<int>.SuccessAsync(product.Id, _localizer["Product Deleted"]);
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["Product Not Found!"]);
            }
        }
    }
}