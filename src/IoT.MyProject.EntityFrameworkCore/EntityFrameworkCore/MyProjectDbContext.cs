using Abp.EntityFrameworkCore;
using IoT.MyProject.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IoT.MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public DbSet<Task> Tasks { get; set; }

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
