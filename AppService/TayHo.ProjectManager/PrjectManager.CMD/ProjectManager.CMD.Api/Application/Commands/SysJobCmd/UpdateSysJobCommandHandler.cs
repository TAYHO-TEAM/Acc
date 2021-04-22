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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobCommandHandler : SysJobCommandHandler,IRequestHandler<UpdateSysJobCommand, MethodResult<UpdateSysJobCommandResponse>>
    {
        public UpdateSysJobCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, ISysJobRepository sysJobRepository) : base(mapper,httpContextAccessor,sysJobRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing SysJob.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateSysJobCommandResponse>> Handle(UpdateSysJobCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateSysJobCommandResponse>();
            var existingSysJob = await _sysJobRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJob == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingSysJob.IsActive = request.IsActive.HasValue ? request.IsActive : existingSysJob.IsActive;
            existingSysJob.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingSysJob.IsVisible;
            existingSysJob.Status = request.Status.HasValue ? request.Status : existingSysJob.Status;

            existingSysJob.SetJobName(request.JobName);
	existingSysJob.SetNameDataBase(request.NameDataBase);
			existingSysJob.SetNameStoreProce(request.NameStoreProce);
			existingSysJob.SetStartTime(request.StartTime);
			existingSysJob.SetEndTime(request.EndTime);
			existingSysJob.SetStartDate(request.StartDate);
			existingSysJob.SetEndDate(request.EndDate);
			existingSysJob.SetFirstDate(request.FirstDate);
			existingSysJob.SetLastDate(request.LastDate);
			existingSysJob.SetNextDate(request.NextDate);
			existingSysJob.SetTimes(request.Times);
			existingSysJob.SetUnit(request.Unit);
			existingSysJob.SetStepTime(request.StepTime);
			

            existingSysJob.SetUpdate(_user,null);
            _sysJobRepository.Update(existingSysJob);
            await _sysJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateSysJobCommandResponse>(existingSysJob);
            return methodResult;
        }
    }
}
