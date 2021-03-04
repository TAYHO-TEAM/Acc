using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_DuChiCommand : IRequest<MethodResult<DeleteNS_DuChiCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_DuChiCommandResponse
    {
        public DeleteNS_DuChiCommandResponse(List<NS_DuChiCommandResponseDTO> NS_DuChi)
        {
            _NS_DuChi = NS_DuChi;
        }

        public List<NS_DuChiCommandResponseDTO> _NS_DuChi { get; }
    }
}