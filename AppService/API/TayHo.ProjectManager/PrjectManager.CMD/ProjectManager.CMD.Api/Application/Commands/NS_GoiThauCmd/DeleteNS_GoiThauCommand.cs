using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_GoiThauCommand : IRequest<MethodResult<DeleteNS_GoiThauCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_GoiThauCommandResponse
    {
        public DeleteNS_GoiThauCommandResponse(List<NS_GoiThauCommandResponseDTO> NS_GoiThau)
        {
            _NS_GoiThau = NS_GoiThau;
        }

        public List<NS_GoiThauCommandResponseDTO> _NS_GoiThau { get; }
    }
}