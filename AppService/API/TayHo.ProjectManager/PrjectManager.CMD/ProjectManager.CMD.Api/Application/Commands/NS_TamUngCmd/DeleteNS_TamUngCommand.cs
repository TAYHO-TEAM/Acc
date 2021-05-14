using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_TamUngCommand : IRequest<MethodResult<DeleteNS_TamUngCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_TamUngCommandResponse
    {
        public DeleteNS_TamUngCommandResponse(List<NS_TamUngCommandResponseDTO> NS_TamUng)
        {
            _NS_TamUng = NS_TamUng;
        }

        public List<NS_TamUngCommandResponseDTO> _NS_TamUng { get; }
    }
}