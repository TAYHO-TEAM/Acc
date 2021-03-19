using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;
using ProjectManager.CMD.Domain.IService;
using System;
using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanScheduleCommandHandler : PlanScheduleCommandHandler, IRequestHandler<CreatePlanScheduleCommand, MethodResult<CreatePlanScheduleCommandResponse>>
    {
        private readonly ISendMailService _sendMailService;
        private readonly IAccountInfoRepository _accountInfoRepository;
        private readonly IPlanMasterRepository _planMasterRepository;
        public CreatePlanScheduleCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanScheduleRepository planScheduleRepository, ISendMailService SendMailService, IAccountInfoRepository AccountInfoRepository, IPlanMasterRepository PlanMasterRepository) : base(mapper, httpContextAccessor, planScheduleRepository)
        {
            _sendMailService = SendMailService;
            _accountInfoRepository = AccountInfoRepository;
            _planMasterRepository = PlanMasterRepository;
        }

        /// <summary>
        /// Handle for creating a new PlanSchedule
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanScheduleCommandResponse>> Handle(CreatePlanScheduleCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanScheduleCommandResponse>();
            var newPlanScheduleExists = await _planScheduleRepository.AnyAsync(x => x.CreateBy == _user && x.PlanMasterId == request.PlanMasterId);
            if (!newPlanScheduleExists)
            {
                var newPlanSchedule = new PlanSchedule(request.PlanMasterId, request.PlanJobId, request.Title, request.Note, request.Remind, request.Repead, request.RepeadType, request.StartDate, request.EndDate, request.ModifyTimes);
                newPlanSchedule.SetCreate(_user);
                newPlanSchedule.Status = request.Status.HasValue ? request.Status : newPlanSchedule.Status;
                newPlanSchedule.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                newPlanSchedule.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
                await _planScheduleRepository.AddAsync(newPlanSchedule).ConfigureAwait(false);
                await _planScheduleRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                var getAccountInfo = _accountInfoRepository.GetSingle(x=> x.AccountId == _user);
                var getPlanMaster = _planMasterRepository.GetSingle(x=>x.Id == newPlanSchedule.PlanMasterId);
                if (newPlanSchedule.Remind.HasValue && getAccountInfo != null && getAccountInfo.Email != null && getPlanMaster != null)
                {
                    _sendMailService.SendMailAppoinment((DateTime)newPlanSchedule.Remind, (DateTime)newPlanSchedule.Remind, "", getPlanMaster.Title, getPlanMaster.Description, "Cảnh báo từ hệ thống","",new List<string> { getAccountInfo.Email }, new List<string>(), new List<string>(), false);
                }
                //_sendMailService.SendMailAppoinment((newPlanSchedule.Calendar.HasValue ? (DateTime)documentRealesed.Calendar : DateTime.Now), (documentRealesed.Calendar.HasValue ? (DateTime)documentRealesed.Calendar : DateTime.Now), documentRealesed.Location, documentRealesed.Title, documentRealesed.Description, documentRealesed.Title, "", toMails, null, null, false);
                if (newPlanSchedule.Remind.HasValue && newPlanSchedule.Repead.HasValue && newPlanSchedule.EndDate.HasValue)
                {
                    if ((int)newPlanSchedule.Repead > 0)
                    {
                        for(int i =1; i<((DateTime)newPlanSchedule.EndDate - (DateTime)newPlanSchedule.Remind).TotalDays; i=+(int)newPlanSchedule.Repead)
                        {
                            _sendMailService.SendMailAppoinment(((DateTime)newPlanSchedule.Remind).AddDays((int)newPlanSchedule.Repead), ((DateTime)newPlanSchedule.Remind).AddDays((int)newPlanSchedule.Repead), "", getPlanMaster.Title, getPlanMaster.Description, "Cảnh báo từ hệ thống", "", new List<string> { getAccountInfo.Email }, new List<string>(), new List<string>(), false);
                        }    
                    }
                }
                methodResult.Result = _mapper.Map<CreatePlanScheduleCommandResponse>(newPlanSchedule);
                return methodResult;
            }
            else
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErr000), new[]{
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
                return methodResult;
            }
        }
    }
}
