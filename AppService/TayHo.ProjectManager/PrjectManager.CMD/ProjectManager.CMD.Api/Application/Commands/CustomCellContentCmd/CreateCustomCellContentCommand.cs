using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomCellContentCommand :CustomCellContentCommandSet, IRequest<MethodResult<CreateCustomCellContentCommandResponse>>
    {
        
    }
    public class CreateFormCustomCellContentCommand : FormCustomCellContentCommandSet, IRequest<MethodResult<CreateFormCustomCellContentCommandResponse>>
    {

    }
    public class CreateCustomCellContentCommands : IRequest<MethodResult<CreateCustomCellContentCommandResponses>>
    {
        public List<CreateCustomCellContentCommand> createCustomCellContentCommands { get; set; }
    }

    public class CreateCustomCellContentCommandResponse : CustomCellContentCommandResponseDTO 
    { 
    }
    public class CreateFormCustomCellContentCommandResponse : FormCustomCellContentCommandResponseDTO
    {
    }
    public class CreateCustomCellContentCommandResponses  
    {
        public CreateCustomCellContentCommandResponses(List<CustomCellContentCommandResponseDTO> CustomCellContent)
        {
            _customCellContent = CustomCellContent;
        }
        public List<CustomCellContentCommandResponseDTO> _customCellContent { get; }
    }

}