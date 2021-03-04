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
    public class DeleteCustomCellContentCommandHandler : CustomCellContentCommandHandler, IRequestHandler<DeleteCustomCellContentCommand, MethodResult<DeleteCustomCellContentCommandResponse>>
    {
        public DeleteCustomCellContentCommandHandler(IMapper mapper, ICustomCellContentRepository CustomCellContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomCellContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomCellContent.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomCellContentCommandResponse>> Handle(DeleteCustomCellContentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomCellContentCommandResponse>();
            var existingCustomCellContent = await _customCellContentRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomCellContent == null || !existingCustomCellContent.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingCustomCellContent)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _customCellContentRepository.UpdateRange(existingCustomCellContent);
            await _customCellContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomCellContentResponseDTOs = _mapper.Map<List<CustomCellContentCommandResponseDTO>>(existingCustomCellContent);
            methodResult.Result = new DeleteCustomCellContentCommandResponse(CustomCellContentResponseDTOs);
            return methodResult;
        }
    }
}