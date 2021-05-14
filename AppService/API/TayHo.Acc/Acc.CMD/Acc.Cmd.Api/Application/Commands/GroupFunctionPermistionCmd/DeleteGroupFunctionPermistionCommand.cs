using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupFunctionPermistionCommand : IRequest<MethodResult<DeleteGroupFunctionPermistionCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupFunctionPermistionCommandResponse
    {
        public DeleteGroupFunctionPermistionCommandResponse(List<GroupFunctionPermistionCommandResponseDTO> GroupFunctionPermistion)
        {
            _GroupFunctionPermistion = GroupFunctionPermistion;
        }

        public List<GroupFunctionPermistionCommandResponseDTO> _GroupFunctionPermistion { get; }
    }
}