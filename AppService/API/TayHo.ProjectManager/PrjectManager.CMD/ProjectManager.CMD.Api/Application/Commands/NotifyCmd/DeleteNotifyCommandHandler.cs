using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNotifyCommandHandler : NotifyCommandHandler, IRequestHandler<DeleteNotifyCommand, MethodResult<DeleteNotifyCommandResponse>>
    {
        public DeleteNotifyCommandHandler(IMapper mapper, INotifyRepository notifyRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, notifyRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Notify.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNotifyCommandResponse>> Handle(DeleteNotifyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNotifyCommandResponse>();
            var existingNotifys = await _notifyRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifys == null || !existingNotifys.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingNotify in existingNotifys)
            {
                existingNotify.UpdateDate = now;
                existingNotify.UpdateDateUTC = utc;
                existingNotify.IsDelete = true;
                existingNotify.SetUpdate(_user, null);
            }
            _notifyRepository.UpdateRange(existingNotifys);
            await _notifyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NotifyResponseDTOs = _mapper.Map<List<NotifyCommandResponseDTO>>(existingNotifys);
            methodResult.Result = new DeleteNotifyCommandResponse(NotifyResponseDTOs);
            return methodResult;
        }
    }
}
