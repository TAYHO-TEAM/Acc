using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteRequestDetailCommand : IRequest<MethodResult<DeleteRequestDetailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteRequestDetailCommandResponse
    {
        public DeleteRequestDetailCommandResponse(List<RequestDetailCommandResponseDTO> RequestDetail)
        {
            requestDetail = RequestDetail;
        }

        public List<RequestDetailCommandResponseDTO> requestDetail { get; }
    }
}