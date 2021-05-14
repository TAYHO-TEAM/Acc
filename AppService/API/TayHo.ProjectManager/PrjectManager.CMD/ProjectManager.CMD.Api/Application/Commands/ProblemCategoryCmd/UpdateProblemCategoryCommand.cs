using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateProblemCategoryCommand : ProblemCategoryCommandSet,IRequest<MethodResult<UpdateProblemCategoryCommandResponse>>
    {
       
    }

    public class UpdateProblemCategoryCommandResponse : ProblemCategoryCommandResponseDTO
    {
    }
}