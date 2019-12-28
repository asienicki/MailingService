using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Jil;
using MailingService.ClientExpectations;
using MailingService.ExternalLib;

namespace MailingService.RestApi.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

            await using var output = new StringWriter();
            
            JSON.Serialize(sampleModel, output);

            var res = output.ToString()
                .Base64Encode();

            FlurlConfiguration.ConfigureDomainForDefaultCredentials("https://localhost:44382");


            var response = await "https://localhost:44382"
               .AppendPathSegment("email")
               .SetQueryParams(new
               {
                   templateName  = "MailingService.ExternalLib.dll",
                   base64Json = res
               })
               .GetAsync();
        }
    }

    public class UseDefaultCredentialsClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler { UseDefaultCredentials = true };
        }
    }

    public static class FlurlConfiguration
    {
        public static void ConfigureDomainForDefaultCredentials(string url)
        {
            FlurlHttp.ConfigureClient(url, cli =>
                cli.Settings.HttpClientFactory = new UseDefaultCredentialsClientFactory());
        }
    }
}
