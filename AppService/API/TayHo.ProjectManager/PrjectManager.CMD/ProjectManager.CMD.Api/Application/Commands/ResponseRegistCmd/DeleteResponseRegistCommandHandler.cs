using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteResponseRegistCommandHandler : ResponseRegistCommandHandler, IRequestHandler<DeleteResponseRegistCommand, MethodResult<DeleteResponseRegistCommandResponse>>
    {
        public DeleteResponseRegistCommandHandler(IMapper mapper, IResponseRegistRepository ResponseRegistRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ResponseRegistRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing ResponseRegist.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteResponseRegistCommandResponse>> Handle(DeleteResponseRegistCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteResponseRegistCommandResponse>();
            var existingResponseRegists = await _ResponseRegistRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingResponseRegists == null || !existingResponseRegists.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingResponseRegist in existingResponseRegists)
            {
                existingResponseRegist.UpdateDate = now;
                existingResponseRegist.UpdateDateUTC = utc;
                existingResponseRegist.IsDelete = true;
                existingResponseRegist.ModifyBy = 0;
                existingResponseRegist.SetUpdate(_user,0);
                
            }
            _ResponseRegistRepository.UpdateRange(existingResponseRegists);

            await _ResponseRegistRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ResponseRegistResponseDTOs = _mapper.Map<List<ResponseRegistCommandResponseDTO>>(existingResponseRegists);
            methodResult.Result = new DeleteResponseRegistCommandResponse(ResponseRegistResponseDTOs);
            return methodResult;
        }
    }
}