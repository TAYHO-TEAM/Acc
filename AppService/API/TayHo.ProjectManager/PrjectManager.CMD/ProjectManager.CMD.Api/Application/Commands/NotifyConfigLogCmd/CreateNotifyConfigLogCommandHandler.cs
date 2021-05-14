using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyConfigLogCommandHandler : NotifyConfigLogCommandHandler, IRequestHandler<CreateNotifyConfigLogCommand, MethodResult<CreateNotifyConfigLogCommandResponse>>
    {
        public CreateNotifyConfigLogCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyConfigLogRepository notifyConfigLogRepository) : base(mapper, httpContextAccessor, notifyConfigLogRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new NotifyConfigLog
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyConfigLogCommandResponse>> Handle(CreateNotifyConfigLogCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyConfigLogCommandResponse>();
            var newNotifyConfigLog = new NotifyConfigLog(request.NotifyConfigId, request.OwnerById);
            newNotifyConfigLog.SetCreate(_user);
            newNotifyConfigLog.Status = request.Status.HasValue ? request.Status : newNotifyConfigLog.Status;
            newNotifyConfigLog.IsActive = request.IsActive.HasValue ? request.IsActive : newNotifyConfigLog.IsActive;
            newNotifyConfigLog.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNotifyConfigLog.IsVisible;
            await _notifyConfigLogRepository.AddAsync(newNotifyConfigLog).ConfigureAwait(false);
            await _notifyConfigLogRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNotifyConfigLogCommandResponse>(newNotifyConfigLog);
            return methodResult;
        }
    }
}
