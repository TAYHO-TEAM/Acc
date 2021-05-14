using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupsCommandHandler : GroupsCommandHandler,IRequestHandler<UpdateGroupsCommand, MethodResult<UpdateGroupsCommandResponse>>
    {
        public UpdateGroupsCommandHandler(IMapper mapper, IGroupsRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Groups.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupsCommandResponse>> Handle(UpdateGroupsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupsCommandResponse>();
            var existingGroups = await _GroupsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroups == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroups.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroups.IsActive;
            existingGroups.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingGroups.IsVisible;
            existingGroups.Status = request.Status.HasValue ? request.Status : existingGroups.Status;
            existingGroups.SetTitle(request.Title);
            existingGroups.SetDescriptions(request.Descriptions);
            existingGroups.SetType(request.Type);

            existingGroups.SetUpdate(_user,null);
            _GroupsRepository.Update(existingGroups);
            await _GroupsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupsCommandResponse>(existingGroups);
            return methodResult;
        }
    }
}