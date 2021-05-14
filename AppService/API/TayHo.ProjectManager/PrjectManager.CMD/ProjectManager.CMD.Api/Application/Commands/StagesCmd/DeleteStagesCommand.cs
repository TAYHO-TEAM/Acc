using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteStagesCommand : IRequest<MethodResult<DeleteStagesCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteStagesCommandResponse
    {
        public DeleteStagesCommandResponse(List<StagesCommandResponseDTO> Stages)
        {
            stages = Stages;
        }

        public List<StagesCommandResponseDTO> stages { get; }
    }
}