using System;
using System.Collections.Generic;

namespace ProjectManager.CMD.Domain.IService
{
    public interface ISendMailService
    {
        void SendMailAppoinment(DateTime StartDate, DateTime EndDate, string LocationTaget, string Subject, string Body, string DisplayName, string MailFrom, List<string> MailTo, List<string> MailCC, List<string> MailBCC, bool isCancel);
        void SendMail(string Subject, string Body, string DisplayName, string MailFrom, List<string> MailTo, List<string> MailCC, List<string> MailBCC, bool IsBodyHtml = true);
    }
}
