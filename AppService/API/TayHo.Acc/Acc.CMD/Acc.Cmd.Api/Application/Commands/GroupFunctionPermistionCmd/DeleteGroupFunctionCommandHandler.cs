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
    public class DeleteGroupFunctionPermistionCommandHandler : GroupFunctionPermistionCommandHandler, IRequestHandler<DeleteGroupFunctionPermistionCommand, MethodResult<DeleteGroupFunctionPermistionCommandResponse>>
    {
        public DeleteGroupFunctionPermistionCommandHandler(IMapper mapper, IGroupFunctionPermistionRepository GroupFunctionPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupFunctionPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupFunctionPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupFunctionPermistionCommandResponse>> Handle(DeleteGroupFunctionPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupFunctionPermistionCommandResponse>();
            var existingGroupFunctionPermistions = await _GroupFunctionPermistionRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupFunctionPermistions == null || !existingGroupFunctionPermistions.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupFunctionPermistion in existingGroupFunctionPermistions)
            {
                existingGroupFunctionPermistion.UpdateDate = now;
                existingGroupFunctionPermistion.UpdateDateUTC = utc;
                existingGroupFunctionPermistion.IsDelete = true;
                existingGroupFunctionPermistion.SetUpdate(_user, null);
            }
            _GroupFunctionPermistionRepository.UpdateRange(existingGroupFunctionPermistions);
            await _GroupFunctionPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupFunctionPermistionResponseDTOs = _mapper.Map<List<GroupFunctionPermistionCommandResponseDTO>>(existingGroupFunctionPermistions);
            methodResult.Result = new DeleteGroupFunctionPermistionCommandResponse(GroupFunctionPermistionResponseDTOs);
            return methodResult;
        }
    }
}