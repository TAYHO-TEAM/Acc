using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class ContractorInfoCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IContractorInfoRepository _ContractorInfoRepository;

        public ContractorInfoCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IContractorInfoRepository ContractorInfoRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _ContractorInfoRepository = ContractorInfoRepository;
        }
    }
}