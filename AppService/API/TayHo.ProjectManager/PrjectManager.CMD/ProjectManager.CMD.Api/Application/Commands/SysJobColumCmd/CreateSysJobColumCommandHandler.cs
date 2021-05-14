using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobColumCommandHandler : SysJobColumCommandHandler, IRequestHandler<CreateSysJobColumCommand, MethodResult<CreateSysJobColumCommandResponse>>
    {
        public CreateSysJobColumCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,ISysJobColumRepository sysJobColumRepository) : base(mapper, httpContextAccessor, sysJobColumRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new SysJobColum
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateSysJobColumCommandResponse>> Handle(CreateSysJobColumCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateSysJobColumCommandResponse>();
            var newSysJobColum = new SysJobColum(request.NoCol,request.SysJobTableId,request.Style,request.Formulas,request.Functions);
            newSysJobColum.SetCreate(_user);
            newSysJobColum.Status = request.Status.HasValue ? request.Status : newSysJobColum.Status;
            newSysJobColum.IsActive = request.IsActive.HasValue ? request.IsActive : newSysJobColum.IsActive;
            newSysJobColum.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newSysJobColum.IsVisible;
            await _sysJobColumRepository.AddAsync(newSysJobColum).ConfigureAwait(false);
            await _sysJobColumRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateSysJobColumCommandResponse>(newSysJobColum);
            return methodResult;
        }
    }
}
