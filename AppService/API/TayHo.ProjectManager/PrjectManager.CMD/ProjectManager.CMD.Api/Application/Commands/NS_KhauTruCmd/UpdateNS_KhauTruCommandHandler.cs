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
    public class UpdateNS_KhauTruCommandHandler : NS_KhauTruCommandHandler,IRequestHandler<UpdateNS_KhauTruCommand, MethodResult<UpdateNS_KhauTruCommandResponse>>
    {
        public UpdateNS_KhauTruCommandHandler(IMapper mapper, INS_KhauTruRepository NS_KhauTruRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_KhauTruRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_KhauTru.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_KhauTruCommandResponse>> Handle(UpdateNS_KhauTruCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_KhauTruCommandResponse>();
            var existingNS_KhauTru = await _NS_KhauTruRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_KhauTru == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_KhauTru.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_KhauTru.IsActive;
            existingNS_KhauTru.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_KhauTru.IsVisible;
            existingNS_KhauTru.Status = request.Status.HasValue ? request.Status : existingNS_KhauTru.Status;
            existingNS_KhauTru.SetGoiThauId(request.GoiThauId);
            existingNS_KhauTru.SetProjectId(request.ProjectId);
            existingNS_KhauTru.SetNoiDung(request.NoiDung);
            existingNS_KhauTru.SetDienGiai(request.DienGiai);
            existingNS_KhauTru.SetGiaTri(request.GiaTri);
            existingNS_KhauTru.SetGiaTriCon(request.GiaTriCon);
            existingNS_KhauTru.SetUpdate(_user,0);
            _NS_KhauTruRepository.Update(existingNS_KhauTru);
            await _NS_KhauTruRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_KhauTruCommandResponse>(existingNS_KhauTru);
            return methodResult;
        }
    }
}