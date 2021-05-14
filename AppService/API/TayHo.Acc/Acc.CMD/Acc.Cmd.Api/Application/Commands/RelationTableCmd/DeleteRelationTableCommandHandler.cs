using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteRelationTableCommandHandler : RelationTableCommandHandler, IRequestHandler<DeleteRelationTableCommand, MethodResult<DeleteRelationTableCommandResponse>>
    {
        public DeleteRelationTableCommandHandler(IMapper mapper, IRelationTableRepository RelationTableRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, RelationTableRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing RelationTable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteRelationTableCommandResponse>> Handle(DeleteRelationTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteRelationTableCommandResponse>();
            var existingRelationTables = await _RelationTableRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingRelationTables == null || !existingRelationTables.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingRelationTable in existingRelationTables)
            {
                existingRelationTable.UpdateDate = now;
                existingRelationTable.UpdateDateUTC = utc;
                existingRelationTable.IsDelete = true;
                existingRelationTable.SetUpdate(_user, null);
            }
            _RelationTableRepository.UpdateRange(existingRelationTables);
            await _RelationTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var RelationTableResponseDTOs = _mapper.Map<List<RelationTableCommandResponseDTO>>(existingRelationTables);
            methodResult.Result = new DeleteRelationTableCommandResponse(RelationTableResponseDTOs);
            return methodResult;
        }
    }
}