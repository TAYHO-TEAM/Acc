using MediatR;
using Services.Common.DomainObjects;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestRegistCommand :RequestRegistCommandSet, IRequest<MethodResult<CreateRequestRegistCommandResponse>>
    {
        
    }

    public class CreateRequestRegistCommandResponse : RequestRegistCommandResponseDTO { }
}