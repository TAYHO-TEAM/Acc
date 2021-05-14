using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NghiemThuCommand : IRequest<MethodResult<DeleteNS_NghiemThuCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteNS_NghiemThuCommandResponse
    {
        public DeleteNS_NghiemThuCommandResponse(List<NS_NghiemThuCommandResponseDTO> NS_NghiemThu)
        {
            _NS_NghiemThu = NS_NghiemThu;
        }

        public List<NS_NghiemThuCommandResponseDTO> _NS_NghiemThu { get; }
    }
}
