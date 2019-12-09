﻿namespace MailingService.Domains
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; }

        int SmtpPort { get; }

        string SmtpUsername { get; set; }

        string SmtpPassword { get; set; }
    }
}