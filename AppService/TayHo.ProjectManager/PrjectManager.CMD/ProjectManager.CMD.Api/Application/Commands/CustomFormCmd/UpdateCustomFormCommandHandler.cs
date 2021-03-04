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
    public class UpdateCustomFormCommandHandler : CustomFormCommandHandler,IRequestHandler<UpdateCustomFormCommand, MethodResult<UpdateCustomFormCommandResponse>>
    {
        public UpdateCustomFormCommandHandler(IMapper mapper, ICustomFormRepository CustomFormRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomForm.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomFormCommandResponse>> Handle(UpdateCustomFormCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomFormCommandResponse>();
            var existingCustomForm = await _customFormRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomForm == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomForm.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomForm.IsActive;
            existingCustomForm.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingCustomForm.IsVisible;
            existingCustomForm.Status = request.Status.HasValue ? request.Status : existingCustomForm.Status;


            existingCustomForm.SetCode(request.Code);
            existingCustomForm.SetTitle(request.Title);
            existingCustomForm.SetHeader(request.Header);
            existingCustomForm.SetStyle(request.Style);

            existingCustomForm.SetUpdate(_user,0);
            _customFormRepository.Update(existingCustomForm);
            await _customFormRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomFormCommandResponse>(existingCustomForm);
            return methodResult;
        }
    }
}