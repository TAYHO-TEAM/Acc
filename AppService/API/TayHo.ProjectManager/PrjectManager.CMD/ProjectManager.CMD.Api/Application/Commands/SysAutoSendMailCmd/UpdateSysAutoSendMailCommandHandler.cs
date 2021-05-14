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
    public class UpdateSysAutoSendMailCommandHandler : SysAutoSendMailCommandHandler, IRequestHandler<UpdateSysAutoSendMailCommand, MethodResult<UpdateSysAutoSendMailCommandResponse>>
    {
        public UpdateSysAutoSendMailCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysAutoSendMailRepository sysAutoSendMailRepository) : base(mapper, httpContextAccessor, sysAutoSendMailRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing SysAutoSendMail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateSysAutoSendMailCommandResponse>> Handle(UpdateSysAutoSendMailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateSysAutoSendMailCommandResponse>();
            var existingSysAutoSendMail = await _sysAutoSendMailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysAutoSendMail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingSysAutoSendMail.IsActive = request.IsActive.HasValue ? request.IsActive : existingSysAutoSendMail.IsActive;
            existingSysAutoSendMail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingSysAutoSendMail.IsVisible;
            existingSysAutoSendMail.Status = request.Status.HasValue ? request.Status : existingSysAutoSendMail.Status;

            existingSysAutoSendMail.SetSysJobId(request.SysJobId);
            existingSysAutoSendMail.SetTemplateMailId(request.TemplateMailId);
            existingSysAutoSendMail.SetSubMail(request.SubMail);
            existingSysAutoSendMail.SetTitleMail(request.TitleMail);
            existingSysAutoSendMail.SetBodyMail(request.BodyMail);
            existingSysAutoSendMail.SetStartTime(request.StartTime);
            existingSysAutoSendMail.SetEndTime(request.EndTime);
            existingSysAutoSendMail.SetStartDate(request.StartDate);
            existingSysAutoSendMail.SetEndDate(request.EndDate);
            existingSysAutoSendMail.SetFirstDate(request.FirstDate);
            existingSysAutoSendMail.SetLastDate(request.LastDate);
            existingSysAutoSendMail.SetNextDate(request.NextDate);
            existingSysAutoSendMail.SetTimes(request.Times);
            existingSysAutoSendMail.SetUnit(request.Unit);
            existingSysAutoSendMail.SetStepTime(request.StepTime);


            existingSysAutoSendMail.SetUpdate(_user, null);
            _sysAutoSendMailRepository.Update(existingSysAutoSendMail);
            await _sysAutoSendMailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateSysAutoSendMailCommandResponse>(existingSysAutoSendMail);
            return methodResult;
        }
    }
}
