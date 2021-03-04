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
    public class DeleteCustomFormContentCommandHandler : CustomFormContentCommandHandler, IRequestHandler<DeleteCustomFormContentCommand, MethodResult<DeleteCustomFormContentCommandResponse>>
    {
        public DeleteCustomFormContentCommandHandler(IMapper mapper, ICustomFormContentRepository CustomFormContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomFormContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomFormContent.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomFormContentCommandResponse>> Handle(DeleteCustomFormContentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomFormContentCommandResponse>();
            var existingCustomFormContent = await _customFormContentRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomFormContent == null || !existingCustomFormContent.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingCustomFormContent)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _customFormContentRepository.UpdateRange(existingCustomFormContent);
            await _customFormContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomFormContentResponseDTOs = _mapper.Map<List<CustomFormContentCommandResponseDTO>>(existingCustomFormContent);
            methodResult.Result = new DeleteCustomFormContentCommandResponse(CustomFormContentResponseDTOs);
            return methodResult;
        }
    }
}