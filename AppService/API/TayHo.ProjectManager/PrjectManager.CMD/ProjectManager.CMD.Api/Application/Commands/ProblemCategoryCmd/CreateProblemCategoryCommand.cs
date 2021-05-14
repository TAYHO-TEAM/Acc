using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateProblemCategoryCommand :ProblemCategoryCommandSet, IRequest<MethodResult<CreateProblemCategoryCommandResponse>>
    {
        
    }

    public class CreateProblemCategoryCommandResponse : ProblemCategoryCommandResponseDTO { }
}