using Abp.Modules;
using Abp.Reflection.Extensions;
using IoT.MyProject.Localization;

namespace IoT.MyProject
{
    public class MyProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            MyProjectLocalizationConfigurer.Configure(Configuration.Localization);
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = MyProjectConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyProjectCoreModule).GetAssembly());
        }
    }
}