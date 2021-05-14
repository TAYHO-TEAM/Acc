using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_Phat_TheoDoiCommand : IRequest<MethodResult<DeleteNS_Phat_TheoDoiCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_Phat_TheoDoiCommandResponse
    {
        public DeleteNS_Phat_TheoDoiCommandResponse(List<NS_Phat_TheoDoiCommandResponseDTO> NS_Phat_TheoDoi)
        {
            _NS_Phat_TheoDoi = NS_Phat_TheoDoi;
        }

        public List<NS_Phat_TheoDoiCommandResponseDTO> _NS_Phat_TheoDoi { get; }
    }
}