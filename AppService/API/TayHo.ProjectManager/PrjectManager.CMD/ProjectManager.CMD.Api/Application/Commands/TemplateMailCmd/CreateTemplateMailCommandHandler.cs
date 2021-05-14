using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateTemplateMailCommandHandler : TemplateMailCommandHandler, IRequestHandler<CreateTemplateMailCommand, MethodResult<CreateTemplateMailCommandResponse>>
    {
        public CreateTemplateMailCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,ITemplateMailRepository templateMailRepository) : base(mapper, httpContextAccessor, templateMailRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new TemplateMail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateTemplateMailCommandResponse>> Handle(CreateTemplateMailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateTemplateMailCommandResponse>();
            var newTemplateMail = new TemplateMail(request.Title,request.BodyContent,request.IsBodyHtml);
            newTemplateMail.SetCreate(_user);
            newTemplateMail.Status = request.Status.HasValue ? request.Status : newTemplateMail.Status;
            newTemplateMail.IsActive = request.IsActive.HasValue ? request.IsActive : newTemplateMail.IsActive;
            newTemplateMail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newTemplateMail.IsVisible;
            await _templateMailRepository.AddAsync(newTemplateMail).ConfigureAwait(false);
            await _templateMailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateTemplateMailCommandResponse>(newTemplateMail);
            return methodResult;
        }
    }
}
