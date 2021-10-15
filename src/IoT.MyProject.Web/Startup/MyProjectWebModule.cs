using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IoT.MyProject.Configuration;
using IoT.MyProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;

namespace IoT.MyProject.Web.Startup
{
    [DependsOn(
        typeof(MyProjectApplicationModule), 
        typeof(MyProjectEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MyProjectWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyProjectWebModule(IWebHostEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MyProjectConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MyProjectNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MyProjectApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectWebModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyProjectWebModule).Assembly);
        }
    }
}
