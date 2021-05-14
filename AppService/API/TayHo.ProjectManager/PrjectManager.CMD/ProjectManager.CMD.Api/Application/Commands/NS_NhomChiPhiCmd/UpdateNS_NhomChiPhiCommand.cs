using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NhomChiPhiCommand : NS_NhomChiPhiCommandSet,IRequest<MethodResult<UpdateNS_NhomChiPhiCommandResponse>>
    {
       
    }

    public class UpdateNS_NhomChiPhiCommandResponse : NS_NhomChiPhiCommandResponseDTO
    {
    }
}
