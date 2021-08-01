using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.Common.APIs;
using Services.Common.APIs.Infrastructure.Configuration;
using Services.Common.APIs.Infrastructure.DIServiceConfigurations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.BLL.Extensions;

namespace OperationManager.CRUD.Api
{
    public class Startup : APIStartupBase
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : base(configuration, webHostEnvironment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            #region Custom DbContext
            services.AddDbContext<QuanLyVanHanhContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TayHoOMConnection")));
            services.AddDbContext<QuanLyDuAnContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TayHoPMConnection")));
            services.AddOperationManagerServices(Configuration);
            #endregion Custom DbContext

            #region Custom Swagger
            services.AddCustomMvc(Configuration, null, new List<SwaggerDocModel>
            {
                new SwaggerDocModel
                {
                    Name = "v1",
                    OpenApiInfo = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "OperationManager.CRUD.Api",
                        Description = "OperationManager.CRUD.Api"
                    }
                }
            });
            #endregion Custom Swagger
        }

    }
}
