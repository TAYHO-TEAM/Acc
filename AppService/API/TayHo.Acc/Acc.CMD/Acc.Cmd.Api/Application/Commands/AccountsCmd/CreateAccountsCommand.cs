using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateAccountsCommand : AccountsCommandSet, IRequest<MethodResult<CreateAccountsCommandResponse>>
    {
       
    }

    public class CreateAccountsCommandResponse : AccountsCommandResponseDTO { }
}