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
    public class DeleteGroupActionPermistionCommandHandler : GroupActionPermistionCommandHandler, IRequestHandler<DeleteGroupActionPermistionCommand, MethodResult<DeleteGroupActionPermistionCommandResponse>>
    {
        public DeleteGroupActionPermistionCommandHandler(IMapper mapper, IGroupActionPermistionRepository GroupActionPermistionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupActionPermistionRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupActionPermistion.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupActionPermistionCommandResponse>> Handle(DeleteGroupActionPermistionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupActionPermistionCommandResponse>();
            var existingGroupActionPermistions = await _GroupActionPermistionRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupActionPermistions == null || !existingGroupActionPermistions.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupActionPermistion in existingGroupActionPermistions)
            {
                existingGroupActionPermistion.UpdateDate = now;
                existingGroupActionPermistion.UpdateDateUTC = utc;
                existingGroupActionPermistion.IsDelete = true;
                existingGroupActionPermistion.SetUpdate(_user, null);

            }
            _GroupActionPermistionRepository.UpdateRange(existingGroupActionPermistions);
            await _GroupActionPermistionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupActionPermistionResponseDTOs = _mapper.Map<List<GroupActionPermistionCommandResponseDTO>>(existingGroupActionPermistions);
            methodResult.Result = new DeleteGroupActionPermistionCommandResponse(GroupActionPermistionResponseDTOs);
            return methodResult;
        }
    }
}