using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_HangMucCommand :NS_HangMucCommandSet, IRequest<MethodResult<CreateNS_HangMucCommandResponse>>
    {
        
    }

    public class CreateNS_HangMucCommandResponse : NS_HangMucCommandResponseDTO { }
}