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
    public class CreateCustomFormBodyCommandHandler : CustomFormBodyCommandHandler, IRequestHandler<CreateCustomFormBodyCommand, MethodResult<CreateCustomFormBodyCommandResponse>>
    {
        public CreateCustomFormBodyCommandHandler(IMapper mapper, ICustomFormBodyRepository CustomFormBodyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormBodyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomFormBody
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomFormBodyCommandResponse>> Handle(CreateCustomFormBodyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomFormBodyCommandResponse>();
            var newCustomFormBody = new CustomFormBody( request.Header,
                                                        request.CustomTableId,
                                                        request.CustomFormId,
                                                        request.Priority);
            newCustomFormBody.SetCreate(_user);
            newCustomFormBody.Status = request.Status.HasValue ? request.Status : newCustomFormBody.Status;
            newCustomFormBody.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomFormBody.IsActive;
            newCustomFormBody.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newCustomFormBody.IsVisible;
            await _customFormBodyRepository.AddAsync(newCustomFormBody).ConfigureAwait(false);
            await _customFormBodyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomFormBodyCommandResponse>(newCustomFormBody);
            return methodResult;
        }
    }
}