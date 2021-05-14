using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobParameterCommandHandler : SysJobParameterCommandHandler, IRequestHandler<UpdateSysJobParameterCommand, MethodResult<UpdateSysJobParameterCommandResponse>>
    {
        public UpdateSysJobParameterCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobParameterRepository sysJobParameterRepository) : base(mapper, httpContextAccessor, sysJobParameterRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing SysJobParameter.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateSysJobParameterCommandResponse>> Handle(UpdateSysJobParameterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateSysJobParameterCommandResponse>();
            var existingSysJobParameter = await _sysJobParameterRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobParameter == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingSysJobParameter.IsActive = request.IsActive.HasValue ? request.IsActive : existingSysJobParameter.IsActive;
            existingSysJobParameter.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingSysJobParameter.IsVisible;
            existingSysJobParameter.Status = request.Status.HasValue ? request.Status : existingSysJobParameter.Status;

            existingSysJobParameter.SetSysJobId(request.SysJobId);
            existingSysJobParameter.SetName(request.Name);
            existingSysJobParameter.SetDisplayName(request.DisplayName);
            existingSysJobParameter.SetDataTypeSQL(request.DataTypeSQL);
            existingSysJobParameter.SetDataTypeC(request.DataTypeC);
            existingSysJobParameter.SetDefaultValue(request.DefaultValue);


            existingSysJobParameter.SetUpdate(_user, null);
            _sysJobParameterRepository.Update(existingSysJobParameter);
            await _sysJobParameterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateSysJobParameterCommandResponse>(existingSysJobParameter);
            return methodResult;
        }
    }
}
