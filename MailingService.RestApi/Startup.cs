using System.Diagnostics.CodeAnalysis;

namespace MailingService.RestApi
{
    using Domains.Models;
    using Domains;
    using Domains.Impl;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(Configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>());

            services.AddSingleton(Configuration.GetSection("MefConfiguration")
                .Get<MefConfiguration>());

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IMefHelper, MefHelper>();

            IMvcBuilder builder = services.AddRazorPages();
            
            builder.AddRazorRuntimeCompilation();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if DEBUG
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
#endif

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
