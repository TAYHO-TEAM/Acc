using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeletePermistionsCommand : IRequest<MethodResult<DeletePermistionsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeletePermistionsCommandResponse
    {
        public DeletePermistionsCommandResponse(List<PermistionsCommandResponseDTO> Permistions)
        {
            _Permistions = Permistions;
        }

        public List<PermistionsCommandResponseDTO> _Permistions { get; }
    }
}