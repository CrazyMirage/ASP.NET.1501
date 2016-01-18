using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Timer
{
    public interface ITimerListener
    {
        void Register(Timer timer);
        void Unregister(Timer timer);
    }

    public sealed class SpendTimeEventArgs : EventArgs
    {
        private readonly int seconds;

        public SpendTimeEventArgs(int seconds)
        {
            this.seconds = seconds;
        }

        public int Seconds
        {
            get { return seconds; }
        }

    }

    public class Timer
    {
        public event EventHandler<SpendTimeEventArgs> TimerStopped = delegate { };
        public virtual void Start(int seconds)
        {
            Thread.Sleep(seconds * 1000);
            StoppedOn(seconds);
        }

        protected virtual void StoppedOn(int time)
        {
            TimerStopped(this, new SpendTimeEventArgs(time));
        }
    }
}
