﻿using MailingService.Domains;
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
        public void Get(string templateName = "MailingService.ExternalLib.dll", string base64Json = null)
        {
            var clientAssembly = _mefHelper.GetEmailMessageBuilderByName(templateName);

            var emailMessage = clientAssembly.PrepareEmailMessage(base64Json);

            //TODO: HangFire
            _emailService.Send(emailMessage);
        }
    }
}