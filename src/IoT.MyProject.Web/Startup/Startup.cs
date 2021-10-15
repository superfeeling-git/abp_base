using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using IoT.MyProject.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IoT.MyProject.Web.Startup
{
    public class Startup
    {
    
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Startup(IWebHostEnvironment env)
        {
            _hostingEnvironment = env;
        }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            services.AddAbpDbContext<MyProjectDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwagger();

            //Configure Abp and Dependency Injection
            return services.AddAbp<MyProjectWebModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig(
                        _hostingEnvironment.IsDevelopment()
                            ? "log4net.config"
                            : "log4net.Production.config"
                        )
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/V1/swagger.json", "通用模块");
                    c.SwaggerEndpoint("/swagger/gp/swagger.json", "登录模块");
                    c.SwaggerEndpoint("/swagger/mom/swagger.json", "业务模块");
                    c.SwaggerEndpoint("/swagger/dm/swagger.json", "其他模块");

                    //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉，如果你想换一个路径，直接写名字即可，比如直接写c.RoutePrefix = "doc";
                    c.RoutePrefix = "";
                });
            }

            app.UseAbp(); //Initializes ABP framework.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
