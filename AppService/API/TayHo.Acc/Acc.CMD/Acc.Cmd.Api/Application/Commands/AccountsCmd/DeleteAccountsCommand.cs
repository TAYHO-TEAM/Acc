using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteAccountsCommand : IRequest<MethodResult<DeleteAccountsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteAccountsCommandResponse
    {
        public DeleteAccountsCommandResponse(List<AccountsCommandResponseDTO> Accounts)
        {
            _Accounts = Accounts;
        }

        public List<AccountsCommandResponseDTO> _Accounts { get; }
    }
}