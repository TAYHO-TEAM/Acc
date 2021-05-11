using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjectManager.CMD.Infrastructure;
using Services.Common.APIs;
using Services.Common.APIs.Infrastructure.Configuration;
using Services.Common.APIs.Infrastructure.DIServiceConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperationManagement.Api
{
    public class Startup : APIStartupBase
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) : base(configuration, webHostEnvironment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            #region Custom DbContext
            services.AddDbContext<QuanLyDuAnContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TayHoConnection")));
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
                        Title = "OperationManagement.Api",
                        Description = "OperationManagement.Api"
                    }
                }
            });
            #endregion Custom Swagger
        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            //builder.RegisterModule(new ApplicationModule());
        }
    }
}
