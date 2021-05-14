using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateCategorysCommand : CategorysCommandSet, IRequest<MethodResult<CreateCategorysCommandResponse>>
    {
       
    }

    public class CreateCategorysCommandResponse : CategorysCommandResponseDTO { }
}