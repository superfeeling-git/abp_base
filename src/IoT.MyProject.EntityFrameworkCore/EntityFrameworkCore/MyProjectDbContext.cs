using Abp.EntityFrameworkCore;
using IoT.MyProject.Log;
using IoT.MyProject.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IoT.MyProject.EntityFrameworkCore
{
    public class MyProjectDbContext : AbpDbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<MyLogAudited> MyLogAudited { get; set; }

        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
