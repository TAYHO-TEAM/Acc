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
    public class UpdateNotifyConfigCommandHandler : NotifyConfigCommandHandler, IRequestHandler<UpdateNotifyConfigCommand, MethodResult<UpdateNotifyConfigCommandResponse>>
    {
        public UpdateNotifyConfigCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyConfigRepository notifyConfigRepository) : base(mapper, httpContextAccessor, notifyConfigRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing NotifyConfig.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNotifyConfigCommandResponse>> Handle(UpdateNotifyConfigCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNotifyConfigCommandResponse>();
            var existingNotifyConfig = await _notifyConfigRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyConfig == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNotifyConfig.IsActive = request.IsActive.HasValue ? request.IsActive : existingNotifyConfig.IsActive;
            existingNotifyConfig.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNotifyConfig.IsVisible;
            existingNotifyConfig.Status = request.Status.HasValue ? request.Status : existingNotifyConfig.Status;

            existingNotifyConfig.SetType(request.Type);
            existingNotifyConfig.SetCode(request.Code);
            existingNotifyConfig.SetJobName(request.JobName);
            existingNotifyConfig.SetTableName(request.TableName);
            existingNotifyConfig.SetQuerryCMD(request.QuerryCMD);


            existingNotifyConfig.SetUpdate(_user, null);
            _notifyConfigRepository.Update(existingNotifyConfig);
            await _notifyConfigRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNotifyConfigCommandResponse>(existingNotifyConfig);
            return methodResult;
        }
    }
}
