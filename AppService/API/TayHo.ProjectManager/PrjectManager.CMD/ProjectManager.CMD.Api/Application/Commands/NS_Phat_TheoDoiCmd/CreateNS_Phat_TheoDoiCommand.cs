using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_Phat_TheoDoiCommand :NS_Phat_TheoDoiCommandSet, IRequest<MethodResult<CreateNS_Phat_TheoDoiCommandResponse>>
    {
        
    }

    public class CreateNS_Phat_TheoDoiCommandResponse : NS_Phat_TheoDoiCommandResponseDTO { }
}