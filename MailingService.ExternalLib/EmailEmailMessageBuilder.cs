using System.Composition;
using MailingService.ClientExpectations;

namespace MailingService.ExternalLib
{
    /// <summary>
    /// Class from some external System
    /// </summary>
    [Export(typeof(IEmailMessageBuilder))]
    public class EmailEmailMessageBuilder : IEmailMessageBuilder
    {
        public EmailMessage PrepareEmailMessage(string base64Json)
        {
            //TODO: Template matching
            return new EmailMessage
            {
                Content = "Sample"
            };
        }
    }
}
