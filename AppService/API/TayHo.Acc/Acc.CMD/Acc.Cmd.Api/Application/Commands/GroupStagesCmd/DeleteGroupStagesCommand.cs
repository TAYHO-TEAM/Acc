using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupStagesCommand : IRequest<MethodResult<DeleteGroupStagesCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupStagesCommandResponse
    {
        public DeleteGroupStagesCommandResponse(List<GroupStagesCommandResponseDTO> GroupStages)
        {
            _GroupStages = GroupStages;
        }

        public List<GroupStagesCommandResponseDTO> _GroupStages { get; }
    }
}