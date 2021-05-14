using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupStepProcessPermistionCommand : IRequest<MethodResult<DeleteGroupStepProcessPermistionCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupStepProcessPermistionCommandResponse
    {
        public DeleteGroupStepProcessPermistionCommandResponse(List<GroupStepProcessPermistionCommandResponseDTO> GroupStepProcessPermistion)
        {
            _GroupStepProcessPermistion = GroupStepProcessPermistion;
        }

        public List<GroupStepProcessPermistionCommandResponseDTO> _GroupStepProcessPermistion { get; }
    }
}