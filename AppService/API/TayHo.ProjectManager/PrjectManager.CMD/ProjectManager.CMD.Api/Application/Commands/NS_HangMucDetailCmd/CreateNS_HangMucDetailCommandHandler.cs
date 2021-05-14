using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_HangMucDetailCommandHandler : NS_HangMucDetailCommandHandler, IRequestHandler<CreateNS_HangMucDetailCommand, MethodResult<CreateNS_HangMucDetailCommandResponse>>
    {
        public CreateNS_HangMucDetailCommandHandler(IMapper mapper, INS_HangMucDetailRepository NS_HangMucDetailRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HangMucDetailRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_HangMucDetail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_HangMucDetailCommandResponse>> Handle(CreateNS_HangMucDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_HangMucDetailCommandResponse>();
            var newNS_HangMucDetail = new NS_HangMucDetail(request.HangMucId,
                request.ProjectId,
                request.GiaiDoanId,
                request.GiaTri);
            newNS_HangMucDetail.SetCreate(_user);
            newNS_HangMucDetail.Status = request.Status.HasValue ? request.Status : newNS_HangMucDetail.Status;
            newNS_HangMucDetail.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_HangMucDetail.IsActive;
            newNS_HangMucDetail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNS_HangMucDetail.IsVisible;
            await _NS_HangMucDetailRepository.AddAsync(newNS_HangMucDetail).ConfigureAwait(false);
            await _NS_HangMucDetailRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_HangMucDetailCommandResponse>(newNS_HangMucDetail);
            return methodResult;
        }
    }
}