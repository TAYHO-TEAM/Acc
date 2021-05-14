using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomFormCommandHandler : CustomFormCommandHandler, IRequestHandler<DeleteCustomFormCommand, MethodResult<DeleteCustomFormCommandResponse>>
    {
        public DeleteCustomFormCommandHandler(IMapper mapper, ICustomFormRepository CustomFormRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomForm.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomFormCommandResponse>> Handle(DeleteCustomFormCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomFormCommandResponse>();
            var existingCustomForm = await _customFormRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomForm == null || !existingCustomForm.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingCustomForm)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _customFormRepository.UpdateRange(existingCustomForm);
            await _customFormRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomFormResponseDTOs = _mapper.Map<List<CustomFormCommandResponseDTO>>(existingCustomForm);
            methodResult.Result = new DeleteCustomFormCommandResponse(CustomFormResponseDTOs);
            return methodResult;
        }
    }
}