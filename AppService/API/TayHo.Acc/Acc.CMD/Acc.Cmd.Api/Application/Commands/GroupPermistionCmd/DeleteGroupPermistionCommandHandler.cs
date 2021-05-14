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
    public class DeleteGroupPermistionCommandHandler : GroupPermistionCommandHandler, IRequestHandler<DeleteGroupPermistionCommand, MethodResult<DeleteGroupPermistionCommandResponse>>
    {
        public DeleteGroupPermistionCommandHandler(IMapper mapper, IGroupPermistionRepository GroupPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupPermistionCommandResponse>> Handle(DeleteGroupPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupPermistionCommandResponse>();
            var existingGroupPermistions = await _GroupPermistionRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupPermistions == null || !existingGroupPermistions.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupPermistion in existingGroupPermistions)
            {
                existingGroupPermistion.UpdateDate = now;
                existingGroupPermistion.UpdateDateUTC = utc;
                existingGroupPermistion.IsDelete = true;
                existingGroupPermistion.SetUpdate(_user, null);

            }
            _GroupPermistionRepository.UpdateRange(existingGroupPermistions);
            await _GroupPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupPermistionResponseDTOs = _mapper.Map<List<GroupPermistionCommandResponseDTO>>(existingGroupPermistions);
            methodResult.Result = new DeleteGroupPermistionCommandResponse(GroupPermistionResponseDTOs);
            return methodResult;
        }
    }
}