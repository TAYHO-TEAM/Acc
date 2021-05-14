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
    public class DeletePermistionsCommandHandler : PermistionsCommandHandler, IRequestHandler<DeletePermistionsCommand, MethodResult<DeletePermistionsCommandResponse>>
    {
        public DeletePermistionsCommandHandler(IMapper mapper, IPermistionsRepository PermistionsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PermistionsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Permistions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeletePermistionsCommandResponse>> Handle(DeletePermistionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeletePermistionsCommandResponse>();
            var existingPermistionss = await _PermistionsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingPermistionss == null || !existingPermistionss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingPermistions in existingPermistionss)
            {
                existingPermistions.UpdateDate = now;
                existingPermistions.UpdateDateUTC = utc;
                existingPermistions.IsDelete = true;
                existingPermistions.SetUpdate(_user, null);

            }
            _PermistionsRepository.UpdateRange(existingPermistionss);
            await _PermistionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var PermistionsResponseDTOs = _mapper.Map<List<PermistionsCommandResponseDTO>>(existingPermistionss);
            methodResult.Result = new DeletePermistionsCommandResponse(PermistionsResponseDTOs);
            return methodResult;
        }
    }
}