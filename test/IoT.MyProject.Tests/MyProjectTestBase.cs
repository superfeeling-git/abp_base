using System;
using System.Threading.Tasks;
using Abp.TestBase;
using IoT.MyProject.EntityFrameworkCore;
using IoT.MyProject.Tests.TestDatas;

namespace IoT.MyProject.Tests
{
    public class MyProjectTestBase : AbpIntegratedTestBase<MyProjectTestModule>
    {
        public MyProjectTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MyProjectDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MyProjectDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MyProjectDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MyProjectDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MyProjectDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MyProjectDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MyProjectDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MyProjectDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
