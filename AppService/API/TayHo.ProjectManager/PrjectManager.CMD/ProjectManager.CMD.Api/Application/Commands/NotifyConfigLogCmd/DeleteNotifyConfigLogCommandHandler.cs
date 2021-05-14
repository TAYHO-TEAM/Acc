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
    public class DeleteNotifyConfigLogCommandHandler : NotifyConfigLogCommandHandler, IRequestHandler<DeleteNotifyConfigLogCommand, MethodResult<DeleteNotifyConfigLogCommandResponse>>
    {
        public DeleteNotifyConfigLogCommandHandler(IMapper mapper, INotifyConfigLogRepository NotifyConfigLogRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, NotifyConfigLogRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NotifyConfigLog.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNotifyConfigLogCommandResponse>> Handle(DeleteNotifyConfigLogCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNotifyConfigLogCommandResponse>();
            var existingNotifyConfigLogs = await _notifyConfigLogRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyConfigLogs == null || !existingNotifyConfigLogs.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingNotifyConfigLog in existingNotifyConfigLogs)
            {
                existingNotifyConfigLog.UpdateDate = now;
                existingNotifyConfigLog.UpdateDateUTC = utc;
                existingNotifyConfigLog.IsDelete = true;
                existingNotifyConfigLog.SetUpdate(_user, null);
            }
            _notifyConfigLogRepository.UpdateRange(existingNotifyConfigLogs);
            await _notifyConfigLogRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NotifyConfigLogResponseDTOs = _mapper.Map<List<NotifyConfigLogCommandResponseDTO>>(existingNotifyConfigLogs);
            methodResult.Result = new DeleteNotifyConfigLogCommandResponse(NotifyConfigLogResponseDTOs);
            return methodResult;
        }
    }
}
