using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain.IService;
using ProjectManager.Common;
using Services.Common.Utilities;
using ProjectManager.CMD.Domain;
using System;
using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFormProgressPlanMasterCommandHandler : PlanMasterCommandHandler, IRequestHandler<CreateFormProgressPlanMasterCommand, MethodResult<CreateFormProgressPlanMasterCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;
        private readonly IPlanJobRepository _planJobRepository;
        public CreateFormProgressPlanMasterCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanMasterRepository planMasterRepository, IFilesAttachmentRepository filesAttachmentRepository, IPlanJobRepository planJobRepository, IMediaService mediaService) : base(mapper, httpContextAccessor, planMasterRepository)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
            _planJobRepository = planJobRepository;
        }

        /// <summary>
        /// Handle for creating a new ProgressPlanMaster by Form
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateFormProgressPlanMasterCommandResponse>> Handle(CreateFormProgressPlanMasterCommand request, CancellationToken cancellationToken)
        {
            DateTime tempdate = (DateTime)request.StartDate;
            if (request.EndDate < request.StartDate)
            {
                request.StartDate = request.EndDate;
                request.EndDate = tempdate;
            }
            string tableName = QuanLyDuAnConstants.PlanMaster_TABLENAME;
            var methodResult = new MethodResult<CreateFormProgressPlanMasterCommandResponse>();
            var newPlanMaster = new PlanMaster(request.Code, request.ParentId, request.PlanProjectId, request.Title, request.TimeLine, request.Description, request.Note, request.StartDate, request.EndDate, request.Unit, request.Amount, request.ReportPeriodicalType, request.ReportPeriodical, request.ReportFrequency, request.Priority, request.ImportantLevel, request.NoAttachment);
            newPlanMaster.SetCreate(_user);
            newPlanMaster.Status = request.Status.HasValue ? request.Status : newPlanMaster.Status;
            newPlanMaster.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanMaster.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planMasterRepository.AddAsync(newPlanMaster).ConfigureAwait(false);
            await _planMasterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            string code = await _planMasterRepository.GenCodeAsync(newPlanMaster.Id, tableName);
            // ghi file vào server và lưu log file dữ liệu
            if (request.getFile() != null && request.getFile().Count > 0)
            {
                foreach (var i in request.getFile())
                {
                    var result = await _mediaService.SaveFile(i, tableName, code);
                    var newFilesAttachment = new FilesAttachment(newPlanMaster.Id,
                                                          tableName,
                                                          code,
                                                          result.Item1,
                                                          result.Item6,
                                                          result.Item5,
                                                          result.Item3,
                                                          result.Item2,
                                                          "",
                                                          result.Item4);
                    newFilesAttachment.SetCreate(_user);
                    newFilesAttachment.Status = request.Status.HasValue ? request.Status : newFilesAttachment.Status;
                    newFilesAttachment.IsActive = request.IsActive.HasValue ? request.IsActive : true;
                    newFilesAttachment.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;

                    await _filesAttachmentRepository.AddAsync(newFilesAttachment).ConfigureAwait(false);
                    await _filesAttachmentRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {

            }
            if (request.ReportFrequency.HasValue && request.ReportFrequency > 0)
            {
                List<PlanJob> newPlanJobs = new List<PlanJob>();
                int rangDate = ((request.EndDate == null ? DateTime.Now.Date : ((DateTime)request.EndDate).Date) - (request.StartDate == null ? DateTime.Now.Date : ((DateTime)request.StartDate).Date)).Days;
                int stepTime = rangDate / (int)request.ReportFrequency;
                int amout = (int)request.Amount / (int)request.ReportFrequency;
                for (int i = 1; i <= (int)request.ReportFrequency; i++)
                {
                    DateTime stepDate = (request.StartDate == null ? DateTime.Now.Date : ((DateTime)request.StartDate).Date).AddDays((int)request.ReportFrequency*i);
                    
                    if((int)request.ReportFrequency == i && ((DateTime)request.EndDate).Date  > stepDate.Date)
                    {
                        PlanJob newPlanJobEnd = new PlanJob(newPlanMaster.Id,
                                                   0,
                                                   "Báo cáo lần " + i.ToString(),
                                                   "Dự toán lần "+i+" công việc ngày:" + stepDate.Date.ToString("dd-MM-yyyy"),
                                                   newPlanMaster.Unit,
                                                   (int)request.Amount - (amout*(i-1)),
                                                   (DateTime)request.StartDate,
                                                   (DateTime)request.EndDate,
                                                   0,
                                                   i,
                                                   (byte)i,
                                                   false);
                        newPlanJobEnd.SetCreate( _user);
                        newPlanJobEnd.Status = 0;
                        newPlanJobEnd.IsActive =  true;
                        newPlanJobEnd.IsVisible =  true;
                        newPlanJobs.Add(newPlanJobEnd);
                        await _planJobRepository.AddAsync(newPlanJobEnd).ConfigureAwait(false);
                        await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    }    
                    else
                    {
                        PlanJob newPlanJob = new PlanJob(newPlanMaster.Id,
                                                    0,
                                                    "Báo cáo lần "+ i.ToString(),
                                                    "Dự toán lần " + i.ToString() + " công việc ngày:" + stepDate.Date.ToString("dd-MM-yyyy"),
                                                    newPlanMaster.Unit,
                                                    amout * i,
                                                    (DateTime)request.StartDate,
                                                    stepDate,
                                                    0,
                                                    i,
                                                    (byte)i,
                                                    false);
                        newPlanJob.SetCreate(_user);
                        newPlanJob.Status = 0;
                        newPlanJob.IsActive = true;
                        newPlanJob.IsVisible = true;
                        newPlanJobs.Add(newPlanJob);
                        await _planJobRepository.AddAsync(newPlanJob).ConfigureAwait(false);
                        await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                    }                        
                }
                //await _planJobRepository.AddRangeAsync(newPlanJobs).ConfigureAwait(false);
                //await _planJobRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            methodResult.Result = _mapper.Map<CreateFormProgressPlanMasterCommandResponse>(newPlanMaster);
            return methodResult;
        }
    }
}
