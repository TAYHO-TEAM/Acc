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
    public class UpdateResponseRegistCommandHandler : ResponseRegistCommandHandler,IRequestHandler<UpdateResponseRegistCommand, MethodResult<UpdateResponseRegistCommandResponse>>
    {
        public UpdateResponseRegistCommandHandler(IMapper mapper, IResponseRegistRepository ResponseRegistRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ResponseRegistRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing ResponseRegist.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateResponseRegistCommandResponse>> Handle(UpdateResponseRegistCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateResponseRegistCommandResponse>();
            var existingResponseRegist = await _ResponseRegistRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingResponseRegist == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingResponseRegist.IsActive = request.IsActive.HasValue ? request.IsActive : existingResponseRegist.IsActive;
            existingResponseRegist.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingResponseRegist.IsVisible;
            existingResponseRegist.Status = request.Status.HasValue ? request.Status : existingResponseRegist.Status;

            existingResponseRegist.SetTitle(request.Title);
            existingResponseRegist.SetDescription(request.Description);
            existingResponseRegist.SetStepProcessId(request.StepProcessId);
            existingResponseRegist.SetRequestRegistId(request.RequestRegistId);
            existingResponseRegist.SetGroupId(request.GroupId);
            existingResponseRegist.SetReplyId(request.ReplyId);
            existingResponseRegist.SetNoAttachment(request.NoAttachment);
            existingResponseRegist.SetIsApprove( true);
            existingResponseRegist.SetTypeOfResult(request.TypeOfResult);

            existingResponseRegist.SetUpdate(_user,0);
            _ResponseRegistRepository.Update(existingResponseRegist);
            await _ResponseRegistRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateResponseRegistCommandResponse>(existingResponseRegist);
            return methodResult;
        }
    }
}