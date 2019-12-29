using System.Net.Http;
using Flurl.Http.Configuration;

namespace MailingService.RestApi.Client
{
    public class UseDefaultCredentialsClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler { UseDefaultCredentials = true };
        }
    }
}