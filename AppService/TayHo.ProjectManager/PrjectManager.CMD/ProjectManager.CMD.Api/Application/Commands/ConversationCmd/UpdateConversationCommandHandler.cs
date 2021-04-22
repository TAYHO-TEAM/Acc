using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateConversationCommandHandler : ConversationCommandHandler, IRequestHandler<UpdateConversationCommand, MethodResult<UpdateConversationCommandResponse>>
    {
        private int _function = 3;
        public UpdateConversationCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, IConversationRepository conversationRepository) : base(mapper, httpContextAccessor, conversationRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Conversation.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateConversationCommandResponse>> Handle(UpdateConversationCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateConversationCommandResponse>();
            var existingConversation = await _conversationRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingConversation == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if ((await _conversationRepository.BaseCheckPermistion((int)request.Id, _user, _actionId, _tableName, _function)) <1)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr02), new[]
               {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingConversation.IsActive = request.IsActive.HasValue ? request.IsActive : existingConversation.IsActive;
            existingConversation.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingConversation.IsVisible;
            existingConversation.Status = request.Status.HasValue ? request.Status : existingConversation.Status;

            existingConversation.SetOwnerTable(request.OwnerTable);
            existingConversation.SetTopicId(request.TopicId);
            existingConversation.SetParentId(request.ParentId);
            existingConversation.SetContent(request.Content);
            existingConversation.SetNoAttachment(request.NoAttachment);

            existingConversation.SetUpdate(_user, null);
            _conversationRepository.Update(existingConversation);
            await _conversationRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateConversationCommandResponse>(existingConversation);
            return methodResult;
        }
    }
}
