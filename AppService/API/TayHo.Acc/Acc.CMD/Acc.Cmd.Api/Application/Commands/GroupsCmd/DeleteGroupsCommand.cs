using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupsCommand : IRequest<MethodResult<DeleteGroupsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupsCommandResponse
    {
        public DeleteGroupsCommandResponse(List<GroupsCommandResponseDTO> Groups)
        {
            _Groups = Groups;
        }

        public List<GroupsCommandResponseDTO> _Groups { get; }
    }
}