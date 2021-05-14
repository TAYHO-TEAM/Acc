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
    public class DeleteFunctionsCommandHandler : FunctionsCommandHandler, IRequestHandler<DeleteFunctionsCommand, MethodResult<DeleteFunctionsCommandResponse>>
    {
        public DeleteFunctionsCommandHandler(IMapper mapper, IFunctionsRepository FunctionsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, FunctionsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Functions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteFunctionsCommandResponse>> Handle(DeleteFunctionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteFunctionsCommandResponse>();
            var existingFunctionss = await _FunctionsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingFunctionss == null || !existingFunctionss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingFunctions in existingFunctionss)
            {
                existingFunctions.UpdateDate = now;
                existingFunctions.UpdateDateUTC = utc;
                existingFunctions.IsDelete = true;
                existingFunctions.SetUpdate(_user, null);

            }
            _FunctionsRepository.UpdateRange(existingFunctionss);
            await _FunctionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var FunctionsResponseDTOs = _mapper.Map<List<FunctionsCommandResponseDTO>>(existingFunctionss);
            methodResult.Result = new DeleteFunctionsCommandResponse(FunctionsResponseDTOs);
            return methodResult;
        }
    }
}