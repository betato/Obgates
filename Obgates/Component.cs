using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Obgates
{
    abstract class Component
    {
        // Output and input states
        public List<bool> pinStates = new List<bool>();
        // Connections to wires
        public List<int> pinConnections = new List<int>();
        
        // Wires inside a component
        public List<Wire> wires = new List<Wire>();
        // Components inside a component
        public List<Component> subcomponents = new List<Component>();

        public int x;
        public int y;
        public int width;
        public int height;

        public Point pos
        {
            get { return new Point(x, y);  }
            set { x = pos.X; y = pos.Y; }
        }

        public Size size
        {
            get { return new Size(width, height); }
            set { width = size.Width; height = size.Height; }
        }

        public Rectangle rect
        {
            get { return new Rectangle(x, y, width, height); }
            set { x = pos.X; y = pos.Y; width = size.Width; height = size.Height; }
        }

        public abstract void Step();
    }
}
