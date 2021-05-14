using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_TamUng_TheoDoiCommand :NS_TamUng_TheoDoiCommandSet, IRequest<MethodResult<CreateNS_TamUng_TheoDoiCommandResponse>>
    {
        
    }

    public class CreateNS_TamUng_TheoDoiCommandResponse : NS_TamUng_TheoDoiCommandResponseDTO { }
}