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
    public class UpdateNS_TamUngCommandHandler : NS_TamUngCommandHandler,IRequestHandler<UpdateNS_TamUngCommand, MethodResult<UpdateNS_TamUngCommandResponse>>
    {
        public UpdateNS_TamUngCommandHandler(IMapper mapper, INS_TamUngRepository NS_TamUngRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_TamUngRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_TamUng.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_TamUngCommandResponse>> Handle(UpdateNS_TamUngCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_TamUngCommandResponse>();
            var existingNS_TamUng = await _NS_TamUngRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_TamUng == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_TamUng.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_TamUng.IsActive;
            existingNS_TamUng.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_TamUng.IsVisible;
            existingNS_TamUng.Status = request.Status.HasValue ? request.Status : existingNS_TamUng.Status;
            existingNS_TamUng.SetGoiThauId(request.GoiThauId);
            existingNS_TamUng.SetProjectId(request.ProjectId);
            existingNS_TamUng.SetNoiDung(request.NoiDung);
            existingNS_TamUng.SetDienGiai(request.DienGiai);
            existingNS_TamUng.SetGiaTri(request.GiaTri);
            existingNS_TamUng.SetGiaTriCon(request.GiaTriCon);
            existingNS_TamUng.SetUpdate(_user,0);
            _NS_TamUngRepository.Update(existingNS_TamUng);
            await _NS_TamUngRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_TamUngCommandResponse>(existingNS_TamUng);
            return methodResult;
        }
    }
}