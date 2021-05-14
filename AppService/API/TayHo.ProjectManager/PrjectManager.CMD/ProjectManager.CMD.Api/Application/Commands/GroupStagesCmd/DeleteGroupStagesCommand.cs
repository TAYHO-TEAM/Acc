using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteGroupStagesCommand : IRequest<MethodResult<DeleteGroupStagesCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupStagesCommandResponse
    {
        public DeleteGroupStagesCommandResponse(List<GroupStagesCommandResponseDTO> GroupStages)
        {
            groupStages = GroupStages;
        }

        public List<GroupStagesCommandResponseDTO> groupStages { get; }
    }
}