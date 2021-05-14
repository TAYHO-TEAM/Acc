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
    public class DeleteNS_LoaiCongViecCommandHandler : NS_LoaiCongViecCommandHandler, IRequestHandler<DeleteNS_LoaiCongViecCommand, MethodResult<DeleteNS_LoaiCongViecCommandResponse>>
    {
        public DeleteNS_LoaiCongViecCommandHandler(IMapper mapper, INS_LoaiCongViecRepository NS_LoaiCongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_LoaiCongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_LoaiCongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_LoaiCongViecCommandResponse>> Handle(DeleteNS_LoaiCongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_LoaiCongViecCommandResponse>();
            var existingNS_LoaiCongViec = await _NS_LoaiCongViecRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_LoaiCongViec == null || !existingNS_LoaiCongViec.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            } 
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_LoaiCongViec)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_LoaiCongViecRepository.UpdateRange(existingNS_LoaiCongViec);
            await _NS_LoaiCongViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_LoaiCongViecResponseDTOs = _mapper.Map<List<NS_LoaiCongViecCommandResponseDTO>>(existingNS_LoaiCongViec);
            methodResult.Result = new DeleteNS_LoaiCongViecCommandResponse(NS_LoaiCongViecResponseDTOs);
            return methodResult;
        }
    }
}