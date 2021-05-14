using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateUserInfoCommandHandler : UserInfoCommandHandler,IRequestHandler<UpdateUserInfoCommand, MethodResult<UpdateUserInfoCommandResponse>>
    {
        public UpdateUserInfoCommandHandler(IMapper mapper, IUserInfoRepository UserInfoRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, UserInfoRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing UserInfo.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateUserInfoCommandResponse>> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateUserInfoCommandResponse>();
            var existingUserInfo = await _UserInfoRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingUserInfo == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingUserInfo.IsActive = request.IsActive.HasValue ? request.IsActive : existingUserInfo.IsActive;
            existingUserInfo.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingUserInfo.IsVisible;
            existingUserInfo.Status = request.Status.HasValue ? request.Status : existingUserInfo.Status;
            existingUserInfo.SetAddress(request.Address);
            existingUserInfo.SetCity(request.City);
            existingUserInfo.SetCountry(request.Country);
            existingUserInfo.SetDateOfBirth(request.DateOfBirth);
            existingUserInfo.SetDistrict(request.District);
            existingUserInfo.SetEmail(request.Email);
            existingUserInfo.SetFirstName(request.FirstName);
            existingUserInfo.SetLastName(request.LastName);
            existingUserInfo.SetSex(request.Sex);
            existingUserInfo.SetPhone(request.Phone);
            existingUserInfo.SetUpdate(_user,null);
            _UserInfoRepository.Update(existingUserInfo);
            await _UserInfoRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateUserInfoCommandResponse>(existingUserInfo);
            return methodResult;
        }
    }
}