using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_CongViecCommand : IRequest<MethodResult<DeleteNS_CongViecCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_CongViecCommandResponse
    {
        public DeleteNS_CongViecCommandResponse(List<NS_CongViecCommandResponseDTO> NS_CongViec)
        {
            _NS_CongViec = NS_CongViec;
        }

        public List<NS_CongViecCommandResponseDTO> _NS_CongViec { get; }
    }
}
