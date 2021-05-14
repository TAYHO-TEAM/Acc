using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomCellContentCommand : IRequest<MethodResult<DeleteCustomCellContentCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomCellContentCommandResponse
    {
        public DeleteCustomCellContentCommandResponse(List<CustomCellContentCommandResponseDTO> CustomCellContent)
        {
            _customCellContent = CustomCellContent;
        }

        public List<CustomCellContentCommandResponseDTO> _customCellContent { get; }
    }
}