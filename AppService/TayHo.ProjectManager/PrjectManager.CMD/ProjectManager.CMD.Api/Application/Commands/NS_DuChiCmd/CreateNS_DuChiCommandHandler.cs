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
    public class CreateNS_DuChiCommandHandler : NS_DuChiCommandHandler, IRequestHandler<CreateNS_DuChiCommand, MethodResult<CreateNS_DuChiCommandResponse>>
    {
        public CreateNS_DuChiCommandHandler(IMapper mapper, INS_DuChiRepository NS_DuChiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_DuChiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_DuChi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_DuChiCommandResponse>> Handle(CreateNS_DuChiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_DuChiCommandResponse>();
            var newNS_DuChi = new NS_DuChi(request.ProjectId, request.NhomCongViecId,
                request.GroupId,
                request.ThoiGianBaoCao,
                request.ThoiGianDuChi,
                request.GiaTri);
            newNS_DuChi.SetCreate(_user);
            newNS_DuChi.Status = request.Status.HasValue ? request.Status : newNS_DuChi.Status;
            newNS_DuChi.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_DuChi.IsActive;
            newNS_DuChi.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_DuChi.IsVisible;
            await _NS_DuChiRepository.AddAsync(newNS_DuChi).ConfigureAwait(false);
            await _NS_DuChiRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_DuChiCommandResponse>(newNS_DuChi);
            return methodResult;
        }
    }
}