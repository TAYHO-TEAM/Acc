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
    public class DeleteNS_HangMucCommandHandler : NS_HangMucCommandHandler, IRequestHandler<DeleteNS_HangMucCommand, MethodResult<DeleteNS_HangMucCommandResponse>>
    {
        public DeleteNS_HangMucCommandHandler(IMapper mapper, INS_HangMucRepository NS_HangMucRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HangMucRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_HangMuc.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_HangMucCommandResponse>> Handle(DeleteNS_HangMucCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_HangMucCommandResponse>();
            var existingNS_HangMuc = await _NS_HangMucRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_HangMuc == null || !existingNS_HangMuc.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_HangMuc)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_HangMucRepository.UpdateRange(existingNS_HangMuc);
            await _NS_HangMucRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_HangMucResponseDTOs = _mapper.Map<List<NS_HangMucCommandResponseDTO>>(existingNS_HangMuc);
            methodResult.Result = new DeleteNS_HangMucCommandResponse(NS_HangMucResponseDTOs);
            return methodResult;
        }
    }
}