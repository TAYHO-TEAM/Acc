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
    public class UpdateNS_NhomCongViecCommandHandler : NS_NhomCongViecCommandHandler,IRequestHandler<UpdateNS_NhomCongViecCommand, MethodResult<UpdateNS_NhomCongViecCommandResponse>>
    {
        public UpdateNS_NhomCongViecCommandHandler(IMapper mapper, INS_NhomCongViecRepository NS_NhomCongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomCongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_NhomCongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_NhomCongViecCommandResponse>> Handle(UpdateNS_NhomCongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_NhomCongViecCommandResponse>();
            var existingNS_NhomCongViec = await _NS_NhomCongViecRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NhomCongViec == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_NhomCongViec.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_NhomCongViec.IsActive;
            existingNS_NhomCongViec.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_NhomCongViec.IsVisible;
            existingNS_NhomCongViec.Status = request.Status.HasValue ? request.Status : existingNS_NhomCongViec.Status;
            existingNS_NhomCongViec.SetHangMucId(request.HangMucId);
            existingNS_NhomCongViec.SetLoaiCongViecId(request.LoaiCongViecId);
            existingNS_NhomCongViec.SetGoiThauId(request.GoiThauId);
            existingNS_NhomCongViec.SetNhomChiPhiId(request.NhomChiPhiId);
            existingNS_NhomCongViec.SetProjectId(request.ProjectId);
            existingNS_NhomCongViec.SetTenNhomCongViec(request.TenNhomCongViec);
            existingNS_NhomCongViec.SetDienGiai(request.DienGiai);
            existingNS_NhomCongViec.SetSortIndex(request.SortIndex);
            existingNS_NhomCongViec.SetUpdate(_user,0);
            _NS_NhomCongViecRepository.Update(existingNS_NhomCongViec);
            await _NS_NhomCongViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_NhomCongViecCommandResponse>(existingNS_NhomCongViec);
            return methodResult;
        }
    }
}