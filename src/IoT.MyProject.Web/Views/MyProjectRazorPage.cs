using Abp.AspNetCore.Mvc.Views;

namespace IoT.MyProject.Web.Views
{
    public abstract class MyProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MyProjectRazorPage()
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
        }
    }
}
