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
    public class CreateNS_KhauTru_TheoDoiCommandHandler : NS_KhauTru_TheoDoiCommandHandler, IRequestHandler<CreateNS_KhauTru_TheoDoiCommand, MethodResult<CreateNS_KhauTru_TheoDoiCommandResponse>>
    {
        public CreateNS_KhauTru_TheoDoiCommandHandler(IMapper mapper, INS_KhauTru_TheoDoiRepository NS_KhauTru_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_KhauTru_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_KhauTru_TheoDoi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_KhauTru_TheoDoiCommandResponse>> Handle(CreateNS_KhauTru_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_KhauTru_TheoDoiCommandResponse>();
            var newNS_KhauTru_TheoDoi = new NS_KhauTru_TheoDoi(request.KhauTruId,
request.NoiDung,
request.DienGiai,
request.GiaTri,
request.Dot);
            newNS_KhauTru_TheoDoi.SetCreate(_user);
            newNS_KhauTru_TheoDoi.Status = request.Status.HasValue ? request.Status : newNS_KhauTru_TheoDoi.Status;
            newNS_KhauTru_TheoDoi.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_KhauTru_TheoDoi.IsActive;
            newNS_KhauTru_TheoDoi.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_KhauTru_TheoDoi.IsVisible;
            await _NS_KhauTru_TheoDoiRepository.AddAsync(newNS_KhauTru_TheoDoi).ConfigureAwait(false);
            await _NS_KhauTru_TheoDoiRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_KhauTru_TheoDoiCommandResponse>(newNS_KhauTru_TheoDoi);
            return methodResult;
        }
    }
}