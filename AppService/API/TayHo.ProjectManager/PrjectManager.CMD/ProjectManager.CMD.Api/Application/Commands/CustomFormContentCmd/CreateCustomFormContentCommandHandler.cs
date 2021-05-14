using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomFormContentCommandHandler : CustomFormContentCommandHandler, IRequestHandler<CreateCustomFormContentCommand, MethodResult<CreateCustomFormContentCommandResponse>>
    {
        public CreateCustomFormContentCommandHandler(IMapper mapper, ICustomFormContentRepository CustomFormContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomFormContent
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomFormContentCommandResponse>> Handle(CreateCustomFormContentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomFormContentCommandResponse>();
            var newCustomFormContent = new CustomFormContent(request.Code,
                                                                request.CustomFormId);
            newCustomFormContent.SetCreate(_user);
            newCustomFormContent.Status = request.Status.HasValue ? request.Status : newCustomFormContent.Status;
            newCustomFormContent.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomFormContent.IsActive;
            newCustomFormContent.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newCustomFormContent.IsVisible;
            await _customFormContentRepository.AddAsync(newCustomFormContent).ConfigureAwait(false);
            await _customFormContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomFormContentCommandResponse>(newCustomFormContent);
            return methodResult;
        }
    }
}