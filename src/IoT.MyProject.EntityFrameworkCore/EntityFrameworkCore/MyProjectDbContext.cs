using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IoT.MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
