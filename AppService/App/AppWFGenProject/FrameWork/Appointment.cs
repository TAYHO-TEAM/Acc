using System;
using System.Collections.Generic;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace AppWFGenProject.FrameWork
{
    public class Appointment
    {
        private void AllDayEventExample()
        {
            Outlook.AppointmentItem appt = Application.CreateItem(
                Outlook.OlItemType.olAppointmentItem)
                as Outlook.AppointmentItem;
            appt.Subject = "Developer's Conference";
            appt.AllDayEvent = true;
            appt.Start = DateTime.Parse("6/11/2007 12:00 AM");
            appt.End = DateTime.Parse("6/16/2007 12:00 AM");
            appt.Display(false);
        }
    }
}
