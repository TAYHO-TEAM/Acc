using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateFunctionsCommandHandler : FunctionsCommandHandler, IRequestHandler<CreateFunctionsCommand, MethodResult<CreateFunctionsCommandResponse>>
    {
        public CreateFunctionsCommandHandler(IMapper mapper, IFunctionsRepository FunctionsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, FunctionsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Functions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateFunctionsCommandResponse>> Handle(CreateFunctionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateFunctionsCommandResponse>();
            var newFunctions = new Functions(request.ActionId,
                                                request.ParentId,
                                                request.Title,
                                                request.Descriptions,
                                                request.Icon,
                                                request.Url,
                                                request.CategoryId,
                                                request.Level);
            newFunctions.SetCreate(_user);
            newFunctions.Status = request.Status.HasValue ? request.Status : newFunctions.Status;
            newFunctions.IsActive = request.IsActive.HasValue ? request.IsActive : newFunctions.IsActive;
            newFunctions.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newFunctions.IsVisible;
            await _FunctionsRepository.AddAsync(newFunctions).ConfigureAwait(false);
            await _FunctionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateFunctionsCommandResponse>(newFunctions);
            return methodResult;
        }
    }
}