using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateStagesCommand : StagesCommandSet,IRequest<MethodResult<UpdateStagesCommandResponse>>
    {
       
    }

    public class UpdateStagesCommandResponse : StagesCommandResponseDTO
    {
    }
}