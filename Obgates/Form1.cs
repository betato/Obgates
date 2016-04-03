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
            NullGate r1 = new NullGate();
            Output o1 = new Output();
            o1.addConnection(1, 0);
            r1.outputs.Add(o1);

            NullGate r2 = new NullGate();

            NullGate r3 = new NullGate();

            sim = new Entity();   
            sim.subcomponents.Add(r1);
            sim.subcomponents.Add(r2);
            sim.subcomponents.Add(r3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sim.subcomponents[0].inputs[0] = true;
            sim.step();
        }
    }
}
