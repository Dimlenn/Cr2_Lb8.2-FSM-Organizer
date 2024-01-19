using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_2
{
    public partial class EventSetterForm : Form
    {
        DateTime date;
        CalendarForm calendar;
        public EventSetterForm(DateTime date, CalendarForm calendar)
        {
            InitializeComponent();
            this.date = new DateTime(date.Year, date.Month, date.Day);
            this.calendar = calendar;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] time = GetTime();
            DateTime dateTime = new DateTime(date.Year, date.Month, date.Day, time[0], time[1], time[2]);

            calendar.CalendarEventsList.Add(dateTime, richTextBox1.Text);
            this.Close();
        }
        private int[] GetTime()
        {
            string time = dateTimePicker1.Text;
            string[] times = time.Split(':');

            int[] timesInt = new int[times.Length];
            for (int i = 0; i < times.Length; i++) 
            {
                timesInt[i] = Convert.ToInt32(times[i]);
            }

            return timesInt;
        }
    }
}
