using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_KhauTruCommand : NS_KhauTruCommandSet,IRequest<MethodResult<UpdateNS_KhauTruCommandResponse>>
    {
       
    }

    public class UpdateNS_KhauTruCommandResponse : NS_KhauTruCommandResponseDTO
    {
    }
}