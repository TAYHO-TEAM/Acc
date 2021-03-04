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
    public class UpdateNS_DuChiCommandHandler : NS_DuChiCommandHandler,IRequestHandler<UpdateNS_DuChiCommand, MethodResult<UpdateNS_DuChiCommandResponse>>
    {
        public UpdateNS_DuChiCommandHandler(IMapper mapper, INS_DuChiRepository NS_DuChiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_DuChiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_DuChi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_DuChiCommandResponse>> Handle(UpdateNS_DuChiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_DuChiCommandResponse>();
            var existingNS_DuChi = await _NS_DuChiRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_DuChi == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_DuChi.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_DuChi.IsActive;
            existingNS_DuChi.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_DuChi.IsVisible;
            existingNS_DuChi.Status = request.Status.HasValue ? request.Status : existingNS_DuChi.Status;
            existingNS_DuChi.SetProjectId(request.ProjectId);
            existingNS_DuChi.SetNhomCongViecId(request.NhomCongViecId);
            existingNS_DuChi.SetGroupId(request.GroupId);
            existingNS_DuChi.SetThoiGianBaoCao(request.ThoiGianBaoCao);
            existingNS_DuChi.SetThoiGianDuChi(request.ThoiGianDuChi);
            existingNS_DuChi.SetGiaTri(request.GiaTri);
            existingNS_DuChi.SetUpdate(_user,0);
            _NS_DuChiRepository.Update(existingNS_DuChi);
            await _NS_DuChiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_DuChiCommandResponse>(existingNS_DuChi);
            return methodResult;
        }
    }
}