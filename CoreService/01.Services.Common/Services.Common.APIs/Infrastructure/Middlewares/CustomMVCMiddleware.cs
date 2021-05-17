using AspNetCore.RouteAnalyzer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Services.Common.APIs.Infrastructure
{
    public static class CustomMVCMiddleware
    {
        public static IApplicationBuilder UseCustomMvc(this IApplicationBuilder app, IConfiguration configuration, bool requireAuthentication = false)
        {
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCustomSwagger();
            app.UseCustomExceptionHandler();
            app.UseCustomLocalization(configuration);
            //app.UseCustomHealthChecks();
            app.UseMiddleware<CustomJwtMiddleware>();
            //app.UseMiddleware<CustomUserBlackListMiddleware>();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRouteAnalyzer("/routes");
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapDefaultControllerRoute();
            });
            //app.UseConsul();
            return app;
        }
    }
}