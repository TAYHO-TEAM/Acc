using MediatR;
using Services.Common.DomainObjects;
using System;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupAccountCommand : GroupAccountCommandSet, IRequest<MethodResult<CreateGroupAccountCommandResponse>>
    {
       
    }
    public class CreateGroupAccountsCommand : IRequest<MethodResult<CreateGroupAccountsCommandResponse>>
    {
        //public CreateGroupAccountsCommand (List<CreateGroupAccountCommand> GroupAccountCommands)
        //{
        //    _GroupAccountCommands = GroupAccountCommands;
        //}

        public List<CreateGroupAccountCommand> _GroupAccountCommands { get; set; } = new List<CreateGroupAccountCommand>();
    }

    public class CreateGroupAccountCommandResponse : GroupAccountCommandResponseDTO { }
    public class CreateGroupAccountsCommandResponse
    {
        public CreateGroupAccountsCommandResponse(List<GroupAccountCommandResponseDTO> GroupAccount)
        {
            _GroupAccount = GroupAccount;
        }

        public List<GroupAccountCommandResponseDTO> _GroupAccount { get; }
    }
}