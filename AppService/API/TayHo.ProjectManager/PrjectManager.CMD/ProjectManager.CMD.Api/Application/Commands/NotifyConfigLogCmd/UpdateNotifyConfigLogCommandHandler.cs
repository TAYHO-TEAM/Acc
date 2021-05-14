using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNotifyConfigLogCommandHandler : NotifyConfigLogCommandHandler, IRequestHandler<UpdateNotifyConfigLogCommand, MethodResult<UpdateNotifyConfigLogCommandResponse>>
    {
        public UpdateNotifyConfigLogCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyConfigLogRepository notifyConfigLogRepository) : base(mapper, httpContextAccessor, notifyConfigLogRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing NotifyConfigLog.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNotifyConfigLogCommandResponse>> Handle(UpdateNotifyConfigLogCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNotifyConfigLogCommandResponse>();
            var existingNotifyConfigLog = await _notifyConfigLogRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyConfigLog == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNotifyConfigLog.IsActive = request.IsActive.HasValue ? request.IsActive : existingNotifyConfigLog.IsActive;
            existingNotifyConfigLog.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNotifyConfigLog.IsVisible;
            existingNotifyConfigLog.Status = request.Status.HasValue ? request.Status : existingNotifyConfigLog.Status;

            existingNotifyConfigLog.SetNotifyConfigId(request.NotifyConfigId);
            existingNotifyConfigLog.SetOwnerById(request.OwnerById);


            existingNotifyConfigLog.SetUpdate(_user, null);
            _notifyConfigLogRepository.Update(existingNotifyConfigLog);
            await _notifyConfigLogRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNotifyConfigLogCommandResponse>(existingNotifyConfigLog);
            return methodResult;
        }
    }
}
