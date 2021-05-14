using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomFormCommand : IRequest<MethodResult<DeleteCustomFormCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomFormCommandResponse
    {
        public DeleteCustomFormCommandResponse(List<CustomFormCommandResponseDTO> CustomForm)
        {
            _customForm = CustomForm;
        }

        public List<CustomFormCommandResponseDTO> _customForm { get; }
    }
}