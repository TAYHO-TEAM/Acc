using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateWorkItemsCommand : WorkItemsCommandSet, IRequest<MethodResult<CreateWorkItemsCommandResponse>>
    {
       
    }

    public class CreateWorkItemsCommandResponse : WorkItemsCommandResponseDTO { }
}