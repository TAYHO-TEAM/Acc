using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupsCommand : GroupsCommandSet, IRequest<MethodResult<CreateGroupsCommandResponse>>
    {
       
    }

    public class CreateGroupsCommandResponse : GroupsCommandResponseDTO { }
}