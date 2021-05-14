using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateUserInfoCommand : UserInfoCommandSet, IRequest<MethodResult<CreateUserInfoCommandResponse>>
    {

    }

    public class CreateUserInfoCommandResponse : UserInfoCommandResponseDTO { }
}