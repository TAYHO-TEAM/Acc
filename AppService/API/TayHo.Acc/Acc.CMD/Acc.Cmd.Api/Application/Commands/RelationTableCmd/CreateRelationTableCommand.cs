using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateRelationTableCommand : RelationTableCommandSet, IRequest<MethodResult<CreateRelationTableCommandResponse>>
    {
       
    }

    public class CreateRelationTableCommandResponse : RelationTableCommandResponseDTO { }
}