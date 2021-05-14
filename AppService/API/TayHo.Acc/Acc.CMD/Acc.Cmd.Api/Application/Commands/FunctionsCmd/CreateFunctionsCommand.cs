using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateFunctionsCommand : FunctionsCommandSet, IRequest<MethodResult<CreateFunctionsCommandResponse>>
    {
       
    }

    public class CreateFunctionsCommandResponse : FunctionsCommandResponseDTO { }
}