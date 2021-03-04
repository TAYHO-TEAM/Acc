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
    public class DeleteNS_DuChiCommandHandler : NS_DuChiCommandHandler, IRequestHandler<DeleteNS_DuChiCommand, MethodResult<DeleteNS_DuChiCommandResponse>>
    {
        public DeleteNS_DuChiCommandHandler(IMapper mapper, INS_DuChiRepository NS_DuChiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_DuChiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_DuChi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_DuChiCommandResponse>> Handle(DeleteNS_DuChiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_DuChiCommandResponse>();
            var existingNS_DuChi = await _NS_DuChiRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_DuChi == null || !existingNS_DuChi.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_DuChi)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_DuChiRepository.UpdateRange(existingNS_DuChi);
            await _NS_DuChiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_DuChiResponseDTOs = _mapper.Map<List<NS_DuChiCommandResponseDTO>>(existingNS_DuChi);
            methodResult.Result = new DeleteNS_DuChiCommandResponse(NS_DuChiResponseDTOs);
            return methodResult;
        }
    }
}