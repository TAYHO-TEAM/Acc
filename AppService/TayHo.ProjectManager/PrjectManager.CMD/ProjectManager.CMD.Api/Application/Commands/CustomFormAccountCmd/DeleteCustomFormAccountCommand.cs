using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteCustomFormAccountCommand : IRequest<MethodResult<DeleteCustomFormAccountCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteCustomFormAccountCommandResponse
    {
        public DeleteCustomFormAccountCommandResponse(List<CustomFormAccountCommandResponseDTO> CustomFormAccount)
        {
            _CustomFormAccount = CustomFormAccount;
        }

        public List<CustomFormAccountCommandResponseDTO> _CustomFormAccount { get; }
    }
}
