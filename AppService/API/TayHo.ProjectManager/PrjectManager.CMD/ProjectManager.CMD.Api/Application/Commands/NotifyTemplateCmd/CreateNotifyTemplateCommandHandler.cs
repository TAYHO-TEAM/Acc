using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyTemplateCommandHandler : NotifyTemplateCommandHandler, IRequestHandler<CreateNotifyTemplateCommand, MethodResult<CreateNotifyTemplateCommandResponse>>
    {
        public CreateNotifyTemplateCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, INotifyTemplateRepository notifyTemplateRepository) : base(mapper, httpContextAccessor, notifyTemplateRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new NotifyTemplate
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyTemplateCommandResponse>> Handle(CreateNotifyTemplateCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyTemplateCommandResponse>();
            var newNotifyTemplate = new NotifyTemplate(request.Code,request.Title,request.Content);
            newNotifyTemplate.SetCreate(_user);
            newNotifyTemplate.Status = request.Status.HasValue ? request.Status : newNotifyTemplate.Status;
            newNotifyTemplate.IsActive = request.IsActive.HasValue ? request.IsActive : newNotifyTemplate.IsActive;
            newNotifyTemplate.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNotifyTemplate.IsVisible;
            await _notifyTemplateRepository.AddAsync(newNotifyTemplate).ConfigureAwait(false);
            await _notifyTemplateRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNotifyTemplateCommandResponse>(newNotifyTemplate);
            return methodResult;
        }
    }
}
