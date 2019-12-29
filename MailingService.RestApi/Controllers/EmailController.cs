using System.Threading.Tasks;
using MailingService.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MailingService.RestApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IMefHelper _mefHelper;

        public EmailController(IEmailService emailService, IMefHelper mefHelper)
        {
            _emailService = emailService;
            _mefHelper = mefHelper;
        }

        /// <summary>
        /// test sample
        /// </summary>
        /// <param name="templateName"></param>
        /// <param name="base64Json"></param>
        public async Task<IActionResult> Get(string templateName, string base64Json)
        {
            if (string.IsNullOrWhiteSpace(templateName) || string.IsNullOrWhiteSpace(base64Json))
            {
                return BadRequest();
            }

            var clientAssembly = _mefHelper.GetEmailMessageBuilderByName(templateName);

            var emailMessage = await clientAssembly.PrepareEmailMessage(base64Json);

            _emailService.Send(emailMessage);

            return Ok(emailMessage.Content);
        }
    }
}