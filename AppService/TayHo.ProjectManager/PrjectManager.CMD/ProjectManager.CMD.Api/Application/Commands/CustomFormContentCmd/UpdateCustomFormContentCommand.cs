using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomFormContentCommand : CustomFormContentCommandSet,IRequest<MethodResult<UpdateCustomFormContentCommandResponse>>
    {
       
    }

    public class UpdateCustomFormContentCommandResponse : CustomFormContentCommandResponseDTO
    {
    }
}