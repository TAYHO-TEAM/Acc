using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomCellContentCommand : CustomCellContentCommandSet,IRequest<MethodResult<UpdateCustomCellContentCommandResponse>>
    {
       
    }

    public class UpdateCustomCellContentCommandResponse : CustomCellContentCommandResponseDTO
    {
    }
}