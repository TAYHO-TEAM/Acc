using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NhomChiPhiCommand : NS_NhomChiPhiCommandSet, IRequest<MethodResult<CreateNS_NhomChiPhiCommandResponse>>
    {
       
    }

    public class CreateNS_NhomChiPhiCommandResponse : NS_NhomChiPhiCommandResponseDTO { }
}
