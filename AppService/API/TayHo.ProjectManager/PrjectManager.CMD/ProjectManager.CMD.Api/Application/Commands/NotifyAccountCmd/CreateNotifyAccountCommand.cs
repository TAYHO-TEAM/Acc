using MediatR;
using Services.Common.DomainObjects;
using System;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyAccountCommand : NotifyAccountCommandSet, IRequest<MethodResult<CreateNotifyAccountCommandResponse>>
    {
       
    }
    public class CreateNotifyAccountsCommand : NotifyAccountsCommandSet, IRequest<MethodResult<CreateNotifyAccountCommandResponse>>
    {

    }
    public class CreateNotifyAccountCommandResponse
    {
        public CreateNotifyAccountCommandResponse(List<NotifyAccountCommandResponseDTO> NotifyAccount)
        {
            _NotifyAccount = NotifyAccount;
        }

        public List<NotifyAccountCommandResponseDTO> _NotifyAccount { get; }
    }
    //public class CreateNotifyAccountCommandResponse : NotifyAccountCommandResponseDTO { }
}
