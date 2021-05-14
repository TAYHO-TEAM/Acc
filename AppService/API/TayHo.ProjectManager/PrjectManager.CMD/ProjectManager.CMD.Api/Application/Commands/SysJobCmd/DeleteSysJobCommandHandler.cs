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
    public class DeleteSysJobCommandHandler : SysJobCommandHandler, IRequestHandler<DeleteSysJobCommand, MethodResult<DeleteSysJobCommandResponse>>
    {
        public DeleteSysJobCommandHandler(IMapper mapper, ISysJobRepository SysJobRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, SysJobRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing SysJob.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteSysJobCommandResponse>> Handle(DeleteSysJobCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteSysJobCommandResponse>();
            var existingSysJobs = await _sysJobRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobs == null || !existingSysJobs.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingSysJob in existingSysJobs)
            {
                existingSysJob.UpdateDate = now;
                existingSysJob.UpdateDateUTC = utc;
                existingSysJob.IsDelete = true;
                existingSysJob.SetUpdate(_user, null);
            }
            _sysJobRepository.UpdateRange(existingSysJobs);
            await _sysJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var SysJobResponseDTOs = _mapper.Map<List<SysJobCommandResponseDTO>>(existingSysJobs);
            methodResult.Result = new DeleteSysJobCommandResponse(SysJobResponseDTOs);
            return methodResult;
        }
    }
}
