using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupAccountCommand : IRequest<MethodResult<DeleteGroupAccountCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteGroupAccountCommandResponse
    {
        public DeleteGroupAccountCommandResponse(List<GroupAccountCommandResponseDTO> GroupAccount)
        {
            _GroupAccount = GroupAccount;
        }

        public List<GroupAccountCommandResponseDTO> _GroupAccount { get; }
    }
}