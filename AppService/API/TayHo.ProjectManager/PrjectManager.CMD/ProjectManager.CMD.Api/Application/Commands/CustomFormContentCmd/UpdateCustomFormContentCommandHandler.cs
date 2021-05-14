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
    public class UpdateCustomFormContentCommandHandler : CustomFormContentCommandHandler,IRequestHandler<UpdateCustomFormContentCommand, MethodResult<UpdateCustomFormContentCommandResponse>>
    {
        public UpdateCustomFormContentCommandHandler(IMapper mapper, ICustomFormContentRepository CustomFormContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomFormContent.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomFormContentCommandResponse>> Handle(UpdateCustomFormContentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomFormContentCommandResponse>();
            var existingCustomFormContent = await _customFormContentRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomFormContent == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomFormContent.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomFormContent.IsActive;
            existingCustomFormContent.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingCustomFormContent.IsVisible;
            existingCustomFormContent.Status = request.Status.HasValue ? request.Status : existingCustomFormContent.Status;

            existingCustomFormContent.SetCode(request.Code);
            existingCustomFormContent.SetCustomFormId(request.CustomFormId);

            existingCustomFormContent.SetUpdate(_user,0);
            _customFormContentRepository.Update(existingCustomFormContent);
            await _customFormContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomFormContentCommandResponse>(existingCustomFormContent);
            return methodResult;
        }
    }
}