using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_ReasonCommand : IRequest<MethodResult<DeleteNS_ReasonCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_ReasonCommandResponse
    {
        public DeleteNS_ReasonCommandResponse(List<NS_ReasonCommandResponseDTO> NS_Reason)
        {
            _NS_Reason = NS_Reason;
        }

        public List<NS_ReasonCommandResponseDTO> _NS_Reason { get; }
    }
}