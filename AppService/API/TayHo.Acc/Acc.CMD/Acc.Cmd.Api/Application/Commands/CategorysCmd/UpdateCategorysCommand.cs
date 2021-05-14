using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateCategorysCommand : CategorysCommandSet,IRequest<MethodResult<UpdateCategorysCommandResponse>>
    {
       
    }

    public class UpdateCategorysCommandResponse : CategorysCommandResponseDTO
    {
    }
}