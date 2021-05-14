using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_HangMucDetailCommandHandler : NS_HangMucDetailCommandHandler, IRequestHandler<UpdateNS_HangMucDetailCommand, MethodResult<UpdateNS_HangMucDetailCommandResponse>>
    {
        public UpdateNS_HangMucDetailCommandHandler(IMapper mapper, INS_HangMucDetailRepository NS_HangMucDetailRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HangMucDetailRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_HangMucDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_HangMucDetailCommandResponse>> Handle(UpdateNS_HangMucDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_HangMucDetailCommandResponse>();
            var existingNS_HangMucDetail = await _NS_HangMucDetailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_HangMucDetail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_HangMucDetail.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_HangMucDetail.IsActive;
            existingNS_HangMucDetail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_HangMucDetail.IsVisible;
            existingNS_HangMucDetail.Status = request.Status.HasValue ? request.Status : existingNS_HangMucDetail.Status;
            existingNS_HangMucDetail.SetHangMucId(request.HangMucId);
            existingNS_HangMucDetail.SetProjectId(request.ProjectId);
            existingNS_HangMucDetail.SetGiaiDoanId(request.GiaiDoanId);
            existingNS_HangMucDetail.SetGiaTri(request.GiaTri);
            existingNS_HangMucDetail.SetUpdate(_user, 0);
            _NS_HangMucDetailRepository.Update(existingNS_HangMucDetail);
            await _NS_HangMucDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_HangMucDetailCommandResponse>(existingNS_HangMucDetail);
            return methodResult;
        }
    }
}