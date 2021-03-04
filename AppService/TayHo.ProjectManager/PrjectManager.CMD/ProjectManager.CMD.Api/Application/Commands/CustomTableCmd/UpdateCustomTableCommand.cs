using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomTableCommand : CustomTableCommandSet,IRequest<MethodResult<UpdateCustomTableCommandResponse>>
    {
       
    }

    public class UpdateCustomTableCommandResponse : CustomTableCommandResponseDTO
    {
    }
}