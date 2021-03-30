using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IService;
using Services.Common.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Infrastructure.Service
{
    public class SendMailService : ISendMailService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpClientFactory _clientFactory;
        private readonly ProfileMailOptions _profileMailOptions;
        public SendMailService(IOptionsSnapshot<ProfileMailOptions> snapshotOptionsAccessor, IHttpClientFactory clientFactory, IWebHostEnvironment env)
        {
            _profileMailOptions = snapshotOptionsAccessor.Value;
            _clientFactory = clientFactory;
            _env = env;
        }
        public void SendMailAppoinment(DateTime StartDate, DateTime EndDate, string LocationTaget, string Subject, string Body, string DisplayName, string MailFrom, List<string> MailTo, List<string> MailCC, List<string> MailBCC, bool isCancel)
        {

            StringBuilder str = new StringBuilder();
            str.AppendLine("BEGIN:VCALENDAR");
            //str.AppendLine("PRODID:-//Microsoft Corporation//Outlook 12.0 MIMEDIR//EN");
            str.AppendLine("PRODID:" + Subject);
            str.AppendLine("VERSION:2.0");
            str.AppendLine(string.Format("METHOD:{0}", (isCancel ? "CANCEL" : "REQUEST")));
            str.AppendLine("BEGIN:VEVENT");
            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmss}", StartDate));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmss}", DateTime.UtcNow));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmss}", EndDate));
            str.AppendLine("LOCATION: " + LocationTaget);
            str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
            str.AppendLine(string.Format("DESCRIPTION:{0}", !string.IsNullOrEmpty(Body) ? Body.Replace("\n", "<br>") : Body));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", !string.IsNullOrEmpty(Body) ? Body.Replace("\n", "<br>") : Body));
            str.AppendLine(string.Format("SUMMARY:{0}", Subject));
            str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", _profileMailOptions.name, _profileMailOptions.name));
            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", string.Join(",", MailTo), string.Join(",", MailTo)));

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");


            byte[] byteArray = Encoding.ASCII.GetBytes(str.ToString());
            MemoryStream stream = new MemoryStream(byteArray);

            //Attachment attach = new Attachment(stream, "Calendar.ics");


            MailMessage msg = new MailMessage();///MailFrom, string.Join(",", MailTo)
            //msg.Attachments.Add(attach);
            msg.From = new MailAddress(_profileMailOptions.userName, _profileMailOptions.name);
            if (MailTo != null && MailTo.Count > 0)
            {
                foreach (string tomail in MailTo)
                {
                    if (!string.IsNullOrEmpty(tomail))
                        msg.To.Add(tomail);
                }
            }
            if (MailCC != null && MailCC.Count > 0)
            {
                foreach (string ccmail in MailCC)
                {
                    if (!string.IsNullOrEmpty(ccmail))
                        msg.CC.Add(ccmail);
                }
            }
            if (MailBCC != null && MailBCC.Count > 0)
            {
                foreach (string bccmail in MailBCC)
                {
                    if (!string.IsNullOrEmpty(bccmail))
                        msg.Bcc.Add(bccmail);
                }
            }
            ContentType contype = new ContentType("text/calendar");
            contype.Parameters.Add("method", "REQUEST");


            //  contype.Parameters.Add("name", "Meeting.ics");
            AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), contype);
            msg.AlternateViews.Add(avCal);

            //Now sending a mail with attachment ICS file.                     
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = _profileMailOptions.serverName; //-------this has to given the Mailserver IP
            smtpclient.Port = _profileMailOptions.port;
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = new NetworkCredential(_profileMailOptions.userName, _profileMailOptions.passWord);
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Send(msg);
        }
        public void SendMail(string Subject, string Body, string DisplayName, string MailFrom, List<string> MailTo, List<string> MailCC, List<string> MailBCC, bool IsBodyHtml = true )
        {
            MailMessage msg = new MailMessage();
            
            msg.From = new MailAddress(_profileMailOptions.userName, _profileMailOptions.name);
            if (MailTo != null && MailTo.Count > 0)
            {
                foreach (string tomail in MailTo)
                {
                    if (!string.IsNullOrEmpty(tomail))
                        msg.To.Add(tomail);
                }
            }
            if (MailCC != null && MailCC.Count > 0)
            {
                foreach (string ccmail in MailCC)
                {
                    if (!string.IsNullOrEmpty(ccmail))
                        msg.CC.Add(ccmail);
                }
            }
            if (MailBCC != null && MailBCC.Count > 0)
            {
                foreach (string bccmail in MailBCC)
                {
                    if (!string.IsNullOrEmpty(bccmail))
                        msg.Bcc.Add(bccmail);
                }
            }
            msg.Subject = string.IsNullOrEmpty(Subject)?"Thông báo hệ thống" : Subject;
            msg.Body = Body;
            msg.IsBodyHtml = IsBodyHtml;
                 
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = _profileMailOptions.serverName; //-------this has to given the Mailserver IP
            smtpclient.Port = _profileMailOptions.port;
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = new NetworkCredential(_profileMailOptions.userName, _profileMailOptions.passWord);
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Send(msg);
        }

        private static string MeetingRequestString(string from, List<string> toUsers, string subject, string desc, string location, DateTime startTime, DateTime endTime, int? eventID = null, bool isCancel = false)
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//Microsoft Corporation//Outlook 12.0 MIMEDIR//EN");
            str.AppendLine("VERSION:2.0");
            str.AppendLine(string.Format("METHOD:{0}", (isCancel ? "CANCEL" : "REQUEST")));
            str.AppendLine("BEGIN:VEVENT");

            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime.ToUniversalTime()));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmss}", DateTime.Now));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", endTime.ToUniversalTime()));
            str.AppendLine(string.Format("LOCATION: {0}", location));
            str.AppendLine(string.Format("UID:{0}", (eventID.HasValue ? "Meeting" + eventID : Guid.NewGuid().ToString())));
            str.AppendLine(string.Format("DESCRIPTION:{0}", desc.Replace("\n", "<br>")));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", desc.Replace("\n", "<br>")));
            str.AppendLine(string.Format("SUMMARY:{0}", subject));

            str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", from, from));
            str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", string.Join(",", toUsers), string.Join(",", toUsers)));

            str.AppendLine("BEGIN:VALARM");
            str.AppendLine("TRIGGER:-PT15M");
            str.AppendLine("ACTION:DISPLAY");
            str.AppendLine("DESCRIPTION:Reminder");
            str.AppendLine("END:VALARM");
            str.AppendLine("END:VEVENT");
            str.AppendLine("END:VCALENDAR");

            return str.ToString();
        }
    }
}
