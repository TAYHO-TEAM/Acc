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
    public class CreateNS_KhauTruCommandHandler : NS_KhauTruCommandHandler, IRequestHandler<CreateNS_KhauTruCommand, MethodResult<CreateNS_KhauTruCommandResponse>>
    {
        public CreateNS_KhauTruCommandHandler(IMapper mapper, INS_KhauTruRepository NS_KhauTruRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_KhauTruRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_KhauTru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_KhauTruCommandResponse>> Handle(CreateNS_KhauTruCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_KhauTruCommandResponse>();
            var newNS_KhauTru = new NS_KhauTru(request.GoiThauId,request.ProjectId,
                request.NoiDung,
                request.DienGiai,
                request.GiaTri,
                request.GiaTriCon);
            newNS_KhauTru.SetCreate(_user);
            newNS_KhauTru.Status = request.Status.HasValue ? request.Status : newNS_KhauTru.Status;
            newNS_KhauTru.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_KhauTru.IsActive;
            newNS_KhauTru.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_KhauTru.IsVisible;
            await _NS_KhauTruRepository.AddAsync(newNS_KhauTru).ConfigureAwait(false);
            await _NS_KhauTruRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_KhauTruCommandResponse>(newNS_KhauTru);
            return methodResult;
        }
    }
}