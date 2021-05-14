using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreatePermistionsCommandHandler : PermistionsCommandHandler, IRequestHandler<CreatePermistionsCommand, MethodResult<CreatePermistionsCommandResponse>>
    {
        public CreatePermistionsCommandHandler(IMapper mapper, IPermistionsRepository PermistionsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, PermistionsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Permistions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePermistionsCommandResponse>> Handle(CreatePermistionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePermistionsCommandResponse>();
            var newPermistions = new Permistions(request.Type,
                                                request.Title,
                                                request.Descriptions);
            newPermistions.Status = request.Status.HasValue ? request.Status : newPermistions.Status;
            newPermistions.IsActive = request.IsActive.HasValue ? request.IsActive : newPermistions.IsActive;
            newPermistions.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newPermistions.IsVisible;
            await _PermistionsRepository.AddAsync(newPermistions).ConfigureAwait(false);
            await _PermistionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePermistionsCommandResponse>(newPermistions);
            return methodResult;
        }
    }
}