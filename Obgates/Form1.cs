using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Obgates
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void StartRefreshLoop(int targetFps, int targetUps)
        {
            int targetFpsNano = 1000000000 / targetFps;
            int targetUpsNano = 1000000000 / targetUps;
            NanoTime tm = new NanoTime();

            long startTime = tm.Time();

            long deltaTime = 0;
            long deltaFps = 0;
            long deltaUps = 0;
            long deltaFpsDisplay = 0;
            int framecount = 0;
            int updatecount = 0;

            while (true)
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

        private void UpdateR()
        {
            // Update components
        }

        private void RenderR()
        {
            // Draw frame
        }

        Component sim;

        private void Form1_Load(object sender, EventArgs e)
        {
            StartRefreshLoop(60, 20);
            // Init gates
            NullGate r1 = new NullGate();
            NullGate r2 = new NullGate();
            NullGate r3 = new NullGate();

            // Add connection to wire
            r1.pinConnections.Add(0);

            // Init main component and add stuff
            sim = new Entity();   
            sim.subcomponents.Add(r1);
            sim.subcomponents.Add(r2);
            sim.subcomponents.Add(r3);

            // Add wire
            Wire w = new Wire();
            w.connections.Add(new Connection(1, 0));
            sim.wires.Add(w);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set first buffer true for testing
            sim.subcomponents[0].pinStates[0] = true;
            sim.Step();
        }
    }
}
