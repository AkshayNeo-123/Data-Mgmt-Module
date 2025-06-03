using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMgmtModule.Application.Interface.Persistence
{
    public interface IEmailServiceRepository
    {
        Task SendEmailAsync(string toEmail, string subject, string body, bool isHtml = true);
    }
}
