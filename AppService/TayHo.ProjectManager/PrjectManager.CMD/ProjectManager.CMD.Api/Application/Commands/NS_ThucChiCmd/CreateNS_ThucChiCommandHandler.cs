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
    public class CreateNS_ThucChiCommandHandler : NS_ThucChiCommandHandler, IRequestHandler<CreateNS_ThucChiCommand, MethodResult<CreateNS_ThucChiCommandResponse>>
    {
        public CreateNS_ThucChiCommandHandler(IMapper mapper, INS_ThucChiRepository NS_ThucChiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_ThucChiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_ThucChi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_ThucChiCommandResponse>> Handle(CreateNS_ThucChiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_ThucChiCommandResponse>();
            var newNS_ThucChi = new NS_ThucChi(request.NhomCongViecId,
                request.GoiThauId,
                request.ThangBaoCao,
                request.ThangThucChi,
                request.GiaTri);
            newNS_ThucChi.SetCreate(_user);
            newNS_ThucChi.Status = request.Status.HasValue ? request.Status : newNS_ThucChi.Status;
            newNS_ThucChi.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_ThucChi.IsActive;
            newNS_ThucChi.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_ThucChi.IsVisible;
            await _NS_ThucChiRepository.AddAsync(newNS_ThucChi).ConfigureAwait(false);
            await _NS_ThucChiRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_ThucChiCommandResponse>(newNS_ThucChi);
            return methodResult;
        }
    }
}