namespace MailingService.ClientExpectations
{
    public interface IEmailMessageBuilder
    {
        EmailMessage PrepareEmailMessage(string base64Json);
    }
}