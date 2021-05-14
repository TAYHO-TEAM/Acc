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
    public class DeleteTemplateMailCommandHandler : TemplateMailCommandHandler, IRequestHandler<DeleteTemplateMailCommand, MethodResult<DeleteTemplateMailCommandResponse>>
    {
        public DeleteTemplateMailCommandHandler(IMapper mapper, ITemplateMailRepository TemplateMailRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, TemplateMailRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing TemplateMail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteTemplateMailCommandResponse>> Handle(DeleteTemplateMailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteTemplateMailCommandResponse>();
            var existingTemplateMails = await _templateMailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingTemplateMails == null || !existingTemplateMails.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingTemplateMail in existingTemplateMails)
            {
                existingTemplateMail.UpdateDate = now;
                existingTemplateMail.UpdateDateUTC = utc;
                existingTemplateMail.IsDelete = true;
                existingTemplateMail.SetUpdate(_user, null);
            }
            _templateMailRepository.UpdateRange(existingTemplateMails);
            await _templateMailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var TemplateMailResponseDTOs = _mapper.Map<List<TemplateMailCommandResponseDTO>>(existingTemplateMails);
            methodResult.Result = new DeleteTemplateMailCommandResponse(TemplateMailResponseDTOs);
            return methodResult;
        }
    }
}
