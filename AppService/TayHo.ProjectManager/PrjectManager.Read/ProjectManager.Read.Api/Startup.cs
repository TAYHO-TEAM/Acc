using ProjectManager.Read.Sql;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.Common.APIs;
using Services.Common.APIs.Infrastructure.Configuration;
using Services.Common.APIs.Infrastructure.DIServiceConfigurations;
using System.Collections.Generic;
using ProjectManager.CMD.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Read.Api
{
    public class Startup : APIStartupBase
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : base(configuration, webHostEnvironment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            #region Register repositories
            services.AddDbContext<QuanLyDuAnContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TayHoConnection")));
            services.AddQuanLyDuAnServices(Configuration);

            #endregion Register repositories

            #region Custom Swagger

            services.AddCustomMvc(Configuration, null, new List<SwaggerDocModel>
            {
                new SwaggerDocModel
                {
                    Name = "v1",
                    OpenApiInfo = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ProjectManager.Read.Api",
                        Description = "ProjectManager.Read.Api"
                    }
                }
            });

            #endregion Custom Swagger
        }
    }
}
