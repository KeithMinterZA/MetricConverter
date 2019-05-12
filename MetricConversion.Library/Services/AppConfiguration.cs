using Microsoft.Extensions.Configuration;

namespace MetricConverter.Library.Services
{
    /// <summary>
    /// The purpose of this custom configuration class is to abstract the IConfiguration interface so that it can be mocked for unit testing
    /// IConfiguration GetValue methods are extension methods which cannot be mocked
    /// </summary>
    public class AppConfiguration : IAppConfiguration
    {
        private IConfiguration Config { get; }
        public AppConfiguration(IConfiguration config)
        {
            Config = config;
        }

        public virtual string GetString(string key)
        {
            return Config.GetValue<string>(key);
        }
    }
}
