using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateLogEventCommand : LogEventCommandSet, IRequest<MethodResult<CreateLogEventCommandResponse>>
    {
       
    }

    public class CreateLogEventCommandResponse : LogEventCommandResponseDTO { }
}