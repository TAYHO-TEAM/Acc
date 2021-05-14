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
    public class UpdateNS_NhomCongViecDetailCommandHandler : NS_NhomCongViecDetailCommandHandler,IRequestHandler<UpdateNS_NhomCongViecDetailCommand, MethodResult<UpdateNS_NhomCongViecDetailCommandResponse>>
    {
        public UpdateNS_NhomCongViecDetailCommandHandler(IMapper mapper, INS_NhomCongViecDetailRepository NS_NhomCongViecDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomCongViecDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_NhomCongViecDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_NhomCongViecDetailCommandResponse>> Handle(UpdateNS_NhomCongViecDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_NhomCongViecDetailCommandResponse>();
            var existingNS_NhomCongViecDetail = await _NS_NhomCongViecDetailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NhomCongViecDetail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_NhomCongViecDetail.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_NhomCongViecDetail.IsActive;
            existingNS_NhomCongViecDetail.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_NhomCongViecDetail.IsVisible;
            existingNS_NhomCongViecDetail.Status = request.Status.HasValue ? request.Status : existingNS_NhomCongViecDetail.Status;
            existingNS_NhomCongViecDetail.SetNhomCongViecId(request.NhomCongViecId);
            existingNS_NhomCongViecDetail.SetGiaiDoanId(request.GiaiDoanId);
            existingNS_NhomCongViecDetail.SetGiaTri(request.GiaTri);
            existingNS_NhomCongViecDetail.SetSortIndex(request.SortIndex);
            existingNS_NhomCongViecDetail.SetUpdate(_user,0);
            _NS_NhomCongViecDetailRepository.Update(existingNS_NhomCongViecDetail);
            await _NS_NhomCongViecDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_NhomCongViecDetailCommandResponse>(existingNS_NhomCongViecDetail);
            return methodResult;
        }
    }
}