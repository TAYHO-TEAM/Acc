using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateContractorInfoCommand : ContractorInfoCommandSet,IRequest<MethodResult<UpdateContractorInfoCommandResponse>>
    {
       
    }

    public class UpdateContractorInfoCommandResponse : ContractorInfoCommandResponseDTO
    {
    }
}