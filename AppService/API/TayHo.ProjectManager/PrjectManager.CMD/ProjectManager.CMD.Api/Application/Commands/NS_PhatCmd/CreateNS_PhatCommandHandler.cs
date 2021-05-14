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
    public class CreateNS_PhatCommandHandler : NS_PhatCommandHandler, IRequestHandler<CreateNS_PhatCommand, MethodResult<CreateNS_PhatCommandResponse>>
    {
        public CreateNS_PhatCommandHandler(IMapper mapper, INS_PhatRepository NS_PhatRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_PhatRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_Phat
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_PhatCommandResponse>> Handle(CreateNS_PhatCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_PhatCommandResponse>();
            var newNS_Phat = new NS_Phat(request.GoiThauId,request.ProjectId,
                request.NhomPhatId,
                request.NoiDung,
                request.DienGiai,
                request.GiaTri,
                request.GiaTriCon);
            newNS_Phat.SetCreate(_user);
            newNS_Phat.Status = request.Status.HasValue ? request.Status : newNS_Phat.Status;
            newNS_Phat.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_Phat.IsActive;
            newNS_Phat.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_Phat.IsVisible;
            await _NS_PhatRepository.AddAsync(newNS_Phat).ConfigureAwait(false);
            await _NS_PhatRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_PhatCommandResponse>(newNS_Phat);
            return methodResult;
        }
    }
}