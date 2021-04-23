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
    public class CreateNS_Phat_NhomCommandHandler : NS_Phat_NhomCommandHandler, IRequestHandler<CreateNS_Phat_NhomCommand, MethodResult<CreateNS_Phat_NhomCommandResponse>>
    {
        public CreateNS_Phat_NhomCommandHandler(IMapper mapper, INS_Phat_NhomRepository NS_Phat_NhomRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_Phat_NhomRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_Phat_Nhom
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_Phat_NhomCommandResponse>> Handle(CreateNS_Phat_NhomCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_Phat_NhomCommandResponse>();
            var newNS_Phat_Nhom = new NS_Phat_Nhom(request.TenNhomPhat, request.DienGiai, request.SortIndex);
            newNS_Phat_Nhom.SetCreate(_user);
            newNS_Phat_Nhom.Status = request.Status.HasValue ? request.Status : newNS_Phat_Nhom.Status;
            newNS_Phat_Nhom.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_Phat_Nhom.IsActive;
            newNS_Phat_Nhom.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNS_Phat_Nhom.IsVisible;
            await _NS_Phat_NhomRepository.AddAsync(newNS_Phat_Nhom).ConfigureAwait(false);
            await _NS_Phat_NhomRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_Phat_NhomCommandResponse>(newNS_Phat_Nhom);
            return methodResult;
        }
    }
}