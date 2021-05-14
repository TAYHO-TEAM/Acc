using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateAccountsCommand : AccountsCommandSet,IRequest<MethodResult<UpdateAccountsCommandResponse>>
    {
       
    }

    public class UpdateAccountsCommandResponse : AccountsCommandResponseDTO
    {
    }
}