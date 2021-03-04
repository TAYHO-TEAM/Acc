using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_NghiemThuCommand : NS_NghiemThuCommandSet,IRequest<MethodResult<UpdateNS_NghiemThuCommandResponse>>
    {
       
    }

    public class UpdateNS_NghiemThuCommandResponse : NS_NghiemThuCommandResponseDTO
    {
    }
}
