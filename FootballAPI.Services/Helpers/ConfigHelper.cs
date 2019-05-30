using Microsoft.Extensions.Configuration;

namespace FootballAPI.Services.Helpers
{

    public static class ConfigHelper
    {
        public static IConfiguration GetConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }

        public static string GetToken()
        {
            var settings = GetConfig();

            return settings.GetSection("HeadersParams").GetSection("X-Auth-Token").Value;
        }


        public static string CompetitionsStandings()
        {
            var settings = GetConfig();

            return settings.GetSection("ApiConnections").GetSection("CompetitionsStandings").Value;
        }

        public static string DefaultCompetition()
        {
            var settings = GetConfig();

            return settings.GetSection("ApiConnections").GetSection("DefaultCompetition").Value;
        }

    }
    //public class AppSettings : IAppConfiguration
    //{
    //    private readonly string _competitionsStandings;
    //    private readonly string _defaultCompetition ;
    //    private readonly string _token;

    //    public AppSettings()
    //    {
    //        var configurationBuilder = new ConfigurationBuilder();
    //        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
    //        configurationBuilder.AddJsonFile(path, false);

    //        var root = configurationBuilder.Build();

    //        _competitionsStandings = root.GetSection("ApiConnections").GetSection("CompetitionsStandings").Value;
    //        _defaultCompetition = root.GetSection("ApiConnections").GetSection("DefaultCompetition").Value;
    //        _token = root.GetSection("HeadersParams").GetSection("X-Auth-Token").Value;

    //        //var appSetting = root.GetSection("ApplicationSettings");
    //    }
    //    public string CompetitionsStandings
    //    {
    //        get => _competitionsStandings;
    //    }

    //    public string DefaultCompetition
    //    {
    //        get => _defaultCompetition;
    //    }

    //    public string Token
    //    {
    //        get => _token;
    //    }
    //}
}
