using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupActionPermistionCommand : IRequest<MethodResult<DeleteGroupActionPermistionCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupActionPermistionCommandResponse
    {
        public DeleteGroupActionPermistionCommandResponse(List<GroupActionPermistionCommandResponseDTO> GroupActionPermistion)
        {
            _GroupActionPermistion = GroupActionPermistion;
        }

        public List<GroupActionPermistionCommandResponseDTO> _GroupActionPermistion { get; }
    }
}