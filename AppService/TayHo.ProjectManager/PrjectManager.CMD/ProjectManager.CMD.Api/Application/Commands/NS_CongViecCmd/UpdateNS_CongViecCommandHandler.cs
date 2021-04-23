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
    public class UpdateNS_CongViecCommandHandler : NS_CongViecCommandHandler,IRequestHandler<UpdateNS_CongViecCommand, MethodResult<UpdateNS_CongViecCommandResponse>>
    {
        public UpdateNS_CongViecCommandHandler(IMapper mapper, INS_CongViecRepository NS_CongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_CongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_CongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_CongViecCommandResponse>> Handle(UpdateNS_CongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_CongViecCommandResponse>();
            var existingNS_CongViec = await _NS_CongViecRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_CongViec == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_CongViec.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_CongViec.IsActive;
            existingNS_CongViec.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_CongViec.IsVisible;
            existingNS_CongViec.Status = request.Status.HasValue ? request.Status : existingNS_CongViec.Status;
            existingNS_CongViec.SetNhomCongViecId(request.NhomCongViecId);
            existingNS_CongViec.SetNhom(request.Nhom);
            existingNS_CongViec.SetTenCongViec(request.TenCongViec);
            existingNS_CongViec.SetDienGiai(request.DienGiai);
            existingNS_CongViec.SetDonViTinh(request.DonViTinh);
            existingNS_CongViec.SetSortIndex(request.SortIndex);
            existingNS_CongViec.SetUpdate(_user,0);
            _NS_CongViecRepository.Update(existingNS_CongViec);
            await _NS_CongViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_CongViecCommandResponse>(existingNS_CongViec);
            return methodResult;
        }
    }
}