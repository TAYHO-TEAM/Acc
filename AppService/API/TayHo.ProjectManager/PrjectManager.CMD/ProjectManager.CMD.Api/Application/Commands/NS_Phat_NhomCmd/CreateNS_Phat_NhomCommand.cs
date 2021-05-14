using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_Phat_NhomCommand : NS_Phat_NhomCommandSet, IRequest<MethodResult<CreateNS_Phat_NhomCommandResponse>>
    {
       
    }

    public class CreateNS_Phat_NhomCommandResponse : NS_Phat_NhomCommandResponseDTO { }
}
