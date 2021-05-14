using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_GiaiDoanCommand : IRequest<MethodResult<DeleteNS_GiaiDoanCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_GiaiDoanCommandResponse
    {
        public DeleteNS_GiaiDoanCommandResponse(List<NS_GiaiDoanCommandResponseDTO> NS_GiaiDoan)
        {
            _NS_GiaiDoan = NS_GiaiDoan;
        }

        public List<NS_GiaiDoanCommandResponseDTO> _NS_GiaiDoan { get; }
    }
}
