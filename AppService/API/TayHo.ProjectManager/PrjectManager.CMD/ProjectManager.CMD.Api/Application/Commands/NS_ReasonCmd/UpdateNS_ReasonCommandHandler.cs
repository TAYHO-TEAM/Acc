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
    public class UpdateNS_ReasonCommandHandler : NS_ReasonCommandHandler,IRequestHandler<UpdateNS_ReasonCommand, MethodResult<UpdateNS_ReasonCommandResponse>>
    {
        public UpdateNS_ReasonCommandHandler(IMapper mapper, INS_ReasonRepository NS_ReasonRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_ReasonRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_Reason.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_ReasonCommandResponse>> Handle(UpdateNS_ReasonCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_ReasonCommandResponse>();
            var existingNS_Reason = await _NS_ReasonRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Reason == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            } 

            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_Reason.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_Reason.IsActive;
            existingNS_Reason.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_Reason.IsVisible;
            existingNS_Reason.Status = request.Status.HasValue ? request.Status : existingNS_Reason.Status;
            existingNS_Reason.SetTen(request.Ten);
            existingNS_Reason.SetDienGiai(request.DienGiai);
            existingNS_Reason.SetUpdate(_user,0);
            _NS_ReasonRepository.Update(existingNS_Reason);
            await _NS_ReasonRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_ReasonCommandResponse>(existingNS_Reason);
            return methodResult;
        }
    }
}