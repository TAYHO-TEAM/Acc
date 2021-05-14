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
    public class CreateNS_Phat_TheoDoiCommandHandler : NS_Phat_TheoDoiCommandHandler, IRequestHandler<CreateNS_Phat_TheoDoiCommand, MethodResult<CreateNS_Phat_TheoDoiCommandResponse>>
    {
        public CreateNS_Phat_TheoDoiCommandHandler(IMapper mapper, INS_Phat_TheoDoiRepository NS_Phat_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_Phat_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_Phat_TheoDoi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_Phat_TheoDoiCommandResponse>> Handle(CreateNS_Phat_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_Phat_TheoDoiCommandResponse>();
            var newNS_Phat_TheoDoi = new NS_Phat_TheoDoi(request.PhatId,
                request.NoiDung,
                request.DienGiai,
                request.GiaTri,
                request.Dot);
            newNS_Phat_TheoDoi.SetCreate(_user);
            newNS_Phat_TheoDoi.Status = request.Status.HasValue ? request.Status : newNS_Phat_TheoDoi.Status;
            newNS_Phat_TheoDoi.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_Phat_TheoDoi.IsActive;
            newNS_Phat_TheoDoi.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_Phat_TheoDoi.IsVisible;
            await _NS_Phat_TheoDoiRepository.AddAsync(newNS_Phat_TheoDoi).ConfigureAwait(false);
            await _NS_Phat_TheoDoiRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_Phat_TheoDoiCommandResponse>(newNS_Phat_TheoDoi);
            return methodResult;
        }
    }
}