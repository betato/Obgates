using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Pin
    {
        public Pin() { }

        public Pin(bool state)
        {
            this.state = state;
        }

        public Pin(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Pin(bool state, int x, int y)
        {
            this.state = state;
            this.x = x;
            this.y = y;
        }

        // Output or input state
        public bool state;
        // Connection to wire
        public int connection;

        // Pin location
        public int x;
        public int y;

        public Point pos
        {
            get { return new Point(x, y); }
            set { x = pos.X; y = pos.Y; }
        }
    }
}
