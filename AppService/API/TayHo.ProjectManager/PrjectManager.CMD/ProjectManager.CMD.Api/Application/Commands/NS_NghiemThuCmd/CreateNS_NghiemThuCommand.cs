using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNS_NghiemThuCommand : NS_NghiemThuCommandSet, IRequest<MethodResult<CreateNS_NghiemThuCommandResponse>>
    {
       
    }

    public class CreateNS_NghiemThuCommandResponse : NS_NghiemThuCommandResponseDTO { }
}
