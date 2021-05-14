using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysJobTableCommandHandler : SysJobTableCommandHandler, IRequestHandler<DeleteSysJobTableCommand, MethodResult<DeleteSysJobTableCommandResponse>>
    {
        public DeleteSysJobTableCommandHandler(IMapper mapper, ISysJobTableRepository SysJobTableRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, SysJobTableRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing SysJobTable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteSysJobTableCommandResponse>> Handle(DeleteSysJobTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteSysJobTableCommandResponse>();
            var existingSysJobTables = await _sysJobTableRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobTables == null || !existingSysJobTables.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingSysJobTable in existingSysJobTables)
            {
                existingSysJobTable.UpdateDate = now;
                existingSysJobTable.UpdateDateUTC = utc;
                existingSysJobTable.IsDelete = true;
                existingSysJobTable.SetUpdate(_user, null);
            }
            _sysJobTableRepository.UpdateRange(existingSysJobTables);
            await _sysJobTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var SysJobTableResponseDTOs = _mapper.Map<List<SysJobTableCommandResponseDTO>>(existingSysJobTables);
            methodResult.Result = new DeleteSysJobTableCommandResponse(SysJobTableResponseDTOs);
            return methodResult;
        }
    }
}
