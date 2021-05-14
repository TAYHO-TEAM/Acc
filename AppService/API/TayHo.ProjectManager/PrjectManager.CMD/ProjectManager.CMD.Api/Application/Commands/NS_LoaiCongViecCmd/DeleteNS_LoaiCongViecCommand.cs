using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_LoaiCongViecCommand : IRequest<MethodResult<DeleteNS_LoaiCongViecCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_LoaiCongViecCommandResponse
    {
        public DeleteNS_LoaiCongViecCommandResponse(List<NS_LoaiCongViecCommandResponseDTO> NS_LoaiCongViec)
        {
            _NS_LoaiCongViec = NS_LoaiCongViec;
        }

        public List<NS_LoaiCongViecCommandResponseDTO> _NS_LoaiCongViec { get; }
    }
}
