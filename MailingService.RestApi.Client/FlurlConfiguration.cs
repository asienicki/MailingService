using Flurl.Http;

namespace MailingService.RestApi.Client
{
    public static class FlurlConfiguration
    {
        public static void ConfigureDomainForDefaultCredentials(string url)
        {
            FlurlHttp.ConfigureClient(url, cli =>
                cli.Settings.HttpClientFactory = new UseDefaultCredentialsClientFactory());
        }
    }
}