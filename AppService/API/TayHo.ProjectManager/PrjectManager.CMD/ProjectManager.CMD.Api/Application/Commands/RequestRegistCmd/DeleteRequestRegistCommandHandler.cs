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
    public class DeleteRequestRegistCommandHandler : RequestRegistCommandHandler, IRequestHandler<DeleteRequestRegistCommand, MethodResult<DeleteRequestRegistCommandResponse>>
    {
        public DeleteRequestRegistCommandHandler(IMapper mapper, IRequestRegistRepository RequestRegistRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestRegistRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing RequestRegist.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteRequestRegistCommandResponse>> Handle(DeleteRequestRegistCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteRequestRegistCommandResponse>();
            var existingRequestRegists = await _requestRegistRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingRequestRegists == null || !existingRequestRegists.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingRequestRegist in existingRequestRegists)
            {
                existingRequestRegist.UpdateDate = now;
                existingRequestRegist.UpdateDateUTC = utc;
                existingRequestRegist.IsDelete = true;
                existingRequestRegist.ModifyBy = 0;
                existingRequestRegist.SetUpdate(_user,0);
                
            }
            _requestRegistRepository.UpdateRange(existingRequestRegists);

            await _requestRegistRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var RequestRegistResponseDTOs = _mapper.Map<List<RequestRegistCommandResponseDTO>>(existingRequestRegists);
            methodResult.Result = new DeleteRequestRegistCommandResponse(RequestRegistResponseDTOs);
            return methodResult;
        }
    }
}