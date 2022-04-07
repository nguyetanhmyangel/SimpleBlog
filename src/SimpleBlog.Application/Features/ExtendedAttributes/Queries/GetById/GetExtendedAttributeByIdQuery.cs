using AutoMapper;
using MediatR;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Contracts;
using SimpleBlog.Domain.Contracts.Extends;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.ExtendedAttributes.Queries.GetById
{
    public class GetExtendedAttributeByIdQuery<TId, TEntityId, TEntity, TExtendedAttribute>
        : IRequest<Result<GetExtendedAttributeByIdResponse<TId, TEntityId>>>
        where TEntity : AuditEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
        where TExtendedAttribute : AuditEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
    }

    internal class GetExtendedAttributeByIdQueryHandler<TId, TEntityId, TEntity, TExtendedAttribute>
        : IRequestHandler<GetExtendedAttributeByIdQuery<TId, TEntityId, TEntity, TExtendedAttribute>, Result<GetExtendedAttributeByIdResponse<TId, TEntityId>>>
            where TEntity : AuditEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
            where TExtendedAttribute : AuditEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
            where TId : IEquatable<TId>
    {
        private readonly IUnitOfWork<TId> _unitOfWork;
        private readonly IMapper _mapper;

        public GetExtendedAttributeByIdQueryHandler(IUnitOfWork<TId> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetExtendedAttributeByIdResponse<TId, TEntityId>>> Handle(GetExtendedAttributeByIdQuery<TId, TEntityId, TEntity, TExtendedAttribute> query, CancellationToken cancellationToken)
        {
            var extendedAttribute = await _unitOfWork.Repository<TExtendedAttribute>().GetByIdAsync(query.Id);
            var mappedExtendedAttribute = _mapper.Map<GetExtendedAttributeByIdResponse<TId, TEntityId>>(extendedAttribute);
            return await Result<GetExtendedAttributeByIdResponse<TId, TEntityId>>.SuccessAsync(mappedExtendedAttribute);
        }
    }
}