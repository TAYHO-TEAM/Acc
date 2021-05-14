using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NhomCongViecDetailCommand : IRequest<MethodResult<DeleteNS_NhomCongViecDetailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_NhomCongViecDetailCommandResponse
    {
        public DeleteNS_NhomCongViecDetailCommandResponse(List<NS_NhomCongViecDetailCommandResponseDTO> NS_NhomCongViecDetail)
        {
            _NS_NhomCongViecDetail = NS_NhomCongViecDetail;
        }

        public List<NS_NhomCongViecDetailCommandResponseDTO> _NS_NhomCongViecDetail { get; }
    }
}
