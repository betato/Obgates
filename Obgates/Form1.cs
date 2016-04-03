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

        Component sim;

        private void Form1_Load(object sender, EventArgs e)
        {
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
            sim.step();
        }
    }
}
