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
    public class UpdateNotifyTemplateCommandHandler : NotifyTemplateCommandHandler, IRequestHandler<UpdateNotifyTemplateCommand, MethodResult<UpdateNotifyTemplateCommandResponse>>
    {
        public UpdateNotifyTemplateCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyTemplateRepository notifyTemplateRepository) : base(mapper, httpContextAccessor, notifyTemplateRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing NotifyTemplate.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNotifyTemplateCommandResponse>> Handle(UpdateNotifyTemplateCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNotifyTemplateCommandResponse>();
            var existingNotifyTemplate = await _notifyTemplateRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyTemplate == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNotifyTemplate.IsActive = request.IsActive.HasValue ? request.IsActive : existingNotifyTemplate.IsActive;
            existingNotifyTemplate.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNotifyTemplate.IsVisible;
            existingNotifyTemplate.Status = request.Status.HasValue ? request.Status : existingNotifyTemplate.Status;

            existingNotifyTemplate.SetCode(request.Code);
            existingNotifyTemplate.SetTitle(request.Title);
            existingNotifyTemplate.SetContent(request.Content);


            existingNotifyTemplate.SetUpdate(_user, null);
            _notifyTemplateRepository.Update(existingNotifyTemplate);
            await _notifyTemplateRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNotifyTemplateCommandResponse>(existingNotifyTemplate);
            return methodResult;
        }
    }
}
