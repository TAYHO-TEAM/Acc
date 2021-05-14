using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteStepsProcessCommand : IRequest<MethodResult<DeleteStepsProcessCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteStepsProcessCommandResponse
    {
        public DeleteStepsProcessCommandResponse(List<StepsProcessCommandResponseDTO> StepsProcess)
        {
            _StepsProcess = StepsProcess;
        }

        public List<StepsProcessCommandResponseDTO> _StepsProcess { get; }
    }
}