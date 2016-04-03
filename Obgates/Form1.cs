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
            Component r1 = new Component();
            r1.connections.Add(1);
            Component r2 = new Component();
            r2.connections.Add(2);
            Component r3 = new Component();

            sim = new Component();
            sim.subcomponents.Add(r1);
            sim.subcomponents.Add(r2);
            sim.subcomponents.Add(r3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sim.subcomponents[0].input = true;
            sim.step();
        }
    }
}
