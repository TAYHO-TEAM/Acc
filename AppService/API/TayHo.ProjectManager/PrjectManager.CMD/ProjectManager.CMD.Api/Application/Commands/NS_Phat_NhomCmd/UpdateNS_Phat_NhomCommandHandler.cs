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
    public class UpdateNS_Phat_NhomCommandHandler : NS_Phat_NhomCommandHandler,IRequestHandler<UpdateNS_Phat_NhomCommand, MethodResult<UpdateNS_Phat_NhomCommandResponse>>
    {
        public UpdateNS_Phat_NhomCommandHandler(IMapper mapper, INS_Phat_NhomRepository NS_Phat_NhomRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_Phat_NhomRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_Phat_Nhom.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_Phat_NhomCommandResponse>> Handle(UpdateNS_Phat_NhomCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_Phat_NhomCommandResponse>();
            var existingNS_Phat_Nhom = await _NS_Phat_NhomRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Phat_Nhom == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_Phat_Nhom.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_Phat_Nhom.IsActive;
            existingNS_Phat_Nhom.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_Phat_Nhom.IsVisible;
            existingNS_Phat_Nhom.Status = request.Status.HasValue ? request.Status : existingNS_Phat_Nhom.Status;
            existingNS_Phat_Nhom.SetTenNhomPhat(request.TenNhomPhat);
            existingNS_Phat_Nhom.SetDienGiai(request.DienGiai);
            existingNS_Phat_Nhom.SetSortIndex(request.SortIndex);
            existingNS_Phat_Nhom.SetUpdate(_user,0);
            _NS_Phat_NhomRepository.Update(existingNS_Phat_Nhom);
            await _NS_Phat_NhomRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_Phat_NhomCommandResponse>(existingNS_Phat_Nhom);
            return methodResult;
        }
    }
}