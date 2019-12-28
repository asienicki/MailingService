using System.Composition;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Jil;
using MailingService.ClientExpectations;
using RazorLight;

namespace MailingService.ExternalLib
{
    /// <summary>
    /// Class from some external System
    /// </summary>
    [Export(typeof(IEmailMessageBuilder))]
    public class EmailMessageBuilder : IEmailMessageBuilder
    {
        public async Task<EmailMessage> PrepareEmailMessage(string base64Json)
        {
            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(EmailMessageBuilder))
                .UseMemoryCachingProvider()
                .Build();

            var template = Encoding.UTF8.GetString(EmailTemplates.Hello);

            var jsonString = base64Json.Base64Decode();

            using var input = new StringReader(jsonString);
            
            var model = JSON.Deserialize<CustomViewModel>(input);

            var result = await engine.CompileRenderStringAsync("templateKey", template, model);
            
            return new EmailMessage
            {
                Content = result
            };
        }
    }
}