using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;

using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain.DomainEvents.RequestRegistDomainEvent;
using ProjectManager.CMD.Domain.IRepositories;
using ProjectManager.CMD.Domain.DomainObjects;
using System.Collections.Generic;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;

namespace ProjectManager.CMD.Api.Application.DomainEventHandlers
{
    public class RequestRegistCreatedDomainEventHandler : INotificationHandler<RequestRegistCreatedDomainEvent>
    {
        private readonly IMapper _mapper;
        private readonly IRequestRegistRepository _requestRegistRepository;
        private readonly ILogger<RequestRegistCreatedDomainEvent> _logger;


        public RequestRegistCreatedDomainEventHandler(IMapper mapper, IRequestRegistRepository requestRegistRepository, ILogger<RequestRegistCreatedDomainEvent> logger)
        {
            _mapper = mapper;
            _requestRegistRepository = requestRegistRepository;
            _logger = logger;
        }

        public async Task Handle(RequestRegistCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var newRequestRegist = notification.RequestRegist;
            if (newRequestRegist == null) return;

            var isRequestRegist = await _requestRegistRepository.IsCreatedRequestRegistAsync((int)notification.RequestRegist.DocumentTypeId, (int)notification.RequestRegist.CreateBy, notification.RequestRegist.Id).ConfigureAwait(false);
            if (!isRequestRegist)
            {
                var errorResult = new ErrorResult
                {
                    ErrorCode = nameof(ErrorCodeInsert.IErrN4),
                    ErrorMessage = ProjectManagerExtensions.GetErrorMessage(nameof(ErrorCodeInsert.IErrN4)),
                    ErrorValues = new List<string> { ErrorHelpers.GenerateErrorResult(nameof(newRequestRegist.Id), newRequestRegist.Id) }
                };
                throw new DomainEventHandlerException(errorResult);
            }
        }
    }

}
