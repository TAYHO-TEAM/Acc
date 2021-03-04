using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateListCustomCellContentCommandHandler : CustomCellContentCommandHandler, IRequestHandler<CreateCustomCellContentCommands, MethodResult<CreateCustomCellContentCommandResponses>>
    {
        public CreateListCustomCellContentCommandHandler(IMapper mapper, ICustomCellContentRepository CustomCellContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomCellContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new ListCustomCellContent
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomCellContentCommandResponses>> Handle(CreateCustomCellContentCommands request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomCellContentCommandResponses>();
            List<CustomCellContent> newCustomCellContents = new List<CustomCellContent>();
            foreach (var item in request.createCustomCellContentCommands)
            {
                var newCustomCellContent = new CustomCellContent(item.CustomFormContentId,
                                                                item.CustomFormBodyId,
                                                                item.CustomColumId,
                                                                item.Contents,
                                                                item.NoRown);
                newCustomCellContent.SetCreate(_user);
                newCustomCellContent.Status = item.Status.HasValue ? item.Status : 0;
                newCustomCellContent.IsActive = item.IsActive.HasValue ? item.IsActive : true;
                newCustomCellContent.IsVisible = item.IsVisible.HasValue ? item.IsVisible : true;
                newCustomCellContents.Add(newCustomCellContent);
            }
           
            await _customCellContentRepository.AddRangeAsync(newCustomCellContents).ConfigureAwait(false);
            await _customCellContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CreateCustomCellContentResponseDTOs = _mapper.Map<List<CustomCellContentCommandResponseDTO>>(newCustomCellContents);
            methodResult.Result = new CreateCustomCellContentCommandResponses(CreateCustomCellContentResponseDTOs);
            return methodResult;
        }
    }
}