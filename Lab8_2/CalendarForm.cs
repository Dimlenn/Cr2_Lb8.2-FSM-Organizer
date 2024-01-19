using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab8;

namespace Lab8_2
{
    public partial class CalendarForm : Form
    {
        public CalendarForm(FSM<Enum, Enum> FSM)
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        Calendar calendar = new Calendar();

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            FSM.OnEvent(CalendarEvent.StartEventMaking);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (calendar.CheckEventOccured())
            {
                timer1.Stop();

                calendar.Freeze();

                timer1.Start();
            }
        }

        private void OpenEventSetter()
        {
            EventSetterForm form2 = new EventSetterForm(monthCalendar1.SelectionRange.Start, this);
            form2.Show();
        }
    }
}
