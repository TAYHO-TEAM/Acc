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
    public class UpdateNS_HangMucCommandHandler : NS_HangMucCommandHandler,IRequestHandler<UpdateNS_HangMucCommand, MethodResult<UpdateNS_HangMucCommandResponse>>
    {
        public UpdateNS_HangMucCommandHandler(IMapper mapper, INS_HangMucRepository NS_HangMucRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HangMucRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_HangMuc.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_HangMucCommandResponse>> Handle(UpdateNS_HangMucCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_HangMucCommandResponse>();
            var existingNS_HangMuc = await _NS_HangMucRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_HangMuc == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_HangMuc.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_HangMuc.IsActive;
            existingNS_HangMuc.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_HangMuc.IsVisible;
            existingNS_HangMuc.Status = request.Status.HasValue ? request.Status : existingNS_HangMuc.Status;
            existingNS_HangMuc.SetParentId(request.ParentId);
            existingNS_HangMuc.SetTenHangMuc(request.TenHangMuc);
            existingNS_HangMuc.SetKyHieu(request.KyHieu);
            existingNS_HangMuc.SetProjectId(request.ProjectId);
            existingNS_HangMuc.SetUpdate(_user,0);
            _NS_HangMucRepository.Update(existingNS_HangMuc);
            await _NS_HangMucRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_HangMucCommandResponse>(existingNS_HangMuc);
            return methodResult;
        }
    }
}