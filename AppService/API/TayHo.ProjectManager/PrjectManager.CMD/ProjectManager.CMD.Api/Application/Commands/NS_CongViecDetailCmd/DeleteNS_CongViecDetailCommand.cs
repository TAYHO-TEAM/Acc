using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_CongViecDetailCommand : IRequest<MethodResult<DeleteNS_CongViecDetailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_CongViecDetailCommandResponse
    {
        public DeleteNS_CongViecDetailCommandResponse(List<NS_CongViecDetailCommandResponseDTO> NS_CongViecDetail)
        {
            _NS_CongViecDetail = NS_CongViecDetail;
        }

        public List<NS_CongViecDetailCommandResponseDTO> _NS_CongViecDetail { get; }
    }
}