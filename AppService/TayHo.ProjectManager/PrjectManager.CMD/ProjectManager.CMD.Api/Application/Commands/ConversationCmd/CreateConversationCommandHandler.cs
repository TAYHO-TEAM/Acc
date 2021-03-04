using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateConversationCommandHandler : ConversationCommandHandler, IRequestHandler<CreateConversationCommand, MethodResult<CreateConversationCommandResponse>>
    {
        public CreateConversationCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IConversationRepository conversationRepository) : base(mapper, httpContextAccessor, conversationRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Conversation
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateConversationCommandResponse>> Handle(CreateConversationCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateConversationCommandResponse>();
            var newConversation = new Conversation(request.OwnerTable,request.TopicId,request.ParentId,request.Content);
            newConversation.SetCreate(_user);
            newConversation.Status = request.Status.HasValue ? request.Status : newConversation.Status;
            newConversation.IsActive = request.IsActive.HasValue ? request.IsActive : newConversation.IsActive;
            newConversation.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newConversation.IsVisible;
            await _conversationRepository.AddAsync(newConversation).ConfigureAwait(false);
            await _conversationRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateConversationCommandResponse>(newConversation);
            return methodResult;
        }
    }
}
