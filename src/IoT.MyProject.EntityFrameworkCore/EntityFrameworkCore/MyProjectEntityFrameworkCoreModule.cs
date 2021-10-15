using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Logging;

namespace IoT.MyProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(MyProjectCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class MyProjectEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            Logger.Info("EF Core模块启动");

            //基于程序集的注册
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectEntityFrameworkCoreModule).GetAssembly());
        }
    }
}