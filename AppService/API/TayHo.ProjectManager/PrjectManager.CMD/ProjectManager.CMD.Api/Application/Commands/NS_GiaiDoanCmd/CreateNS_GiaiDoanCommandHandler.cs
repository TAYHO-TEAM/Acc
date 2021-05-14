using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_GiaiDoanCommandHandler : NS_GiaiDoanCommandHandler, IRequestHandler<CreateNS_GiaiDoanCommand, MethodResult<CreateNS_GiaiDoanCommandResponse>>
    {
        public CreateNS_GiaiDoanCommandHandler(IMapper mapper, INS_GiaiDoanRepository NS_GiaiDoanRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_GiaiDoanRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_GiaiDoan
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_GiaiDoanCommandResponse>> Handle(CreateNS_GiaiDoanCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_GiaiDoanCommandResponse>();
            var newNS_GiaiDoan = new NS_GiaiDoan(request.TenGiaiDoan,
                request.DienGiai,
                request.ProjectId,
                request.GroupId,
                request.CapDo,
                request.SortIndex);
            newNS_GiaiDoan.SetCreate(_user);
            newNS_GiaiDoan.Status = request.Status.HasValue ? request.Status : newNS_GiaiDoan.Status;
            newNS_GiaiDoan.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_GiaiDoan.IsActive;
            newNS_GiaiDoan.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNS_GiaiDoan.IsVisible;
            await _NS_GiaiDoanRepository.AddAsync(newNS_GiaiDoan).ConfigureAwait(false);
            await _NS_GiaiDoanRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_GiaiDoanCommandResponse>(newNS_GiaiDoan);
            return methodResult;
        }
    }
}