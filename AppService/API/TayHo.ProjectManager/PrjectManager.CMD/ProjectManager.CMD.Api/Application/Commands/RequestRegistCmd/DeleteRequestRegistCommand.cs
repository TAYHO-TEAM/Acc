using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteRequestRegistCommand : IRequest<MethodResult<DeleteRequestRegistCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteRequestRegistCommandResponse
    {
        public DeleteRequestRegistCommandResponse(List<RequestRegistCommandResponseDTO> RequestRegist)
        {
            RequestRegist = RequestRegist;
        }

        public List<RequestRegistCommandResponseDTO> RequestRegist { get; }
    }
}