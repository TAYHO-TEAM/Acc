using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysAutoSendMailCommandHandler : SysAutoSendMailCommandHandler, IRequestHandler<CreateSysAutoSendMailCommand, MethodResult<CreateSysAutoSendMailCommandResponse>>
    {
        public CreateSysAutoSendMailCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,ISysAutoSendMailRepository sysAutoSendMailRepository) : base(mapper, httpContextAccessor, sysAutoSendMailRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new SysAutoSendMail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateSysAutoSendMailCommandResponse>> Handle(CreateSysAutoSendMailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateSysAutoSendMailCommandResponse>();
            var newSysAutoSendMail = new SysAutoSendMail(request.SysJobId,request.TemplateMailId,request.SubMail,request.TitleMail,request.BodyMail,request.StartTime,request.EndTime,request.StartDate,request.EndDate,request.FirstDate,request.LastDate,request.NextDate,request.Times,request.Unit,request.StepTime);
            newSysAutoSendMail.SetCreate(_user);
            newSysAutoSendMail.Status = request.Status.HasValue ? request.Status : newSysAutoSendMail.Status;
            newSysAutoSendMail.IsActive = request.IsActive.HasValue ? request.IsActive : newSysAutoSendMail.IsActive;
            newSysAutoSendMail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newSysAutoSendMail.IsVisible;
            await _sysAutoSendMailRepository.AddAsync(newSysAutoSendMail).ConfigureAwait(false);
            await _sysAutoSendMailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateSysAutoSendMailCommandResponse>(newSysAutoSendMail);
            return methodResult;
        }
    }
}
