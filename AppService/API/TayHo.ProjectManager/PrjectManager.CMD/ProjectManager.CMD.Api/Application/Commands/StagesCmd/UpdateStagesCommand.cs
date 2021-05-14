using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateStagesCommand : StagesCommandSet,IRequest<MethodResult<UpdateStagesCommandResponse>>
    {
       
    }

    public class UpdateStagesCommandResponse : StagesCommandResponseDTO
    {
    }
}