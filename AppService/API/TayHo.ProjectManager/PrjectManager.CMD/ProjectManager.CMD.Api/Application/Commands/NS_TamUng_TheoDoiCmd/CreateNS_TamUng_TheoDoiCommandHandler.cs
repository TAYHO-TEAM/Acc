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
    public class CreateNS_TamUng_TheoDoiCommandHandler : NS_TamUng_TheoDoiCommandHandler, IRequestHandler<CreateNS_TamUng_TheoDoiCommand, MethodResult<CreateNS_TamUng_TheoDoiCommandResponse>>
    {
        public CreateNS_TamUng_TheoDoiCommandHandler(IMapper mapper, INS_TamUng_TheoDoiRepository NS_TamUng_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_TamUng_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NS_TamUng_TheoDoi
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNS_TamUng_TheoDoiCommandResponse>> Handle(CreateNS_TamUng_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNS_TamUng_TheoDoiCommandResponse>();
            var newNS_TamUng_TheoDoi = new NS_TamUng_TheoDoi(request.TamUngId,
request.NoiDung,
request.DienGiai,
request.GiaTri,
request.Dot);
            newNS_TamUng_TheoDoi.SetCreate(_user);
            newNS_TamUng_TheoDoi.Status = request.Status.HasValue ? request.Status : newNS_TamUng_TheoDoi.Status;
            newNS_TamUng_TheoDoi.IsActive = request.IsActive.HasValue ? request.IsActive : newNS_TamUng_TheoDoi.IsActive;
            newNS_TamUng_TheoDoi.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newNS_TamUng_TheoDoi.IsVisible;
            await _NS_TamUng_TheoDoiRepository.AddAsync(newNS_TamUng_TheoDoi).ConfigureAwait(false);
            await _NS_TamUng_TheoDoiRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNS_TamUng_TheoDoiCommandResponse>(newNS_TamUng_TheoDoi);
            return methodResult;
        }
    }
}