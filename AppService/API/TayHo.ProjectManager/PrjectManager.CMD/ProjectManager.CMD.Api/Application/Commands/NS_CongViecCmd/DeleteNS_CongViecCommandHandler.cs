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
    public class DeleteNS_CongViecCommandHandler : NS_CongViecCommandHandler, IRequestHandler<DeleteNS_CongViecCommand, MethodResult<DeleteNS_CongViecCommandResponse>>
    {
        public DeleteNS_CongViecCommandHandler(IMapper mapper, INS_CongViecRepository NS_CongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_CongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_CongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_CongViecCommandResponse>> Handle(DeleteNS_CongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_CongViecCommandResponse>();
            var existingNS_CongViec = await _NS_CongViecRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_CongViec == null || !existingNS_CongViec.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_CongViec)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_CongViecRepository.UpdateRange(existingNS_CongViec);
            await _NS_CongViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_CongViecResponseDTOs = _mapper.Map<List<NS_CongViecCommandResponseDTO>>(existingNS_CongViec);
            methodResult.Result = new DeleteNS_CongViecCommandResponse(NS_CongViecResponseDTOs);
            return methodResult;
        }
    }
}