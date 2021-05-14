using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyCommandHandler : NotifyCommandHandler, IRequestHandler<CreateNotifyCommand, MethodResult<CreateNotifyCommandResponse>>
    {
        public CreateNotifyCommandHandler(IMapper mapper, INotifyRepository notifyRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, notifyRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new Notify
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyCommandResponse>> Handle(CreateNotifyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyCommandResponse>();
            var newNotify = new Notify(request.Type,
                                        request.Category,
                                        request.Message,
                                        request.Link,
                                        request.TemplateId,
                                        request.Title,
                                        request.Sub,
                                        request.BodyContent);
            newNotify.SetCreate(_user);
            newNotify.Status = request.Status.HasValue ? request.Status : newNotify.Status;
            newNotify.IsActive = request.IsActive.HasValue ? request.IsActive : newNotify.IsActive;
            newNotify.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNotify.IsVisible;
            await _notifyRepository.AddAsync(newNotify).ConfigureAwait(false);
            await _notifyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNotifyCommandResponse>(newNotify);
            return methodResult;
        }
    }
}
