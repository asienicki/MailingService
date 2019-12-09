using MailingService.ClientExpectations;

namespace MailingService.RestApi
{
    public interface IMefHelper
    {
        IEmailMessageBuilder GetEmailMessageBuilderByName(string assemblyName);
    }
}