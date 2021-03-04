using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomColumCommandHandler : CustomColumCommandHandler, IRequestHandler<CreateCustomColumCommand, MethodResult<CreateCustomColumCommandResponse>>
    {
        public CreateCustomColumCommandHandler(IMapper mapper, ICustomColumRepository CustomColumRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomColumRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomColum
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomColumCommandResponse>> Handle(CreateCustomColumCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomColumCommandResponse>();
            var newCustomColum = new CustomColum(request.CustomTableId,
                                                    request.ColIndex,
                                                    request.Header,
                                                    request.TypeParam,
                                                    request.Style,
                                                    request.SourceValue,
                                                    request.SourceLink);
            newCustomColum.SetCreate(_user);
            newCustomColum.Status = request.Status.HasValue ? request.Status : newCustomColum.Status;
            newCustomColum.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomColum.IsActive;
            newCustomColum.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newCustomColum.IsVisible;
            await _customColumRepository.AddAsync(newCustomColum).ConfigureAwait(false);
            await _customColumRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomColumCommandResponse>(newCustomColum);
            return methodResult;
        }
    }
}