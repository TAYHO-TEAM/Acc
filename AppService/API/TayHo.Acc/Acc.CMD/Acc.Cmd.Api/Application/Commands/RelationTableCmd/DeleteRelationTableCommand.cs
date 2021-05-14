using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteRelationTableCommand : IRequest<MethodResult<DeleteRelationTableCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteRelationTableCommandResponse
    {
        public DeleteRelationTableCommandResponse(List<RelationTableCommandResponseDTO> RelationTable)
        {
            _RelationTable = RelationTable;
        }

        public List<RelationTableCommandResponseDTO> _RelationTable { get; }
    }
}