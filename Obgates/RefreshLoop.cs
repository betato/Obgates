using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Obgates
{
    class RefreshLoop
    {
        public RefreshLoop(int targetFps, int targetUps)
        {
            // Set loop times
            targetFpsNano = 1000000000 / targetFps;
            targetUpsNano = 1000000000 / targetUps;
        }

        public event RenderEventHandler RenderR;
        public event UpdateEventHandler UpdateR;

        // Target loop times
        int targetFpsNano;
        int targetUpsNano;

        // Current loop times
        int fps;
        int ups;

        public delegate void RenderEventHandler(object source, int fps, int ups);
        public delegate void UpdateEventHandler(object source, int fps, int ups);

        bool running = true;

        public void Start()
        {
            // Start loop in new thread
            Thread loopThread = new Thread(new ThreadStart(RunLoop));
            loopThread.Start();
        }

        public void Exit()
        {
            // End loop
            running = false;
        }

        public void RunLoop()
        {
            NanoTime tm = new NanoTime();

            long startTime = tm.Time();

            long deltaTime = 0;
            long deltaFps = 0;
            long deltaUps = 0;
            long deltaFpsDisplay = 0;
            int framecount = 0;
            int updatecount = 0;

            while (running)
            {
                // Get current time
                long currentTime = tm.Time();
                // Get time since last loop
                deltaTime = currentTime - startTime;
                deltaFps += deltaTime;
                deltaUps += deltaTime;
                deltaFpsDisplay += deltaTime;
                // Set start time of this loop for use in next cycle
                startTime = currentTime;

                // Render
                if (deltaFps >= targetFpsNano)
                {
                    RenderR(this, fps, ups);
                    framecount++;
                    deltaFps = 0;
                }

                // Update
                if (deltaUps >= targetUpsNano)
                {
                    UpdateR(this, fps, ups);
                    updatecount++;
                    deltaUps = 0;
                }

                // Update fps display
                if (deltaFpsDisplay >= 1000000000)
                {
                    fps = framecount;
                    ups = updatecount;
                    framecount = 0;
                    updatecount = 0;
                    deltaFpsDisplay = 0;
                }
            }
        }
    }
}
