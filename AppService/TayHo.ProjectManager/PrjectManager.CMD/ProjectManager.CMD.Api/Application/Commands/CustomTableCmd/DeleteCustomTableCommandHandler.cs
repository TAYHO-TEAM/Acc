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
    public class DeleteCustomTableCommandHandler : CustomTableCommandHandler, IRequestHandler<DeleteCustomTableCommand, MethodResult<DeleteCustomTableCommandResponse>>
    {
        public DeleteCustomTableCommandHandler(IMapper mapper, ICustomTableRepository CustomTableRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomTableRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing CustomTable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCustomTableCommandResponse>> Handle(DeleteCustomTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCustomTableCommandResponse>();
            var existingCustomTable = await _customTableRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomTable == null || !existingCustomTable.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingStage in existingCustomTable)
            {
                existingStage.UpdateDate = now;
                existingStage.UpdateDateUTC = utc;
                existingStage.IsDelete = true;
                existingStage.ModifyBy = 0;
                existingStage.SetUpdate(_user,0);
                
            }
            _customTableRepository.UpdateRange(existingCustomTable);
            await _customTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CustomTableResponseDTOs = _mapper.Map<List<CustomTableCommandResponseDTO>>(existingCustomTable);
            methodResult.Result = new DeleteCustomTableCommandResponse(CustomTableResponseDTOs);
            return methodResult;
        }
    }
}