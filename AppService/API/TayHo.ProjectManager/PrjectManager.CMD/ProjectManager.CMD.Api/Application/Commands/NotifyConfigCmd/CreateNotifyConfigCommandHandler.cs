using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyConfigCommandHandler : NotifyConfigCommandHandler, IRequestHandler<CreateNotifyConfigCommand, MethodResult<CreateNotifyConfigCommandResponse>>
    {
        public CreateNotifyConfigCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,INotifyConfigRepository notifyConfigRepository) : base(mapper, httpContextAccessor, notifyConfigRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new NotifyConfig
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyConfigCommandResponse>> Handle(CreateNotifyConfigCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyConfigCommandResponse>();
            var newNotifyConfig = new NotifyConfig(request.Type,request.Code,request.JobName,request.TableName,request.QuerryCMD);
            newNotifyConfig.SetCreate(_user);
            newNotifyConfig.Status = request.Status.HasValue ? request.Status : newNotifyConfig.Status;
            newNotifyConfig.IsActive = request.IsActive.HasValue ? request.IsActive : newNotifyConfig.IsActive;
            newNotifyConfig.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNotifyConfig.IsVisible;
            await _notifyConfigRepository.AddAsync(newNotifyConfig).ConfigureAwait(false);
            await _notifyConfigRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNotifyConfigCommandResponse>(newNotifyConfig);
            return methodResult;
        }
    }
}
