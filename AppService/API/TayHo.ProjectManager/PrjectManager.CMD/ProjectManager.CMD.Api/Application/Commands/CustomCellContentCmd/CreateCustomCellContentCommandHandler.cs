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
    public class CreateCustomCellContentCommandHandler : CustomCellContentCommandHandler, IRequestHandler<CreateCustomCellContentCommand, MethodResult<CreateCustomCellContentCommandResponse>>
    {
        public CreateCustomCellContentCommandHandler(IMapper mapper, ICustomCellContentRepository CustomCellContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomCellContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomCellContent
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomCellContentCommandResponse>> Handle(CreateCustomCellContentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomCellContentCommandResponse>();
            var newCustomCellContent = new CustomCellContent(request.CustomFormContentId,
                                                                request.CustomFormBodyId,
                                                                request.CustomColumId,
                                                                request.Contents,
                                                                request.NoRown);
            newCustomCellContent.SetCreate(_user);
            newCustomCellContent.Status = request.Status.HasValue ? request.Status : newCustomCellContent.Status;
            newCustomCellContent.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomCellContent.IsActive;
            newCustomCellContent.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newCustomCellContent.IsVisible;
            await _customCellContentRepository.AddAsync(newCustomCellContent).ConfigureAwait(false);
            await _customCellContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomCellContentCommandResponse>(newCustomCellContent);
            return methodResult;
        }
    }
}