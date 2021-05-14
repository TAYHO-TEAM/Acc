using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteUserInfoCommand : IRequest<MethodResult<DeleteUserInfoCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteUserInfoCommandResponse
    {
        public DeleteUserInfoCommandResponse(List<UserInfoCommandResponseDTO> userInfos)
        {
            _UserInfos = userInfos;
        }

        public List<UserInfoCommandResponseDTO> _UserInfos { get; }
    }
}