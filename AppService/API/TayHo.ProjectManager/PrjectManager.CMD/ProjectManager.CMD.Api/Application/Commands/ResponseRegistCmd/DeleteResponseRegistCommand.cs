using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteResponseRegistCommand : IRequest<MethodResult<DeleteResponseRegistCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteResponseRegistCommandResponse
    {
        public DeleteResponseRegistCommandResponse(List<ResponseRegistCommandResponseDTO> ResponseRegist)
        {
            ResponseRegist = ResponseRegist;
        }

        public List<ResponseRegistCommandResponseDTO> ResponseRegist { get; }
    }
}