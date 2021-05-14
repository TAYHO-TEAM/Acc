using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_KhauTru_TheoDoiCommand : IRequest<MethodResult<DeleteNS_KhauTru_TheoDoiCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_KhauTru_TheoDoiCommandResponse
    {
        public DeleteNS_KhauTru_TheoDoiCommandResponse(List<NS_KhauTru_TheoDoiCommandResponseDTO> NS_KhauTru_TheoDoi)
        {
            _NS_KhauTru_TheoDoi = NS_KhauTru_TheoDoi;
        }

        public List<NS_KhauTru_TheoDoiCommandResponseDTO> _NS_KhauTru_TheoDoi { get; }
    }
}