using System.IO;
using Microsoft.Extensions.Configuration;

namespace AngularTest.Domain.Data
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            SqlConnectionString = appSetting.Value;
        }

        public string SqlConnectionString { get; set; }

    }
}
