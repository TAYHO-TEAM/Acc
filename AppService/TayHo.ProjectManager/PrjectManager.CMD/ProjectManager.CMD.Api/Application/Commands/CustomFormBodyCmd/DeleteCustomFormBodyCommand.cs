using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomFormBodyCommand : IRequest<MethodResult<DeleteCustomFormBodyCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomFormBodyCommandResponse
    {
        public DeleteCustomFormBodyCommandResponse(List<CustomFormBodyCommandResponseDTO> CustomFormBody)
        {
            _customFormBody = CustomFormBody;
        }

        public List<CustomFormBodyCommandResponseDTO> _customFormBody { get; }
    }
}