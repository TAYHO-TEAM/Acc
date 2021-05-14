using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteRequestsCommand : IRequest<MethodResult<DeleteRequestsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteRequestsCommandResponse
    {
        public DeleteRequestsCommandResponse(List<RequestsCommandResponseDTO> Requests)
        {
            requests = Requests;
        }

        public List<RequestsCommandResponseDTO> requests { get; }
    }
}