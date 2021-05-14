using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_HangMucDetailCommand :NS_HangMucDetailCommandSet, IRequest<MethodResult<CreateNS_HangMucDetailCommandResponse>>
    {
        
    }

    public class CreateNS_HangMucDetailCommandResponse : NS_HangMucDetailCommandResponseDTO { }
}