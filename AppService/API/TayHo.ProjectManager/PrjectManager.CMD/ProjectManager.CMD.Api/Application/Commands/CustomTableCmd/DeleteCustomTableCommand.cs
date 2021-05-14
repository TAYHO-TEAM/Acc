using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomTableCommand : IRequest<MethodResult<DeleteCustomTableCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomTableCommandResponse
    {
        public DeleteCustomTableCommandResponse(List<CustomTableCommandResponseDTO> CustomTable)
        {
            _customTable = CustomTable;
        }

        public List<CustomTableCommandResponseDTO> _customTable { get; }
    }
}