using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteContractorInfoCommand : IRequest<MethodResult<DeleteContractorInfoCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteContractorInfoCommandResponse
    {
        public DeleteContractorInfoCommandResponse(List<ContractorInfoCommandResponseDTO> ContractorInfo)
        {
            _ContractorInfo = ContractorInfo;
        }

        public List<ContractorInfoCommandResponseDTO> _ContractorInfo { get; }
    }
}