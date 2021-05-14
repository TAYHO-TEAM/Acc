using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupPermistionCommand : IRequest<MethodResult<DeleteGroupPermistionCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupPermistionCommandResponse
    {
        public DeleteGroupPermistionCommandResponse(List<GroupPermistionCommandResponseDTO> GroupPermistion)
        {
            _GroupPermistion = GroupPermistion;
        }

        public List<GroupPermistionCommandResponseDTO> _GroupPermistion { get; }
    }
}