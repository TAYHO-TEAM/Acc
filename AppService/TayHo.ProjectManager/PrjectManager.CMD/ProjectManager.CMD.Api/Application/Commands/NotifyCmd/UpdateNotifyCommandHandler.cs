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
    public class UpdateNotifyCommandHandler : NotifyCommandHandler, IRequestHandler<UpdateNotifyCommand, MethodResult<UpdateNotifyCommandResponse>>
    {
        public UpdateNotifyCommandHandler(IMapper mapper, INotifyRepository notifyRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, notifyRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing Notify.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNotifyCommandResponse>> Handle(UpdateNotifyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNotifyCommandResponse>();
            var existingNotify = await _notifyRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotify == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNotify.IsActive = request.IsActive.HasValue ? request.IsActive : existingNotify.IsActive;
            existingNotify.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNotify.IsVisible;
            existingNotify.Status = request.Status.HasValue ? request.Status : existingNotify.Status;


            existingNotify.SetType(request.Type);
            existingNotify.SetCategory(request.Category);
            existingNotify.SetMessage(request.Message);
            existingNotify.SetLink(request.Link);
            existingNotify.SetTemplateId(request.TemplateId);
            existingNotify.SetTitle(request.Title);
            existingNotify.SetSub(request.Sub);
            existingNotify.SetBodyContent(request.BodyContent);


            existingNotify.SetUpdate(_user, null);
            _notifyRepository.Update(existingNotify);
            await _notifyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNotifyCommandResponse>(existingNotify);
            return methodResult;
        }
    }
}
