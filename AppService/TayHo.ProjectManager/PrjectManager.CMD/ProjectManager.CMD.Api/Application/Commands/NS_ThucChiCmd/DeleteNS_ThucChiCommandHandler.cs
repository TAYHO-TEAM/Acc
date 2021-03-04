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
    public class DeleteNS_ThucChiCommandHandler : NS_ThucChiCommandHandler, IRequestHandler<DeleteNS_ThucChiCommand, MethodResult<DeleteNS_ThucChiCommandResponse>>
    {
        public DeleteNS_ThucChiCommandHandler(IMapper mapper, INS_ThucChiRepository NS_ThucChiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_ThucChiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_ThucChi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_ThucChiCommandResponse>> Handle(DeleteNS_ThucChiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_ThucChiCommandResponse>();
            var existingNS_ThucChi = await _NS_ThucChiRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_ThucChi == null || !existingNS_ThucChi.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_ThucChi)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_ThucChiRepository.UpdateRange(existingNS_ThucChi);
            await _NS_ThucChiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_ThucChiResponseDTOs = _mapper.Map<List<NS_ThucChiCommandResponseDTO>>(existingNS_ThucChi);
            methodResult.Result = new DeleteNS_ThucChiCommandResponse(NS_ThucChiResponseDTOs);
            return methodResult;
        }
    }
}