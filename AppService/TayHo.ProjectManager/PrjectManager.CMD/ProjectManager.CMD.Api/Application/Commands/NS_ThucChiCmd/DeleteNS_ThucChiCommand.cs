using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_ThucChiCommand : IRequest<MethodResult<DeleteNS_ThucChiCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_ThucChiCommandResponse
    {
        public DeleteNS_ThucChiCommandResponse(List<NS_ThucChiCommandResponseDTO> NS_ThucChi)
        {
            _NS_ThucChi = NS_ThucChi;
        }

        public List<NS_ThucChiCommandResponseDTO> _NS_ThucChi { get; }
    }
}