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
    public class UpdatePermistionsCommandHandler : PermistionsCommandHandler,IRequestHandler<UpdatePermistionsCommand, MethodResult<UpdatePermistionsCommandResponse>>
    {
        public UpdatePermistionsCommandHandler(IMapper mapper, IPermistionsRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Permistions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePermistionsCommandResponse>> Handle(UpdatePermistionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePermistionsCommandResponse>();
            var existingPermistions = await _PermistionsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPermistions == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPermistions.IsActive = request.IsActive.HasValue ? request.IsActive : existingPermistions.IsActive;
            existingPermistions.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingPermistions.IsVisible;
            existingPermistions.Status = request.Status.HasValue ? request.Status : existingPermistions.Status;
            existingPermistions.SetType(request.Type);
            existingPermistions.SetTitle(request.Title);
            existingPermistions.SetDescriptions(request.Descriptions);

            existingPermistions.SetUpdate(_user,null);
            _PermistionsRepository.Update(existingPermistions);
            await _PermistionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePermistionsCommandResponse>(existingPermistions);
            return methodResult;
        }
    }
}