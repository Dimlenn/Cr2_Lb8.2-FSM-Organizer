using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8_2
{
    public static class Program
    {
        enum CalendarState
        {
            CalebdarOpen,
            EventMaking,
            EventNotify,
            EventPostpone
        }
        enum CalendarEvent
        {
            StartEventMaking,
            EventMade,
            EventOccured,
            EventPostponed,
            GoToCalendar
        }

        public static FSM<CalendarState, CalendarEvent> FSM { get; set; }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalendarForm(FSM));



            FSM = new FSM<CalendarState, CalendarEvent>(CalendarState.CalebdarOpen);

            FSM.RegisterTransitions(new Transition<CalendarState, CalendarEvent>[]
            {
                new Transition<CalendarState, CalendarEvent> { FromState = CalendarState.CalebdarOpen, ToState = CalendarState.EventMaking, Event = CalendarEvent.StartEventMaking },
                new Transition<CalendarState, CalendarEvent> { FromState = CalendarState.EventMaking, ToState = CalendarState.CalebdarOpen, Event = CalendarEvent.EventMade },

                new Transition<CalendarState, CalendarEvent> { FromState = CalendarState.CalebdarOpen, ToState = CalendarState.EventNotify, Event = CalendarEvent.EventOccured },

                new Transition<CalendarState, CalendarEvent> { FromState = CalendarState.EventNotify, ToState = CalendarState.EventPostpone, Event = CalendarEvent.EventPostponed },
                new Transition<CalendarState, CalendarEvent> { FromState = CalendarState.EventNotify, ToState = CalendarState.CalebdarOpen, Event = CalendarEvent.GoToCalendar }
            });

            FSM[CalendarState.EventMaking].OnEnter = () => calendar.OpenEventSetter();
        }
    }
}
