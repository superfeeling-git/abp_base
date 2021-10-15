using Abp.Auditing;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using IoT.MyProject.Localization;
using IoT.MyProject.Log;

namespace IoT.MyProject
{
    public class MyProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            MyProjectLocalizationConfigurer.Configure(Configuration.Localization);
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = MyProjectConsts.DefaultPassPhrase;

            Configuration.ReplaceService(typeof(IAuditingStore), () => {
                IocManager.IocContainer.Register(
                  Component.For<IAuditingStore>()
                  .ImplementedBy<DBAuditStore>()
                  .LifestyleTransient()
              );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectCoreModule).GetAssembly());
        }
    }
}