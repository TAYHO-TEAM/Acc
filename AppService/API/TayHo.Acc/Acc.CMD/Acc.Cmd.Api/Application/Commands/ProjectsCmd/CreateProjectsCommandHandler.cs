using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateProjectsCommandHandler : ProjectsCommandHandler, IRequestHandler<CreateProjectsCommand, MethodResult<CreateProjectsCommandResponse>>
    {
        public CreateProjectsCommandHandler(IMapper mapper, IProjectsRepository ProjectsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ProjectsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Projects
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateProjectsCommandResponse>> Handle(CreateProjectsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateProjectsCommandResponse>();
            var newProjects = new Projects(request.Code,
                                            request.BarCode,
                                            request.Title,
                                            request.Descriptions,
                                            request.ParentId,
                                            request.NodeLevel,
                                            request.OldId);
            newProjects.SetCreate(_user);
            newProjects.Status = request.Status.HasValue ? request.Status : newProjects.Status;
            newProjects.IsActive = request.IsActive.HasValue ? request.IsActive : newProjects.IsActive;
            newProjects.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newProjects.IsVisible;
            await _ProjectsRepository.AddAsync(newProjects).ConfigureAwait(false);
            await _ProjectsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateProjectsCommandResponse>(newProjects);
            return methodResult;
        }
    }
}