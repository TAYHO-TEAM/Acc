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
    public class CreateNS_NhomChiPhiCommandHandler : NS_NhomChiPhiCommandHandler, IRequestHandler<CreateNS_NhomChiPhiCommand, MethodResult<CreateNS_NhomChiPhiCommandResponse>>
    {
        public CreateNS_NhomChiPhiCommandHandler(IMapper mapper, INS_NhomChiPhiRepository NS_NhomChiPhiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomChiPhiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_NhomChiPhi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_NhomChiPhiCommandResponse>> Handle(CreateNS_NhomChiPhiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_NhomChiPhiCommandResponse>();
            var newNS_NhomChiPhi = new NS_NhomChiPhi(request.TenNhomChiPhi, request.DienGiai, request.SortIndex);
            newNS_NhomChiPhi.SetCreate(_user);
            newNS_NhomChiPhi.Status = request.Status.HasValue ? request.Status : newNS_NhomChiPhi.Status;
            newNS_NhomChiPhi.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_NhomChiPhi.IsActive;
            newNS_NhomChiPhi.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_NhomChiPhi.IsVisible;
            await _NS_NhomChiPhiRepository.AddAsync(newNS_NhomChiPhi).ConfigureAwait(false);
            await _NS_NhomChiPhiRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_NhomChiPhiCommandResponse>(newNS_NhomChiPhi);
            return methodResult;
        }
    }
}