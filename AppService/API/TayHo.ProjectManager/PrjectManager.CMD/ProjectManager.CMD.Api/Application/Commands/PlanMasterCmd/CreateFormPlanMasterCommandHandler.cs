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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateFormPlanMasterCommandHandler : PlanMasterCommandHandler, IRequestHandler<CreateFormPlanMasterCommand, MethodResult<CreateFormPlanMasterCommandResponse>>
    {
        private readonly IMediaService _mediaService;
        private readonly IFilesAttachmentRepository _filesAttachmentRepository;
        public CreateFormPlanMasterCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IPlanMasterRepository planMasterRepository, IFilesAttachmentRepository filesAttachmentRepository, IMediaService mediaService) : base(mapper, httpContextAccessor, planMasterRepository)
        {
            _filesAttachmentRepository = filesAttachmentRepository;
            _mediaService = mediaService;
        }

        /// <summary>
        /// Handle for creating a new PlanMaster by Form
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateFormPlanMasterCommandResponse>> Handle(CreateFormPlanMasterCommand request, CancellationToken cancellationToken)
        {
            string tableName = QuanLyDuAnConstants.PlanMaster_TABLENAME;
            var methodResult = new MethodResult<CreateFormPlanMasterCommandResponse>();
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


            methodResult.Result = _mapper.Map<CreateFormPlanMasterCommandResponse>(newPlanMaster);
            return methodResult;
        }
    }
}
