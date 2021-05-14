using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupActionCommand : IRequest<MethodResult<DeleteGroupActionCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupActionCommandResponse
    {
        public DeleteGroupActionCommandResponse(List<GroupActionCommandResponseDTO> GroupAction)
        {
            _GroupAction = GroupAction;
        }

        public List<GroupActionCommandResponseDTO> _GroupAction { get; }
    }
}