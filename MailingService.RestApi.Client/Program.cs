using System;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
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

            var res = sampleModel.SerializeAndEncode();

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
}