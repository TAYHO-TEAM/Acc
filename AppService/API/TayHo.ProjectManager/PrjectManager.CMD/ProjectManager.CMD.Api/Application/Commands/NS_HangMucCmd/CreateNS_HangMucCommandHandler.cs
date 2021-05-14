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
    public class CreateNS_HangMucCommandHandler : NS_HangMucCommandHandler, IRequestHandler<CreateNS_HangMucCommand, MethodResult<CreateNS_HangMucCommandResponse>>
    {
        public CreateNS_HangMucCommandHandler(IMapper mapper, INS_HangMucRepository NS_HangMucRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HangMucRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_HangMuc
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_HangMucCommandResponse>> Handle(CreateNS_HangMucCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_HangMucCommandResponse>();
            var newNS_HangMuc = new NS_HangMuc(request.ParentId,
                request.TenHangMuc,
                request.KyHieu,
                request.ProjectId);
            newNS_HangMuc.SetCreate(_user);
            newNS_HangMuc.Status = request.Status.HasValue ? request.Status : newNS_HangMuc.Status;
            newNS_HangMuc.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_HangMuc.IsActive;
            newNS_HangMuc.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_HangMuc.IsVisible;
            await _NS_HangMucRepository.AddAsync(newNS_HangMuc).ConfigureAwait(false);
            await _NS_HangMucRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_HangMucCommandResponse>(newNS_HangMuc);
            return methodResult;
        }
    }
}