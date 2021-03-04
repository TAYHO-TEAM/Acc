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
    public class DeleteNotifyTemplateCommandHandler : NotifyTemplateCommandHandler, IRequestHandler<DeleteNotifyTemplateCommand, MethodResult<DeleteNotifyTemplateCommandResponse>>
    {
        public DeleteNotifyTemplateCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, INotifyTemplateRepository notifyTemplateRepository) : base(mapper, httpContextAccessor, notifyTemplateRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NotifyTemplate.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNotifyTemplateCommandResponse>> Handle(DeleteNotifyTemplateCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNotifyTemplateCommandResponse>();
            var existingNotifyTemplates = await _notifyTemplateRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNotifyTemplates == null || !existingNotifyTemplates.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingNotifyTemplate in existingNotifyTemplates)
            {
                existingNotifyTemplate.UpdateDate = now;
                existingNotifyTemplate.UpdateDateUTC = utc;
                existingNotifyTemplate.IsDelete = true;
                existingNotifyTemplate.SetUpdate(_user, null);
            }
            _notifyTemplateRepository.UpdateRange(existingNotifyTemplates);
            await _notifyTemplateRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NotifyTemplateResponseDTOs = _mapper.Map<List<NotifyTemplateCommandResponseDTO>>(existingNotifyTemplates);
            methodResult.Result = new DeleteNotifyTemplateCommandResponse(NotifyTemplateResponseDTOs);
            return methodResult;
        }
    }
}
