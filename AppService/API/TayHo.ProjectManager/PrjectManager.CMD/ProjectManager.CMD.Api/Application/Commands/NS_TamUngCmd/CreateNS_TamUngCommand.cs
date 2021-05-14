using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_TamUngCommand :NS_TamUngCommandSet, IRequest<MethodResult<CreateNS_TamUngCommandResponse>>
    {
        
    }

    public class CreateNS_TamUngCommandResponse : NS_TamUngCommandResponseDTO { }
}