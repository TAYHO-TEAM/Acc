using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class DeleteOperationProcessCommandHandler : OperationProcessCommandHandler, IRequestHandler<DeleteOperationProcessCommand, MethodResult<DeleteOperationProcessCommandResponse>>
    {
        public DeleteOperationProcessCommandHandler(IMapper mapper, IOperationProcessRepository OperationProcessRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, OperationProcessRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing OperationProcess.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteOperationProcessCommandResponse>> Handle(DeleteOperationProcessCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteOperationProcessCommandResponse>();
            var existingOperationProcesss = await _OperationProcessRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingOperationProcesss == null || !existingOperationProcesss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingOperationProcess in existingOperationProcesss)
            {
                existingOperationProcess.UpdateDate = now;
                existingOperationProcess.UpdateDateUTC = utc;
                existingOperationProcess.IsDelete = true;
                existingOperationProcess.SetUpdate(_user, null);
            }
            _OperationProcessRepository.UpdateRange(existingOperationProcesss);
            await _OperationProcessRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var OperationProcessResponseDTOs = _mapper.Map<List<OperationProcessCommandResponseDTO>>(existingOperationProcesss);
            methodResult.Result = new DeleteOperationProcessCommandResponse(OperationProcessResponseDTOs);
            return methodResult;
        }
    }
}