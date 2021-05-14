using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomFormContentCommand : IRequest<MethodResult<DeleteCustomFormContentCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomFormContentCommandResponse
    {
        public DeleteCustomFormContentCommandResponse(List<CustomFormContentCommandResponseDTO> CustomFormContent)
        {
            _customFormContent = CustomFormContent;
        }

        public List<CustomFormContentCommandResponseDTO> _customFormContent { get; }
    }
}