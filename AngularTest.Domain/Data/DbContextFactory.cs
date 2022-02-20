using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AngularTest.Domain.Data
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig = new AppConfiguration();
            var opsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            opsBuilder.UseSqlServer(appConfig.SqlConnectionString);
            return new MyDbContext(opsBuilder.Options);
        }
    }
}