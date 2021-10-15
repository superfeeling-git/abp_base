using IoT.MyProject.EntityFrameworkCore;

namespace IoT.MyProject.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MyProjectDbContext _context;

        public TestDataBuilder(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}