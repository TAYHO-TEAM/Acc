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
    public class UpdateRequestsCommandHandler : RequestsCommandHandler,IRequestHandler<UpdateRequestsCommand, MethodResult<UpdateRequestsCommandResponse>>
    {
        public UpdateRequestsCommandHandler(IMapper mapper, IRequestsRepository RequestsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestsRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing Requests.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateRequestsCommandResponse>> Handle(UpdateRequestsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateRequestsCommandResponse>();
            var existingRequest = await _RequestsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingRequest == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingRequest.IsActive = request.IsActive.HasValue ? request.IsActive : existingRequest.IsActive;
            existingRequest.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingRequest.IsVisible;
            existingRequest.Status = request.Status.HasValue ? request.Status : existingRequest.Status;
            existingRequest.SetCode(request.Code);
            existingRequest.SetNoAttachment(request.NoAttachment);
            existingRequest.SetPriority(request.Priority);
            existingRequest.SetProjectId(request.ProjectId);
            existingRequest.SetReplyById(request.ReplyById);
            existingRequest.SetRequestFromId(request.RequestFromId);
            existingRequest.SetSendDateTime(request.SendDateTime);
            existingRequest.SetStageId(request.StageId);
            existingRequest.SetUpdate(_user,0);
            _RequestsRepository.Update(existingRequest);
            await _RequestsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateRequestsCommandResponse>(existingRequest);
            return methodResult;
        }
    }
}