using Abp.Application.Services;

namespace IoT.MyProject
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MyProjectAppServiceBase : ApplicationService
    {
        protected MyProjectAppServiceBase()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}