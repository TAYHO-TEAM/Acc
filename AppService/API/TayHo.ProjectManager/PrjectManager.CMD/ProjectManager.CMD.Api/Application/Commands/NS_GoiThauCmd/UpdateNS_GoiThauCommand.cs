using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_GoiThauCommand : NS_GoiThauCommandSet,IRequest<MethodResult<UpdateNS_GoiThauCommandResponse>>
    {
       
    }

    public class UpdateNS_GoiThauCommandResponse : NS_GoiThauCommandResponseDTO
    {
    }
}