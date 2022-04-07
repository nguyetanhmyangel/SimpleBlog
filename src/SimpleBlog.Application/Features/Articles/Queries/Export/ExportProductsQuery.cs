using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SimpleBlog.Application.Extensions;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Application.Interfaces.Services;
using SimpleBlog.Application.Specifications.Catalog;
using SimpleBlog.Domain.Entities.Catalog;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.Articles.Queries.Export
{
    public class ExportProductsQuery : IRequest<Result<string>>
    {
        public string SearchString { get; set; }

        public ExportProductsQuery(string searchString = "")
        {
            SearchString = searchString;
        }
    }

    internal class ExportProductsQueryHandler : IRequestHandler<ExportProductsQuery, Result<string>>
    {
        private readonly IExcelService _excelService;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IStringLocalizer<ExportProductsQueryHandler> _localizer;

        public ExportProductsQueryHandler(IExcelService excelService
            , IUnitOfWork<int> unitOfWork
            , IStringLocalizer<ExportProductsQueryHandler> localizer)
        {
            _excelService = excelService;
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(ExportProductsQuery request, CancellationToken cancellationToken)
        {
            var productFilterSpec = new ProductFilterSpecification(request.SearchString);
            var products = await _unitOfWork.Repository<Product>().Entities
                .Specify(productFilterSpec)
                .ToListAsync( cancellationToken);
            var data = await _excelService.ExportAsync(products, mappers: new Dictionary<string, Func<Product, object>>
            {
                { _localizer["Id"], item => item.Id },
                { _localizer["Name"], item => item.Name },
                { _localizer["Barcode"], item => item.Barcode },
                { _localizer["Description"], item => item.Description },
                { _localizer["Rate"], item => item.Rate }
            }, sheetName: _localizer["Products"]);

            return await Result<string>.SuccessAsync(data: data);
        }
    }
}