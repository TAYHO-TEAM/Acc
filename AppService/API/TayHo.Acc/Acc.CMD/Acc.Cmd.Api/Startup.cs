using Acc.Cmd.Api.Infrastructure.AutofacModules;
using Acc.Cmd.Infrastructure;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Common.APIs;
using Services.Common.APIs.Cmd.EF;
using Services.Common.APIs.Infrastructure.Configuration;
using Services.Common.APIs.Infrastructure.DIServiceConfigurations;
using Services.Common.Options;
using System.Collections.Generic;


namespace Acc.Cmd.Api
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
                        Title = "Acc.Cmd.Api",
                        Description = "Acc.Cmd.Api"
                    }
                }
            });
            services.AddRazorPages(options =>
                {
                    options.Conventions
                        .AddPageApplicationModelConvention("/StreamedSingleFileUploadDb",
                            model =>
                            {
                                model.Filters.Add(
                                    new GenerateAntiforgeryTokenCookieAttribute());
                                model.Filters.Add(
                                    new DisableFormValueModelBindingAttribute());
                            });
                    options.Conventions
                        .AddPageApplicationModelConvention("/StreamedSingleFileUploadPhysical",
                            model =>
                            {
                                model.Filters.Add(
                                    new GenerateAntiforgeryTokenCookieAttribute());
                                model.Filters.Add(
                                    new DisableFormValueModelBindingAttribute());
                            });
                });

            #endregion Custom Swagger
            #region Http

            //services.AddHttpClient();

            #endregion http

        }

        public override void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterModule(new ApplicationModule());
        }
    }
}
