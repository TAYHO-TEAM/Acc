using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_PhatCommand : IRequest<MethodResult<DeleteNS_PhatCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_PhatCommandResponse
    {
        public DeleteNS_PhatCommandResponse(List<NS_PhatCommandResponseDTO> NS_Phat)
        {
            _NS_Phat = NS_Phat;
        }

        public List<NS_PhatCommandResponseDTO> _NS_Phat { get; }
    }
}