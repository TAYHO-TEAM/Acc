using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomFormBodyCommandHandler : CustomFormBodyCommandHandler,IRequestHandler<UpdateCustomFormBodyCommand, MethodResult<UpdateCustomFormBodyCommandResponse>>
    {
        public UpdateCustomFormBodyCommandHandler(IMapper mapper, ICustomFormBodyRepository CustomFormBodyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormBodyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomFormBody.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomFormBodyCommandResponse>> Handle(UpdateCustomFormBodyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomFormBodyCommandResponse>();
            var existingCustomFormBody = await _customFormBodyRepository.SingleOrDefaultAsync(x => x.Id == request.Id && (x.IsDelete == false || x.IsDelete == null)).ConfigureAwait(false);
            if (existingCustomFormBody == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomFormBody.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomFormBody.IsActive;
            existingCustomFormBody.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingCustomFormBody.IsVisible;
            existingCustomFormBody.Status = request.Status.HasValue ? request.Status : existingCustomFormBody.Status;

            existingCustomFormBody.SetPriority(request.Priority);
            existingCustomFormBody.SetHeader(request.Header);
            existingCustomFormBody.SetCustomTableId(request.CustomTableId);
            existingCustomFormBody.SetCustomFormId(request.CustomFormId);

            existingCustomFormBody.SetUpdate(_user,0);
            _customFormBodyRepository.Update(existingCustomFormBody);
            await _customFormBodyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomFormBodyCommandResponse>(existingCustomFormBody);
            return methodResult;
        }
    }
}