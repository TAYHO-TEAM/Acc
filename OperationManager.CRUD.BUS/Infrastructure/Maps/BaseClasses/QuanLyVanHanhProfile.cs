using AutoMapper;
using DevExtreme.AspNet.Data;
using Services.Common.DevExpress;

namespace OperationManager.CRUD.BLL.Infrastructure.Maps.BaseClasses
{
    public class QuanLyVanHanhProfile : Profile
    {
        public QuanLyVanHanhProfile()
        {
            CreateMap<DataSourceLoadOptionsBase, DataSourceLoadOptions>();
        }
    }
}
