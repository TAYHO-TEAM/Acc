using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_KhauTru_TheoDoiCommand : NS_KhauTru_TheoDoiCommandSet,IRequest<MethodResult<UpdateNS_KhauTru_TheoDoiCommandResponse>>
    {
       
    }

    public class UpdateNS_KhauTru_TheoDoiCommandResponse : NS_KhauTru_TheoDoiCommandResponseDTO
    {
    }
}