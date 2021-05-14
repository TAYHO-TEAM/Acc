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
    public class DeleteNS_TamUng_TheoDoiCommandHandler : NS_TamUng_TheoDoiCommandHandler, IRequestHandler<DeleteNS_TamUng_TheoDoiCommand, MethodResult<DeleteNS_TamUng_TheoDoiCommandResponse>>
    {
        public DeleteNS_TamUng_TheoDoiCommandHandler(IMapper mapper, INS_TamUng_TheoDoiRepository NS_TamUng_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_TamUng_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_TamUng_TheoDoi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_TamUng_TheoDoiCommandResponse>> Handle(DeleteNS_TamUng_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_TamUng_TheoDoiCommandResponse>();
            var existingNS_TamUng_TheoDoi = await _NS_TamUng_TheoDoiRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_TamUng_TheoDoi == null || !existingNS_TamUng_TheoDoi.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_TamUng_TheoDoi)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_TamUng_TheoDoiRepository.UpdateRange(existingNS_TamUng_TheoDoi);
            await _NS_TamUng_TheoDoiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_TamUng_TheoDoiResponseDTOs = _mapper.Map<List<NS_TamUng_TheoDoiCommandResponseDTO>>(existingNS_TamUng_TheoDoi);
            methodResult.Result = new DeleteNS_TamUng_TheoDoiCommandResponse(NS_TamUng_TheoDoiResponseDTOs);
            return methodResult;
        }
    }
}