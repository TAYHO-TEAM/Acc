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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_GoiThauCommandHandler : NS_GoiThauCommandHandler, IRequestHandler<DeleteNS_GoiThauCommand, MethodResult<DeleteNS_GoiThauCommandResponse>>
    {
        public DeleteNS_GoiThauCommandHandler(IMapper mapper, INS_GoiThauRepository NS_GoiThauRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_GoiThauRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_GoiThau.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_GoiThauCommandResponse>> Handle(DeleteNS_GoiThauCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_GoiThauCommandResponse>();
            var existingNS_GoiThau = await _NS_GoiThauRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_GoiThau == null || !existingNS_GoiThau.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_GoiThau)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user, 0);
            }
            _NS_GoiThauRepository.UpdateRange(existingNS_GoiThau);
            await _NS_GoiThauRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_GoiThauResponseDTOs = _mapper.Map<List<NS_GoiThauCommandResponseDTO>>(existingNS_GoiThau);
            methodResult.Result = new DeleteNS_GoiThauCommandResponse(NS_GoiThauResponseDTOs);
            return methodResult;
        }
    }
}