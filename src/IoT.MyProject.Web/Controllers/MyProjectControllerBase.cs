using Abp.AspNetCore.Mvc.Controllers;

namespace IoT.MyProject.Web.Controllers
{
    public abstract class MyProjectControllerBase: AbpController
    {
        protected MyProjectControllerBase()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}