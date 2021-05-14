using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomColumCommand : IRequest<MethodResult<DeleteCustomColumCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomColumCommandResponse
    {
        public DeleteCustomColumCommandResponse(List<CustomColumCommandResponseDTO> CustomColum)
        {
            _customColum = CustomColum;
        }

        public List<CustomColumCommandResponseDTO> _customColum { get; }
    }
}