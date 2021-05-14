using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupsCommandHandler : GroupsCommandHandler, IRequestHandler<DeleteGroupsCommand, MethodResult<DeleteGroupsCommandResponse>>
    {
        public DeleteGroupsCommandHandler(IMapper mapper, IGroupsRepository GroupsRepository ,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Groups.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupsCommandResponse>> Handle(DeleteGroupsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupsCommandResponse>();
            var existingGroupss = await _GroupsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupss == null || !existingGroupss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroups in existingGroupss)
            {
                existingGroups.UpdateDate = now;
                existingGroups.UpdateDateUTC = utc;
                existingGroups.IsDelete = true;
                existingGroups.SetUpdate(_user,null);
            }
            _GroupsRepository.UpdateRange(existingGroupss);
            await _GroupsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupsResponseDTOs = _mapper.Map<List<GroupsCommandResponseDTO>>(existingGroupss);
            methodResult.Result = new DeleteGroupsCommandResponse(GroupsResponseDTOs);
            return methodResult;
        }
    }
}