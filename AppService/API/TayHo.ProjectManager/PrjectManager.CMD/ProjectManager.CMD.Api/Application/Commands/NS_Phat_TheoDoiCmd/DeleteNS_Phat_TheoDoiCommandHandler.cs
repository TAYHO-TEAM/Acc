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
    public class DeleteNS_Phat_TheoDoiCommandHandler : NS_Phat_TheoDoiCommandHandler, IRequestHandler<DeleteNS_Phat_TheoDoiCommand, MethodResult<DeleteNS_Phat_TheoDoiCommandResponse>>
    {
        public DeleteNS_Phat_TheoDoiCommandHandler(IMapper mapper, INS_Phat_TheoDoiRepository NS_Phat_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_Phat_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_Phat_TheoDoi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_Phat_TheoDoiCommandResponse>> Handle(DeleteNS_Phat_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_Phat_TheoDoiCommandResponse>();
            var existingNS_Phat_TheoDoi = await _NS_Phat_TheoDoiRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Phat_TheoDoi == null || !existingNS_Phat_TheoDoi.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_Phat_TheoDoi)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_Phat_TheoDoiRepository.UpdateRange(existingNS_Phat_TheoDoi);
            await _NS_Phat_TheoDoiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_Phat_TheoDoiResponseDTOs = _mapper.Map<List<NS_Phat_TheoDoiCommandResponseDTO>>(existingNS_Phat_TheoDoi);
            methodResult.Result = new DeleteNS_Phat_TheoDoiCommandResponse(NS_Phat_TheoDoiResponseDTOs);
            return methodResult;
        }
    }
}