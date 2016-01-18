using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerUI
{
    internal class Microwave : ITimerListener
    {

        public void Register(Timer.Timer timer)
        {
            timer.TimerStopped += PrintMsg;
        }

        public void Unregister(Timer.Timer timer)
        {
            timer.TimerStopped -= PrintMsg;
        }

        public void PrintMsg(object sender, SpendTimeEventArgs args)
        {
            Console.WriteLine("Food are ready");
        }
    }

    internal class AlarmClock : ITimerListener
    {
        private string msg;

        public AlarmClock(string msg)
        {
            this.msg = msg;
        }

        public void Register(Timer.Timer timer)
        {
            timer.TimerStopped += PrintMsg;
        }

        public void Unregister(Timer.Timer timer)
        {
            timer.TimerStopped -= PrintMsg;
        }

        public void PrintMsg(object sender, SpendTimeEventArgs args)
        {
            Console.WriteLine(msg, args.Seconds);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Timer.Timer timer = new Timer.Timer();
            ITimerListener[] listeners = new ITimerListener[] { new Microwave(), new AlarmClock("Microwave are stopped after {0}sec") };
            foreach(var elem in listeners)
                elem.Register(timer);
            timer.Start(1);
            foreach (var elem in listeners)
                elem.Unregister(timer);

            new AlarmClock("I'm late").Register(timer);
            timer.Start(10);

            ///Console.Read();
        }
    }
}
