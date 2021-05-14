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
    public class DeleteNS_TamUngCommandHandler : NS_TamUngCommandHandler, IRequestHandler<DeleteNS_TamUngCommand, MethodResult<DeleteNS_TamUngCommandResponse>>
    {
        public DeleteNS_TamUngCommandHandler(IMapper mapper, INS_TamUngRepository NS_TamUngRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_TamUngRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_TamUng.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_TamUngCommandResponse>> Handle(DeleteNS_TamUngCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_TamUngCommandResponse>();
            var existingNS_TamUng = await _NS_TamUngRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_TamUng == null || !existingNS_TamUng.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_TamUng)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_TamUngRepository.UpdateRange(existingNS_TamUng);
            await _NS_TamUngRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_TamUngResponseDTOs = _mapper.Map<List<NS_TamUngCommandResponseDTO>>(existingNS_TamUng);
            methodResult.Result = new DeleteNS_TamUngCommandResponse(NS_TamUngResponseDTOs);
            return methodResult;
        }
    }
}