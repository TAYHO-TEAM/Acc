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
    public class DeleteNotifyConfigCommandHandler : NotifyConfigCommandHandler, IRequestHandler<DeleteNotifyConfigCommand, MethodResult<DeleteNotifyConfigCommandResponse>>
    {
        public DeleteNotifyConfigCommandHandler(IMapper mapper, INotifyConfigRepository NotifyConfigRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, NotifyConfigRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NotifyConfig.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNotifyConfigCommandResponse>> Handle(DeleteNotifyConfigCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNotifyConfigCommandResponse>();
            var existingNotifyConfigs = await _notifyConfigRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyConfigs == null || !existingNotifyConfigs.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingNotifyConfig in existingNotifyConfigs)
            {
                existingNotifyConfig.UpdateDate = now;
                existingNotifyConfig.UpdateDateUTC = utc;
                existingNotifyConfig.IsDelete = true;
                existingNotifyConfig.SetUpdate(_user, null);
            }
            _notifyConfigRepository.UpdateRange(existingNotifyConfigs);
            await _notifyConfigRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NotifyConfigResponseDTOs = _mapper.Map<List<NotifyConfigCommandResponseDTO>>(existingNotifyConfigs);
            methodResult.Result = new DeleteNotifyConfigCommandResponse(NotifyConfigResponseDTOs);
            return methodResult;
        }
    }
}
