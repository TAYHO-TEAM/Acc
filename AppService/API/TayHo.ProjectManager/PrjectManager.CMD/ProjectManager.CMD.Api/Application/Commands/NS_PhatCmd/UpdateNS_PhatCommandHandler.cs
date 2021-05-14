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
    public class UpdateNS_PhatCommandHandler : NS_PhatCommandHandler,IRequestHandler<UpdateNS_PhatCommand, MethodResult<UpdateNS_PhatCommandResponse>>
    {
        public UpdateNS_PhatCommandHandler(IMapper mapper, INS_PhatRepository NS_PhatRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_PhatRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_Phat.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_PhatCommandResponse>> Handle(UpdateNS_PhatCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_PhatCommandResponse>();
            var existingNS_Phat = await _NS_PhatRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Phat == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_Phat.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_Phat.IsActive;
            existingNS_Phat.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_Phat.IsVisible;
            existingNS_Phat.Status = request.Status.HasValue ? request.Status : existingNS_Phat.Status;
            existingNS_Phat.SetGoiThauId(request.GoiThauId);
            existingNS_Phat.SetProjectId(request.ProjectId);
            existingNS_Phat.SetNhomPhatId(request.NhomPhatId);
            existingNS_Phat.SetNoiDung(request.NoiDung);
            existingNS_Phat.SetDienGiai(request.DienGiai);
            existingNS_Phat.SetGiaTri(request.GiaTri);
            existingNS_Phat.SetGiaTriCon(request.GiaTriCon);
            existingNS_Phat.SetUpdate(_user,0);
            _NS_PhatRepository.Update(existingNS_Phat);
            await _NS_PhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_PhatCommandResponse>(existingNS_Phat);
            return methodResult;
        }
    }
}