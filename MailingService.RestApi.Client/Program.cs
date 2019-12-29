using System;
using System.IO;
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
    static class Program
    {
        static string emailServiceUrl = "https://localhost:44382";

        static async Task Main()
        {
            var sampleModel = new CustomViewModel
            {
                Description = "Fake description."
            };

            await using var output = new StringWriter();
            
            JSON.Serialize(sampleModel, output);

            var res = output.ToString()
                .Base64Encode();

            FlurlConfiguration.ConfigureDomainForDefaultCredentials(emailServiceUrl);
            
            var response = await emailServiceUrl
               .AppendPathSegment("email")
               .SetQueryParams(new
               {
                   templateName  = "MailingService.ExternalLib.dll",
                   base64Json = res
               })
               .GetAsync();

            Console.WriteLine(await response.Content.ReadAsStringAsync());
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
