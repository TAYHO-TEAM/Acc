using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateRelationTableCommandHandler : RelationTableCommandHandler,IRequestHandler<UpdateRelationTableCommand, MethodResult<UpdateRelationTableCommandResponse>>
    {
        public UpdateRelationTableCommandHandler(IMapper mapper, IRelationTableRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing RelationTable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateRelationTableCommandResponse>> Handle(UpdateRelationTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateRelationTableCommandResponse>();
            var existingRelationTable = await _RelationTableRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingRelationTable == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingRelationTable.IsActive = request.IsActive.HasValue ? request.IsActive : existingRelationTable.IsActive;
            existingRelationTable.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingRelationTable.IsVisible;
            existingRelationTable.Status = request.Status.HasValue ? request.Status : existingRelationTable.Status;
            existingRelationTable.SetPrimaryTable(request.PrimaryTable);
            existingRelationTable.SetPrimaryKey(request.PrimaryKey);
            existingRelationTable.SetForeignTable(request.ForeignTable);
            existingRelationTable.SetForeignKey(request.ForeignKey);

            existingRelationTable.SetUpdate(_user,null);
            _RelationTableRepository.Update(existingRelationTable);
            await _RelationTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateRelationTableCommandResponse>(existingRelationTable);
            return methodResult;
        }
    }
}