using Abp.Application.Services;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.Reflection.Extensions;
using IoT.MyProject.Configuration;
using IoT.MyProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using System.Reflection;

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

            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(
                typeof(MyProjectApplicationModule).Assembly, 
                moduleName: "app", 
                useConventionalHttpVerbs: true);
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
