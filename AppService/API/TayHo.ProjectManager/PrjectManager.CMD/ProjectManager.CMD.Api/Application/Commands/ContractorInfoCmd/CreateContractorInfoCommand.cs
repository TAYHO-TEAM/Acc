using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateContractorInfoCommand : ContractorInfoCommandSet, IRequest<MethodResult<CreateContractorInfoCommandResponse>>
    {
       
    }

    public class CreateContractorInfoCommandResponse : ContractorInfoCommandResponseDTO { }
}