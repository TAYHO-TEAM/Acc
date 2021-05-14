using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateContractorInfoCommand : ContractorInfoCommandSet, IRequest<MethodResult<CreateContractorInfoCommandResponse>>
    {
       
    }

    public class CreateContractorInfoCommandResponse : ContractorInfoCommandResponseDTO { }
}