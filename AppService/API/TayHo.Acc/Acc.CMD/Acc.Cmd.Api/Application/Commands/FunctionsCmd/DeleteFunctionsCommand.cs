using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteFunctionsCommand : IRequest<MethodResult<DeleteFunctionsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteFunctionsCommandResponse
    {
        public DeleteFunctionsCommandResponse(List<FunctionsCommandResponseDTO> Functions)
        {
            _Functions = Functions;
        }

        public List<FunctionsCommandResponseDTO> _Functions { get; }
    }
}