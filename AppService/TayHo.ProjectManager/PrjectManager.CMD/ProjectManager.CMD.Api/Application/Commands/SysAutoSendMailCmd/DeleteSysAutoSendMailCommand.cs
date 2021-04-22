using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteSysAutoSendMailCommand : IRequest<MethodResult<DeleteSysAutoSendMailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteSysAutoSendMailCommandResponse
    {
        public DeleteSysAutoSendMailCommandResponse(List<SysAutoSendMailCommandResponseDTO> SysAutoSendMail)
        {
            _SysAutoSendMail = SysAutoSendMail;
        }

        public List<SysAutoSendMailCommandResponseDTO> _SysAutoSendMail { get; }
    }
}
