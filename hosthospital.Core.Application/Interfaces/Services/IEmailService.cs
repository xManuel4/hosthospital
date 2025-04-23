using hosthospital.Core.Application.Dtos.Email;
using hosthospital.Core.Domain.Settings;
using hosthospital.Core.Application.Dtos.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosthospital.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
        public MailSettings _mailSettings { get; }


    }
}
