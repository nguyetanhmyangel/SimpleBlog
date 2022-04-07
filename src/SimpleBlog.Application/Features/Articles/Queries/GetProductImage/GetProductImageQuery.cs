using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Entities.Catalog;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.Articles.Queries.GetProductImage
{
    public class GetProductImageQuery : IRequest<Result<string>>
    {
        public int Id { get; set; }

        public GetProductImageQuery(int productId)
        {
            Id = productId;
        }
    }

    internal class GetProductImageQueryHandler : IRequestHandler<GetProductImageQuery, Result<string>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        public GetProductImageQueryHandler(IUnitOfWork<int> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<string>> Handle(GetProductImageQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.Repository<Product>().Entities.Where(p => p.Id == request.Id).Select(a => a.ImageDataUrl).FirstOrDefaultAsync(cancellationToken);
            return await Result<string>.SuccessAsync(data: data);
        }
    }
}