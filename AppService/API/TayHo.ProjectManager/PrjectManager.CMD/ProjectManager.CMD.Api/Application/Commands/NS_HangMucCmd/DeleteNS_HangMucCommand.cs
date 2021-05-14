using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_HangMucCommand : IRequest<MethodResult<DeleteNS_HangMucCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_HangMucCommandResponse
    {
        public DeleteNS_HangMucCommandResponse(List<NS_HangMucCommandResponseDTO> NS_HangMuc)
        {
            _NS_HangMuc = NS_HangMuc;
        }

        public List<NS_HangMucCommandResponseDTO> _NS_HangMuc { get; }
    }
}