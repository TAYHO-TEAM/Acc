using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateUserInfoCommandHandler : UserInfoCommandHandler, IRequestHandler<CreateUserInfoCommand, MethodResult<CreateUserInfoCommandResponse>>
    {
        public CreateUserInfoCommandHandler(IMapper mapper, IUserInfoRepository UserInfoRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, UserInfoRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new UserInfo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateUserInfoCommandResponse>> Handle(CreateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateUserInfoCommandResponse>();
            var newUserInfo = new UserInfo(request.FirstName,request.LastName,request.Sex,request.DateOfBirth,request.Country,request.City,request.District,request.Address,request.Phone,request.Email);
            newUserInfo.SetCreate(_user);
            newUserInfo.Status = request.Status.HasValue ? request.Status : newUserInfo.Status;
            newUserInfo.IsActive = request.IsActive.HasValue ? request.IsActive : newUserInfo.IsActive;
            newUserInfo.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newUserInfo.IsVisible;
            await _UserInfoRepository.AddAsync(newUserInfo).ConfigureAwait(false);
            await _UserInfoRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateUserInfoCommandResponse>(newUserInfo);
            return methodResult;
        }
    }
}