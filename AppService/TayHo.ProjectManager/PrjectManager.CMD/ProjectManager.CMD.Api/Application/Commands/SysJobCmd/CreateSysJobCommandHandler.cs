using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobCommandHandler : SysJobCommandHandler, IRequestHandler<CreateSysJobCommand, MethodResult<CreateSysJobCommandResponse>>
    {
        public CreateSysJobCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,ISysJobRepository sysJobRepository) : base(mapper, httpContextAccessor, sysJobRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new SysJob
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateSysJobCommandResponse>> Handle(CreateSysJobCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateSysJobCommandResponse>();
            var newSysJob = new SysJob(request.JobName,request.NameDataBase,request.NameStoreProce, request.ConnStringHash, request.StartTime,request.EndTime,request.StartDate,request.EndDate,request.FirstDate,request.LastDate,request.NextDate,request.Times,request.Unit,request.StepTime);
            newSysJob.SetCreate(_user);
            newSysJob.Status = request.Status.HasValue ? request.Status : newSysJob.Status;
            newSysJob.IsActive = request.IsActive.HasValue ? request.IsActive : newSysJob.IsActive;
            newSysJob.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newSysJob.IsVisible;
            await _sysJobRepository.AddAsync(newSysJob).ConfigureAwait(false);
            await _sysJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateSysJobCommandResponse>(newSysJob);
            return methodResult;
        }
    }
}
