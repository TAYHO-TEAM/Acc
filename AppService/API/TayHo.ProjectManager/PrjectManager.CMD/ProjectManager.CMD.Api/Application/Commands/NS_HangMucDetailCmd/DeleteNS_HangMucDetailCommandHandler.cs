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
    public class DeleteNS_HangMucDetailCommandHandler : NS_HangMucDetailCommandHandler, IRequestHandler<DeleteNS_HangMucDetailCommand, MethodResult<DeleteNS_HangMucDetailCommandResponse>>
    {
        public DeleteNS_HangMucDetailCommandHandler(IMapper mapper, INS_HangMucDetailRepository NS_HangMucDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HangMucDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_HangMucDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_HangMucDetailCommandResponse>> Handle(DeleteNS_HangMucDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_HangMucDetailCommandResponse>();
            var existingNS_HangMucDetail = await _NS_HangMucDetailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_HangMucDetail == null || !existingNS_HangMucDetail.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_HangMucDetail)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_HangMucDetailRepository.UpdateRange(existingNS_HangMucDetail);
            await _NS_HangMucDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_HangMucDetailResponseDTOs = _mapper.Map<List<NS_HangMucDetailCommandResponseDTO>>(existingNS_HangMucDetail);
            methodResult.Result = new DeleteNS_HangMucDetailCommandResponse(NS_HangMucDetailResponseDTOs);
            return methodResult;
        }
    }
}