using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_TamUng_TheoDoiCommand : IRequest<MethodResult<DeleteNS_TamUng_TheoDoiCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_TamUng_TheoDoiCommandResponse
    {
        public DeleteNS_TamUng_TheoDoiCommandResponse(List<NS_TamUng_TheoDoiCommandResponseDTO> NS_TamUng_TheoDoi)
        {
            _NS_TamUng_TheoDoi = NS_TamUng_TheoDoi;
        }

        public List<NS_TamUng_TheoDoiCommandResponseDTO> _NS_TamUng_TheoDoi { get; }
    }
}