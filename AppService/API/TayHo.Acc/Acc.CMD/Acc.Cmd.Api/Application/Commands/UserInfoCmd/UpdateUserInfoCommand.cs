using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateUserInfoCommand : UserInfoCommandSet,IRequest<MethodResult<UpdateUserInfoCommandResponse>>
    {
       
    }

    public class UpdateUserInfoCommandResponse : UserInfoCommandResponseDTO
    {
    }
}