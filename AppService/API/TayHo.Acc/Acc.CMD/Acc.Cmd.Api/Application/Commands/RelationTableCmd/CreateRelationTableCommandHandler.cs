using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateRelationTableCommandHandler : RelationTableCommandHandler, IRequestHandler<CreateRelationTableCommand, MethodResult<CreateRelationTableCommandResponse>>
    {
        public CreateRelationTableCommandHandler(IMapper mapper, IRelationTableRepository RelationTableRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, RelationTableRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new RelationTable
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateRelationTableCommandResponse>> Handle(CreateRelationTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateRelationTableCommandResponse>();
            var newRelationTable = new RelationTable(request.PrimaryTable,
                                                        request.PrimaryKey,
                                                        request.ForeignTable,
                                                        request.ForeignKey);
            newRelationTable.SetCreate(_user);
            newRelationTable.Status = request.Status.HasValue ? request.Status : newRelationTable.Status;
            newRelationTable.IsActive = request.IsActive.HasValue ? request.IsActive : newRelationTable.IsActive;
            newRelationTable.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newRelationTable.IsVisible;
            await _RelationTableRepository.AddAsync(newRelationTable).ConfigureAwait(false);
            await _RelationTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateRelationTableCommandResponse>(newRelationTable);
            return methodResult;
        }
    }
}