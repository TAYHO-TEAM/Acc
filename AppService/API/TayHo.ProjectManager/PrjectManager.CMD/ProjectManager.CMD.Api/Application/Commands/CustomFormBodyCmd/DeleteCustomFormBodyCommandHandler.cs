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
    public class DeleteCustomFormBodyCommandHandler : CustomFormBodyCommandHandler, IRequestHandler<DeleteCustomFormBodyCommand, MethodResult<DeleteCustomFormBodyCommandResponse>>
    {
        public DeleteCustomFormBodyCommandHandler(IMapper mapper, ICustomFormBodyRepository CustomFormBodyRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormBodyRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomFormBody.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomFormBodyCommandResponse>> Handle(DeleteCustomFormBodyCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomFormBodyCommandResponse>();
            var existingCustomFormBody = await _customFormBodyRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomFormBody == null || !existingCustomFormBody.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingCustomFormBody)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _customFormBodyRepository.UpdateRange(existingCustomFormBody);
            await _customFormBodyRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomFormBodyResponseDTOs = _mapper.Map<List<CustomFormBodyCommandResponseDTO>>(existingCustomFormBody);
            methodResult.Result = new DeleteCustomFormBodyCommandResponse(CustomFormBodyResponseDTOs);
            return methodResult;
        }
    }
}