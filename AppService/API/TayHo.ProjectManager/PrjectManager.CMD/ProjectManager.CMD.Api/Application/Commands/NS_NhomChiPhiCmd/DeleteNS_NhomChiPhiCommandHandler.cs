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
    public class DeleteNS_NhomChiPhiCommandHandler : NS_NhomChiPhiCommandHandler, IRequestHandler<DeleteNS_NhomChiPhiCommand, MethodResult<DeleteNS_NhomChiPhiCommandResponse>>
    {
        public DeleteNS_NhomChiPhiCommandHandler(IMapper mapper, INS_NhomChiPhiRepository NS_NhomChiPhiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomChiPhiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_NhomChiPhi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_NhomChiPhiCommandResponse>> Handle(DeleteNS_NhomChiPhiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_NhomChiPhiCommandResponse>();
            var existingNS_NhomChiPhi = await _NS_NhomChiPhiRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NhomChiPhi == null || !existingNS_NhomChiPhi.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_NhomChiPhi)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_NhomChiPhiRepository.UpdateRange(existingNS_NhomChiPhi);
            await _NS_NhomChiPhiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_NhomChiPhiResponseDTOs = _mapper.Map<List<NS_NhomChiPhiCommandResponseDTO>>(existingNS_NhomChiPhi);
            methodResult.Result = new DeleteNS_NhomChiPhiCommandResponse(NS_NhomChiPhiResponseDTOs);
            return methodResult;
        }
    }
}