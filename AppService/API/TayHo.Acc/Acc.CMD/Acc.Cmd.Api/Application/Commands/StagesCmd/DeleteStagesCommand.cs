using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteStagesCommand : IRequest<MethodResult<DeleteStagesCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteStagesCommandResponse
    {
        public DeleteStagesCommandResponse(List<StagesCommandResponseDTO> Stages)
        {
            _Stages = Stages;
        }

        public List<StagesCommandResponseDTO> _Stages { get; }
    }
}