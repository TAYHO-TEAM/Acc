using Services.Common.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Services.Common.Utilities
{
    public static class SendMailOption
    {
        public static void SendMailAppoinment(DateTime StartDate, DateTime EndDate, string LocationTaget, string Subject, string Body, string DisplayName, string MailFrom, List<string> MailTo, List<string> MailCC, List<string> MailBCC, bool isCancel, ProfileMailOptions ProfileMailOption)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine("BEGIN:VCALENDAR");
            str.AppendLine("PRODID:-//Microsoft Corporation//Outlook 12.0 MIMEDIR//EN");
            str.AppendLine("VERSION:2.0");
            str.AppendLine(string.Format("METHOD:{0}", (isCancel ? "CANCEL" : "REQUEST")));
            str.AppendLine("BEGIN:VEVENT");
            str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmss}", StartDate));
            str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmss}", DateTime.UtcNow));
            str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmss}", EndDate));
            str.AppendLine("LOCATION: " + LocationTaget);
            str.AppendLine(string.Format("UID:{0}", Guid.NewGuid()));
            str.AppendLine(string.Format("DESCRIPTION:{0}", Body));
            str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", Body));
            str.AppendLine(string.Format("SUMMARY:{0}", Subject));
            str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", MailFrom, MailFrom));
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

            Attachment attach = new Attachment(stream, "Calendar.ics");


            MailMessage msg = new MailMessage();///MailFrom, string.Join(",", MailTo)
            msg.Attachments.Add(attach);
            msg.From=new MailAddress( MailFrom,"Hệ thông");
            foreach (string tomail in MailTo)
            {
                msg.To.Add(tomail);
            }
            foreach (string ccmail in MailCC)
            {
                msg.CC.Add(ccmail);
            }
            foreach (string bccmail in MailBCC)
            {
                msg.Bcc.Add(bccmail);
            }
            ContentType contype = new ContentType("text/calendar");
            contype.Parameters.Add("method", "REQUEST");
            //  contype.Parameters.Add("name", "Meeting.ics");
            AlternateView avCal = AlternateView.CreateAlternateViewFromString(str.ToString(), contype);
            msg.AlternateViews.Add(avCal);

            //Now sending a mail with attachment ICS file.                     
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = ProfileMailOption.serverName; //-------this has to given the Mailserver IP
            smtpclient.Port = ProfileMailOption.port;
            smtpclient.EnableSsl = true;
            smtpclient.Credentials = new NetworkCredential(ProfileMailOption.userName, ProfileMailOption.passWord);
            smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpclient.Send(msg);


        }

    }

}
