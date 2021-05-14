using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteProblemCategoryCommand : IRequest<MethodResult<DeleteProblemCategoryCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteProblemCategoryCommandResponse
    {
        public DeleteProblemCategoryCommandResponse(List<ProblemCategoryCommandResponseDTO> ProblemCategory)
        {
            problemCategory = ProblemCategory;
        }

        public List<ProblemCategoryCommandResponseDTO> problemCategory { get; }
    }
}