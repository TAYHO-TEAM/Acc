using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_TamUng_TheoDoiCommand : NS_TamUng_TheoDoiCommandSet,IRequest<MethodResult<UpdateNS_TamUng_TheoDoiCommandResponse>>
    {
       
    }

    public class UpdateNS_TamUng_TheoDoiCommandResponse : NS_TamUng_TheoDoiCommandResponseDTO
    {
    }
}