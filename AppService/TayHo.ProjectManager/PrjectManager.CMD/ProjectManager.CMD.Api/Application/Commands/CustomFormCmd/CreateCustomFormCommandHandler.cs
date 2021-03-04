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
    public class CreateCustomFormCommandHandler : CustomFormCommandHandler, IRequestHandler<CreateCustomFormCommand, MethodResult<CreateCustomFormCommandResponse>>
    {
        public CreateCustomFormCommandHandler(IMapper mapper, ICustomFormRepository CustomFormRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomForm
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomFormCommandResponse>> Handle(CreateCustomFormCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomFormCommandResponse>();
            var newCustomForm = new CustomForm(request.Code,
                                                    request.Title,
                                                    request.Header,
                                                    request.Style);
            newCustomForm.SetCreate(_user);
            newCustomForm.Status = request.Status.HasValue ? request.Status : newCustomForm.Status;
            newCustomForm.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomForm.IsActive;
            newCustomForm.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newCustomForm.IsVisible;
            await _customFormRepository.AddAsync(newCustomForm).ConfigureAwait(false);
            await _customFormRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomFormCommandResponse>(newCustomForm);
            return methodResult;
        }
    }
}