using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NhomCongViecCommand : IRequest<MethodResult<DeleteNS_NhomCongViecCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_NhomCongViecCommandResponse
    {
        public DeleteNS_NhomCongViecCommandResponse(List<NS_NhomCongViecCommandResponseDTO> NS_NhomCongViec)
        {
            _NS_NhomCongViec = NS_NhomCongViec;
        }

        public List<NS_NhomCongViecCommandResponseDTO> _NS_NhomCongViec { get; }
    }
}
