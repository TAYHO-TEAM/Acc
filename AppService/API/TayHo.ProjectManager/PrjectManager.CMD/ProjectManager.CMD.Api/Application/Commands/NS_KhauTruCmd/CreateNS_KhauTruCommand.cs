using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_KhauTruCommand :NS_KhauTruCommandSet, IRequest<MethodResult<CreateNS_KhauTruCommandResponse>>
    {
        
    }

    public class CreateNS_KhauTruCommandResponse : NS_KhauTruCommandResponseDTO { }
}