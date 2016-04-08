using Ormin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obgates
{
    public abstract class RLoopForm : Form
    {
        public RLoopForm(int targetFps, int targetUps)
        {
            targetFpsNano = 1000000000 / targetFps;
            targetUpsNano = 1000000000 / targetUps;
        }

        static int targetFpsNano;
        static int targetUpsNano;
        NanoTime tm = new NanoTime();
        bool running;

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            running = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            running = true;
            Start();
        }

        private void Start()
        {
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
                    RenderR();
                    framecount++;
                    deltaFps = 0;
                }

                // Update
                if (deltaUps >= targetUpsNano)
                {
                    UpdateR();
                    updatecount++;
                    deltaUps = 0;
                }

                // Update fps display
                if (deltaFpsDisplay >= 1000000000)
                {
                    Console.WriteLine(String.Format("Fps:{0} Ups:{1}", framecount, updatecount));
                    framecount = 0;
                    updatecount = 0;
                    deltaFpsDisplay = 0;
                }
            }
        }

        public abstract void UpdateR();

        public abstract void RenderR();
    }
}
