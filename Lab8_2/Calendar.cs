using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_2
{
    internal class Calendar
    {
        private Dictionary<DateTime, string> calendarEventsList = new Dictionary<DateTime, string>();
        public Dictionary<DateTime, string> CalendarEventsList
        {
            set
            {
                if (value.GetType() == typeof(DateTime))
                    CalendarEventsList = value;
            }
            get { return CalendarEventsList; }
        }

        public bool CheckEventOccured()
        {
            foreach (var item in CalendarEventsList)
            {
                if (item.Key.ToShortDateString() == DateTime.Now.ToShortDateString() &&
                    item.Key.Hour == DateTime.Now.Hour &&
                    item.Key.Minute == DateTime.Now.Minute)
                {
                    EventForm form3 = new EventForm(item.Value);
                    form3.Show();
                    return true;
                }
            }
            return false;
        }

        public void Freeze()
        {
            foreach (var item in CalendarEventsList)
            {
                if (item.Key.ToShortDateString() == DateTime.Now.ToShortDateString() &&
                item.Key.Hour == DateTime.Now.Hour &&
                item.Key.Minute == DateTime.Now.Minute)
                    Freeze();
            }
        }
    }
}
