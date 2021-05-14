using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_GoiThauCommand :NS_GoiThauCommandSet, IRequest<MethodResult<CreateNS_GoiThauCommandResponse>>
    {
        
    }

    public class CreateNS_GoiThauCommandResponse : NS_GoiThauCommandResponseDTO { }
}