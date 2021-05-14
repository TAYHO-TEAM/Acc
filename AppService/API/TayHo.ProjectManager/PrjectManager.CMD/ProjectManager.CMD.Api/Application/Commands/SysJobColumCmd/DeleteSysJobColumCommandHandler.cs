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
    public class DeleteSysJobColumCommandHandler : SysJobColumCommandHandler, IRequestHandler<DeleteSysJobColumCommand, MethodResult<DeleteSysJobColumCommandResponse>>
    {
        public DeleteSysJobColumCommandHandler(IMapper mapper, ISysJobColumRepository SysJobColumRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, SysJobColumRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing SysJobColum.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteSysJobColumCommandResponse>> Handle(DeleteSysJobColumCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteSysJobColumCommandResponse>();
            var existingSysJobColums = await _sysJobColumRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobColums == null || !existingSysJobColums.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingSysJobColum in existingSysJobColums)
            {
                existingSysJobColum.UpdateDate = now;
                existingSysJobColum.UpdateDateUTC = utc;
                existingSysJobColum.IsDelete = true;
                existingSysJobColum.SetUpdate(_user, null);
            }
            _sysJobColumRepository.UpdateRange(existingSysJobColums);
            await _sysJobColumRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var SysJobColumResponseDTOs = _mapper.Map<List<SysJobColumCommandResponseDTO>>(existingSysJobColums);
            methodResult.Result = new DeleteSysJobColumCommandResponse(SysJobColumResponseDTOs);
            return methodResult;
        }
    }
}
