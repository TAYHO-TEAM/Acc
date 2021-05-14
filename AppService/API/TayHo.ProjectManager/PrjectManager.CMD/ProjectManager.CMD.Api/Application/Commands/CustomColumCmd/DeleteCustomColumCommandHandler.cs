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
    public class DeleteCustomColumCommandHandler : CustomColumCommandHandler, IRequestHandler<DeleteCustomColumCommand, MethodResult<DeleteCustomColumCommandResponse>>
    {
        public DeleteCustomColumCommandHandler(IMapper mapper, ICustomColumRepository CustomColumRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomColumRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomColum.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomColumCommandResponse>> Handle(DeleteCustomColumCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomColumCommandResponse>();
            var existingCustomColum = await _customColumRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomColum == null || !existingCustomColum.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingCustomColum)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _customColumRepository.UpdateRange(existingCustomColum);
            await _customColumRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomColumResponseDTOs = _mapper.Map<List<CustomColumCommandResponseDTO>>(existingCustomColum);
            methodResult.Result = new DeleteCustomColumCommandResponse(CustomColumResponseDTOs);
            return methodResult;
        }
    }
}