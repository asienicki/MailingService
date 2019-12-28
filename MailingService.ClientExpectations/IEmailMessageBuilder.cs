using System.Threading.Tasks;

namespace MailingService.ClientExpectations
{
    public interface IEmailMessageBuilder
    {
        Task<EmailMessage> PrepareEmailMessage(string base64Json);
    }
}