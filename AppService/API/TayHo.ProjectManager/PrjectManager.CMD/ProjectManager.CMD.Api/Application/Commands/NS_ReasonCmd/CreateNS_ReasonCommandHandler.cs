using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_ReasonCommandHandler : NS_ReasonCommandHandler, IRequestHandler<CreateNS_ReasonCommand, MethodResult<CreateNS_ReasonCommandResponse>>
    {
        public CreateNS_ReasonCommandHandler(IMapper mapper, INS_ReasonRepository NS_ReasonRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_ReasonRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_Reason
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_ReasonCommandResponse>> Handle(CreateNS_ReasonCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_ReasonCommandResponse>();
            var newNS_Reason = new NS_Reason(request.Ten, request.DienGiai);
            newNS_Reason.SetCreate(_user);
            newNS_Reason.Status = request.Status.HasValue ? request.Status : newNS_Reason.Status;
            newNS_Reason.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_Reason.IsActive;
            newNS_Reason.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_Reason.IsVisible;
            await _NS_ReasonRepository.AddAsync(newNS_Reason).ConfigureAwait(false);
            await _NS_ReasonRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_ReasonCommandResponse>(newNS_Reason);
            return methodResult;
        }
    }
}