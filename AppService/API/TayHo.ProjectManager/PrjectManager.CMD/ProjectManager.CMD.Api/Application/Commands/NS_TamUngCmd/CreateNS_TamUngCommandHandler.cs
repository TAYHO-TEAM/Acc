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
    public class CreateNS_TamUngCommandHandler : NS_TamUngCommandHandler, IRequestHandler<CreateNS_TamUngCommand, MethodResult<CreateNS_TamUngCommandResponse>>
    {
        public CreateNS_TamUngCommandHandler(IMapper mapper, INS_TamUngRepository NS_TamUngRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_TamUngRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_TamUng
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_TamUngCommandResponse>> Handle(CreateNS_TamUngCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_TamUngCommandResponse>();
            var newNS_TamUng = new NS_TamUng(request.GoiThauId,request.ProjectId,
request.NoiDung,
request.DienGiai,
request.GiaTri,
request.GiaTriCon);
            newNS_TamUng.SetCreate(_user);
            newNS_TamUng.Status = request.Status.HasValue ? request.Status : newNS_TamUng.Status;
            newNS_TamUng.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_TamUng.IsActive;
            newNS_TamUng.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_TamUng.IsVisible;
            await _NS_TamUngRepository.AddAsync(newNS_TamUng).ConfigureAwait(false);
            await _NS_TamUngRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_TamUngCommandResponse>(newNS_TamUng);
            return methodResult;
        }
    }
}