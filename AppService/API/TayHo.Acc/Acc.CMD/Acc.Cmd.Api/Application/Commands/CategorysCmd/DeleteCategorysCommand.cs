using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteCategorysCommand : IRequest<MethodResult<DeleteCategorysCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCategorysCommandResponse
    {
        public DeleteCategorysCommandResponse(List<CategorysCommandResponseDTO> Categorys)
        {
            _Categorys = Categorys;
        }

        public List<CategorysCommandResponseDTO> _Categorys { get; }
    }
}