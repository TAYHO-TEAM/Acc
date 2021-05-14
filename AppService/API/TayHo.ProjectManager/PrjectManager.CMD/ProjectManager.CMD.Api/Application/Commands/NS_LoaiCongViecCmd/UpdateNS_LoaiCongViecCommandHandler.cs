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
    public class UpdateNS_LoaiCongViecCommandHandler : NS_LoaiCongViecCommandHandler,IRequestHandler<UpdateNS_LoaiCongViecCommand, MethodResult<UpdateNS_LoaiCongViecCommandResponse>>
    {
        public UpdateNS_LoaiCongViecCommandHandler(IMapper mapper, INS_LoaiCongViecRepository NS_LoaiCongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_LoaiCongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_LoaiCongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_LoaiCongViecCommandResponse>> Handle(UpdateNS_LoaiCongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_LoaiCongViecCommandResponse>();
            var existingNS_LoaiCongViec = await _NS_LoaiCongViecRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_LoaiCongViec == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_LoaiCongViec.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_LoaiCongViec.IsActive;
            existingNS_LoaiCongViec.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_LoaiCongViec.IsVisible;
            existingNS_LoaiCongViec.Status = request.Status.HasValue ? request.Status : existingNS_LoaiCongViec.Status;
            existingNS_LoaiCongViec.SetTenLoaiCongViec(request.TenLoaiCongViec);
            existingNS_LoaiCongViec.SetDienGiai(request.DienGiai);
            existingNS_LoaiCongViec.SetKyHieu(request.KyHieu);
            existingNS_LoaiCongViec.SetProjectId(request.ProjectId);
            existingNS_LoaiCongViec.SetSortIndex(request.SortIndex);
            existingNS_LoaiCongViec.SetUpdate(_user,0);
            _NS_LoaiCongViecRepository.Update(existingNS_LoaiCongViec);
            await _NS_LoaiCongViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_LoaiCongViecCommandResponse>(existingNS_LoaiCongViec);
            return methodResult;
        }
    }
}