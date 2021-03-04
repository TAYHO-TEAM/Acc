using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanMasterCommandHandler : PlanMasterCommandHandler, IRequestHandler<CreatePlanMasterCommand, MethodResult<CreatePlanMasterCommandResponse>>
    {
        public CreatePlanMasterCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanMasterRepository planMasterRepository) : base(mapper, httpContextAccessor, planMasterRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanMaster
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanMasterCommandResponse>> Handle(CreatePlanMasterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanMasterCommandResponse>();
            var newPlanMaster = new PlanMaster(request.Code,request.ParentId,request.PlanProjectId,request.Title,request.TimeLine,request.Description,request.Note,request.StartDate,request.EndDate,request.Unit,request.Amount,request.ReportPeriodicalType,request.ReportPeriodical,request.ReportFrequency,request.Priority,request.ImportantLevel,request.NoAttachment);
            newPlanMaster.SetCreate(_user);
            newPlanMaster.Status = request.Status.HasValue ? request.Status : newPlanMaster.Status;
            newPlanMaster.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanMaster.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planMasterRepository.AddAsync(newPlanMaster).ConfigureAwait(false);
            await _planMasterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanMasterCommandResponse>(newPlanMaster);
            return methodResult;
        }
    }
}
