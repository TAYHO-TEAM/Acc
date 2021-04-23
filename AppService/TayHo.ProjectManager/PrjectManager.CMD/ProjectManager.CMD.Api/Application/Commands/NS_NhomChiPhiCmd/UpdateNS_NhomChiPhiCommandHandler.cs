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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NhomChiPhiCommandHandler : NS_NhomChiPhiCommandHandler,IRequestHandler<UpdateNS_NhomChiPhiCommand, MethodResult<UpdateNS_NhomChiPhiCommandResponse>>
    {
        public UpdateNS_NhomChiPhiCommandHandler(IMapper mapper, INS_NhomChiPhiRepository NS_NhomChiPhiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomChiPhiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_NhomChiPhi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_NhomChiPhiCommandResponse>> Handle(UpdateNS_NhomChiPhiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_NhomChiPhiCommandResponse>();
            var existingNS_NhomChiPhi = await _NS_NhomChiPhiRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NhomChiPhi == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_NhomChiPhi.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_NhomChiPhi.IsActive;
            existingNS_NhomChiPhi.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_NhomChiPhi.IsVisible;
            existingNS_NhomChiPhi.Status = request.Status.HasValue ? request.Status : existingNS_NhomChiPhi.Status;
            existingNS_NhomChiPhi.SetTenNhomChiPhi(request.TenNhomChiPhi);
            existingNS_NhomChiPhi.SetDienGiai(request.DienGiai);
            existingNS_NhomChiPhi.SetSortIndex(request.SortIndex);
            existingNS_NhomChiPhi.SetUpdate(_user,0);
            _NS_NhomChiPhiRepository.Update(existingNS_NhomChiPhi);
            await _NS_NhomChiPhiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_NhomChiPhiCommandResponse>(existingNS_NhomChiPhi);
            return methodResult;
        }
    }
}