using AutoMapper;
using LazyCache;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Application.Interfaces.Repositories;
using SimpleBlog.Domain.Contracts;
using SimpleBlog.Domain.Contracts.Extends;
using SimpleBlog.Share.Constants.Application;
using SimpleBlog.Share.Wrapper;

namespace SimpleBlog.Application.Features.ExtendedAttributes.Queries.GetAllByEntityId
{
    public class GetAllExtendedAttributesByEntityIdQuery<TId, TEntityId, TEntity, TExtendedAttribute>
        : IRequest<Result<List<GetAllExtendedAttributesByEntityIdResponse<TId, TEntityId>>>>
            where TEntity : AuditEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
            where TExtendedAttribute : AuditEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
            where TId : IEquatable<TId>
    {
        public TEntityId EntityId { get; set; }

        public GetAllExtendedAttributesByEntityIdQuery(TEntityId entityId)
        {
            EntityId = entityId;
        }
    }

    internal class GetAllExtendedAttributesByEntityIdQueryHandler<TId, TEntityId, TEntity, TExtendedAttribute>
        : IRequestHandler<GetAllExtendedAttributesByEntityIdQuery<TId, TEntityId, TEntity, TExtendedAttribute>, Result<List<GetAllExtendedAttributesByEntityIdResponse<TId, TEntityId>>>>
            where TEntity : AuditEntity<TEntityId>, IEntityWithExtendedAttributes<TExtendedAttribute>, IEntity<TEntityId>
            where TExtendedAttribute : AuditEntityExtendedAttribute<TId, TEntityId, TEntity>, IEntity<TId>
            where TId : IEquatable<TId>
    {
        private readonly IUnitOfWork<TId> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllExtendedAttributesByEntityIdQueryHandler(IUnitOfWork<TId> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllExtendedAttributesByEntityIdResponse<TId, TEntityId>>>> Handle(GetAllExtendedAttributesByEntityIdQuery<TId, TEntityId, TEntity, TExtendedAttribute> request, CancellationToken cancellationToken)
        {
            var getAllExtendedAttributesByEntityId = () => _unitOfWork.Repository<TExtendedAttribute>().Entities.Where(x => x.EntityId.Equals(request.EntityId)).ToListAsync(cancellationToken);
            var extendedAttributeList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllEntityExtendedAttributesByEntityIdCacheKey(typeof(TEntity).Name, request.EntityId), getAllExtendedAttributesByEntityId);
            var mappedExtendedAttributes = _mapper.Map<List<GetAllExtendedAttributesByEntityIdResponse<TId, TEntityId>>>(extendedAttributeList);
            return await Result<List<GetAllExtendedAttributesByEntityIdResponse<TId, TEntityId>>>.SuccessAsync(mappedExtendedAttributes);
        }
    }
}