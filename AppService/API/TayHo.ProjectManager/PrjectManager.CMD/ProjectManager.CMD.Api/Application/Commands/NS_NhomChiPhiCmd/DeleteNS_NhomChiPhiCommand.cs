using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NhomChiPhiCommand : IRequest<MethodResult<DeleteNS_NhomChiPhiCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_NhomChiPhiCommandResponse
    {
        public DeleteNS_NhomChiPhiCommandResponse(List<NS_NhomChiPhiCommandResponseDTO> NS_NhomChiPhi)
        {
            _NS_NhomChiPhi = NS_NhomChiPhi;
        }

        public List<NS_NhomChiPhiCommandResponseDTO> _NS_NhomChiPhi { get; }
    }
}
