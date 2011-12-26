using System;
using System.Threading;

namespace WpfThreading
{
    class Model
    {
        private Thread worker;
        private Random random = new Random((int) DateTime.UtcNow.Ticks);

        internal event Action<string> NewLine = delegate { }; 

        public Model()
        {
            worker = new Thread(Work) { IsBackground = true };
            worker.Start();
        }

        private void Work()
        {
            while(true)
            {
                NewLine(random.Next().ToString());
                Thread.Sleep(200);
            }
        }
    }
}
