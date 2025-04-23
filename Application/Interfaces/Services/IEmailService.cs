using Internetbanking.Core.Application.Dtos.Email;
using Internetbanking.Core.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internetbanking.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
        public MailSettings _mailSettings { get; }


    }
}
