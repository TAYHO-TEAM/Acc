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
    public class DeleteSysJobParameterCommandHandler : SysJobParameterCommandHandler, IRequestHandler<DeleteSysJobParameterCommand, MethodResult<DeleteSysJobParameterCommandResponse>>
    {
        public DeleteSysJobParameterCommandHandler(IMapper mapper, ISysJobParameterRepository SysJobParameterRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, SysJobParameterRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing SysJobParameter.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteSysJobParameterCommandResponse>> Handle(DeleteSysJobParameterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteSysJobParameterCommandResponse>();
            var existingSysJobParameters = await _sysJobParameterRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobParameters == null || !existingSysJobParameters.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingSysJobParameter in existingSysJobParameters)
            {
                existingSysJobParameter.UpdateDate = now;
                existingSysJobParameter.UpdateDateUTC = utc;
                existingSysJobParameter.IsDelete = true;
                existingSysJobParameter.SetUpdate(_user, null);
            }
            _sysJobParameterRepository.UpdateRange(existingSysJobParameters);
            await _sysJobParameterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var SysJobParameterResponseDTOs = _mapper.Map<List<SysJobParameterCommandResponseDTO>>(existingSysJobParameters);
            methodResult.Result = new DeleteSysJobParameterCommandResponse(SysJobParameterResponseDTOs);
            return methodResult;
        }
    }
}
