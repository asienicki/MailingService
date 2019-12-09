using MailingService.ClientExpectations;

namespace MailingService.Domains
{
    public interface IEmailService
    {
        void Send(EmailMessage emailMessage);
    }
}