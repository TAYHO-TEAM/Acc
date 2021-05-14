using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_GiaiDoanCommandHandler : NS_GiaiDoanCommandHandler, IRequestHandler<DeleteNS_GiaiDoanCommand, MethodResult<DeleteNS_GiaiDoanCommandResponse>>
    {
        public DeleteNS_GiaiDoanCommandHandler(IMapper mapper, INS_GiaiDoanRepository NS_GiaiDoanRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_GiaiDoanRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_GiaiDoan.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_GiaiDoanCommandResponse>> Handle(DeleteNS_GiaiDoanCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_GiaiDoanCommandResponse>();
            var existingNS_GiaiDoan = await _NS_GiaiDoanRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_GiaiDoan == null || !existingNS_GiaiDoan.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_GiaiDoan)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user, 0);
            }
            _NS_GiaiDoanRepository.UpdateRange(existingNS_GiaiDoan);
            await _NS_GiaiDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_GiaiDoanResponseDTOs = _mapper.Map<List<NS_GiaiDoanCommandResponseDTO>>(existingNS_GiaiDoan);
            methodResult.Result = new DeleteNS_GiaiDoanCommandResponse(NS_GiaiDoanResponseDTOs);
            return methodResult;
        }
    }
}