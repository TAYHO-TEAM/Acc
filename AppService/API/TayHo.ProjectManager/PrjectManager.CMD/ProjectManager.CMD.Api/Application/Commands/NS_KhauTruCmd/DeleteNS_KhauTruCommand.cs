using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_KhauTruCommand : IRequest<MethodResult<DeleteNS_KhauTruCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_KhauTruCommandResponse
    {
        public DeleteNS_KhauTruCommandResponse(List<NS_KhauTruCommandResponseDTO> NS_KhauTru)
        {
            _NS_KhauTru = NS_KhauTru;
        }

        public List<NS_KhauTruCommandResponseDTO> _NS_KhauTru { get; }
    }
}