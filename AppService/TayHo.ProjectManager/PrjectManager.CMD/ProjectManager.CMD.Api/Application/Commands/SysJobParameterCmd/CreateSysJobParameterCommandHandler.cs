using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobParameterCommandHandler : SysJobParameterCommandHandler, IRequestHandler<CreateSysJobParameterCommand, MethodResult<CreateSysJobParameterCommandResponse>>
    {
        public CreateSysJobParameterCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobParameterRepository sysJobParameterRepository) : base(mapper, httpContextAccessor, sysJobParameterRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new SysJobParameter
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateSysJobParameterCommandResponse>> Handle(CreateSysJobParameterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateSysJobParameterCommandResponse>();
            var newSysJobParameter = new SysJobParameter(request.SysJobId, request.Name, request.DisplayName, request.DataTypeSQL, request.DataTypeC, request.DefaultValue);
            newSysJobParameter.SetCreate(_user);
            newSysJobParameter.Status = request.Status.HasValue ? request.Status : newSysJobParameter.Status;
            newSysJobParameter.IsActive = request.IsActive.HasValue ? request.IsActive : newSysJobParameter.IsActive;
            newSysJobParameter.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newSysJobParameter.IsVisible;
            await _sysJobParameterRepository.AddAsync(newSysJobParameter).ConfigureAwait(false);
            await _sysJobParameterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateSysJobParameterCommandResponse>(newSysJobParameter);
            return methodResult;
        }
    }
}
