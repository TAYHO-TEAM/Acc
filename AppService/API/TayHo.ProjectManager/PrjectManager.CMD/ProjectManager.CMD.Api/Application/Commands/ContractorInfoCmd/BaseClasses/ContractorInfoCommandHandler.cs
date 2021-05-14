using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.Common;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ContractorInfoCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IContractorInfoRepository _ContractorInfoRepository;
        protected const int _actionId = 0;
        protected const string _tableName = QuanLyDuAnConstants.ContractorInfo_TABLENAME;

        public ContractorInfoCommandHandler(IMapper mapper, IContractorInfoRepository ContractorInfoRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _ContractorInfoRepository = ContractorInfoRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}