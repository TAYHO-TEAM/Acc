using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_KhauTru_TheoDoiCommand :NS_KhauTru_TheoDoiCommandSet, IRequest<MethodResult<CreateNS_KhauTru_TheoDoiCommandResponse>>
    {
        
    }

    public class CreateNS_KhauTru_TheoDoiCommandResponse : NS_KhauTru_TheoDoiCommandResponseDTO { }
}