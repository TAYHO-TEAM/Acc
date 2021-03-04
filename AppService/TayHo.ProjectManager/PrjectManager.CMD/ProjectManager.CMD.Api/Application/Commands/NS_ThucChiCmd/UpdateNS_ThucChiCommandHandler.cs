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
    public class UpdateNS_ThucChiCommandHandler : NS_ThucChiCommandHandler,IRequestHandler<UpdateNS_ThucChiCommand, MethodResult<UpdateNS_ThucChiCommandResponse>>
    {
        public UpdateNS_ThucChiCommandHandler(IMapper mapper, INS_ThucChiRepository NS_ThucChiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_ThucChiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_ThucChi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_ThucChiCommandResponse>> Handle(UpdateNS_ThucChiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_ThucChiCommandResponse>();
            var existingNS_ThucChi = await _NS_ThucChiRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_ThucChi == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_ThucChi.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_ThucChi.IsActive;
            existingNS_ThucChi.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_ThucChi.IsVisible;
            existingNS_ThucChi.Status = request.Status.HasValue ? request.Status : existingNS_ThucChi.Status;
            existingNS_ThucChi.SetNhomCongViecId(request.NhomCongViecId);
            existingNS_ThucChi.SetGoiThauId(request.GoiThauId);
            existingNS_ThucChi.SetThangBaoCao(request.ThangBaoCao);
            existingNS_ThucChi.SetThangThucChi(request.ThangThucChi);
            existingNS_ThucChi.SetGiaTri(request.GiaTri);
            existingNS_ThucChi.SetUpdate(_user,0);
            _NS_ThucChiRepository.Update(existingNS_ThucChi);
            await _NS_ThucChiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_ThucChiCommandResponse>(existingNS_ThucChi);
            return methodResult;
        }
    }
}