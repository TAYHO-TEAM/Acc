using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteUserInfoCommandHandler : UserInfoCommandHandler, IRequestHandler<DeleteUserInfoCommand, MethodResult<DeleteUserInfoCommandResponse>>
    {
        public DeleteUserInfoCommandHandler(IMapper mapper, IUserInfoRepository UserInfoRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, UserInfoRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing UserInfo.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteUserInfoCommandResponse>> Handle(DeleteUserInfoCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteUserInfoCommandResponse>();
            var existingUserInfos = await _UserInfoRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
           
            if (existingUserInfos == null || !existingUserInfos.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingUserInfo in existingUserInfos)
            {
                existingUserInfo.UpdateDate = now;
                existingUserInfo.UpdateDateUTC = utc;
                existingUserInfo.IsDelete = true;
                existingUserInfo.SetUpdate(_user, null);
            }
            _UserInfoRepository.UpdateRange(existingUserInfos);
            await _UserInfoRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var UserInfoResponseDTOs = _mapper.Map<List<UserInfoCommandResponseDTO>>(existingUserInfos);
            methodResult.Result = new DeleteUserInfoCommandResponse(UserInfoResponseDTOs);
            return methodResult;
        }
    }
}