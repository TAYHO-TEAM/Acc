using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_HangMucDetailCommand : IRequest<MethodResult<DeleteNS_HangMucDetailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_HangMucDetailCommandResponse
    {
        public DeleteNS_HangMucDetailCommandResponse(List<NS_HangMucDetailCommandResponseDTO> NS_HangMucDetail)
        {
            _NS_HangMucDetail = NS_HangMucDetail;
        }

        public List<NS_HangMucDetailCommandResponseDTO> _NS_HangMucDetail { get; }
    }
}