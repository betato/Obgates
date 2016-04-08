using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ormin
{
    class NanoTime
    {
        [DllImport("KERNEL32")]
        private static extern bool QueryPerformanceCounter(
          out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        private long now;
        private long frequency;
        Decimal multiplier = new Decimal(1.0e9);

        public NanoTime()
        {
            if (QueryPerformanceFrequency(out frequency) == false)
            {
                // Frequency not supported
                throw new Win32Exception();
            }
        }

        public long Time()
        {
            QueryPerformanceCounter(out now);
            // Return time in nanoseconds
            return (long)(((double)now * (double)multiplier) / (double)frequency);
        }
    }
}
