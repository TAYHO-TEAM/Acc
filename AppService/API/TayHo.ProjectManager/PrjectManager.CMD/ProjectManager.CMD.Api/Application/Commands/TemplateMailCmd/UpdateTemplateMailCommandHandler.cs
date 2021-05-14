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
    public class UpdateTemplateMailCommandHandler : TemplateMailCommandHandler, IRequestHandler<UpdateTemplateMailCommand, MethodResult<UpdateTemplateMailCommandResponse>>
    {
        public UpdateTemplateMailCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ITemplateMailRepository templateMailRepository) : base(mapper, httpContextAccessor, templateMailRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing TemplateMail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateTemplateMailCommandResponse>> Handle(UpdateTemplateMailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateTemplateMailCommandResponse>();
            var existingTemplateMail = await _templateMailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingTemplateMail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingTemplateMail.IsActive = request.IsActive.HasValue ? request.IsActive : existingTemplateMail.IsActive;
            existingTemplateMail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingTemplateMail.IsVisible;
            existingTemplateMail.Status = request.Status.HasValue ? request.Status : existingTemplateMail.Status;

            existingTemplateMail.SetTitle(request.Title);
            existingTemplateMail.SetBodyContent(request.BodyContent);
            existingTemplateMail.SetIsBodyHtml(request.IsBodyHtml);


            existingTemplateMail.SetUpdate(_user, null);
            _templateMailRepository.Update(existingTemplateMail);
            await _templateMailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateTemplateMailCommandResponse>(existingTemplateMail);
            return methodResult;
        }
    }
}
