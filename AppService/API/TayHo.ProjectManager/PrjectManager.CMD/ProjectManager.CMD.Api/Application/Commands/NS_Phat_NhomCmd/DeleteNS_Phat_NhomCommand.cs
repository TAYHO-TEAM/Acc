using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_Phat_NhomCommand : IRequest<MethodResult<DeleteNS_Phat_NhomCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_Phat_NhomCommandResponse
    {
        public DeleteNS_Phat_NhomCommandResponse(List<NS_Phat_NhomCommandResponseDTO> NS_Phat_Nhom)
        {
            _NS_Phat_Nhom = NS_Phat_Nhom;
        }

        public List<NS_Phat_NhomCommandResponseDTO> _NS_Phat_Nhom { get; }
    }
}
