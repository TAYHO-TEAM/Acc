using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateRelationTableCommand : RelationTableCommandSet,IRequest<MethodResult<UpdateRelationTableCommandResponse>>
    {
       
    }

    public class UpdateRelationTableCommandResponse : RelationTableCommandResponseDTO
    {
    }
}