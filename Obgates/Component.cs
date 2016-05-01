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
        // Component inputs and outputs
        public List<Pin> pins = new List<Pin>();

        // Wires inside a component
        public List<Wire> Wires
        {
            get { return wires; }
            set
            {
                wires = Wires;

                wirePoints = 0;
                foreach (Wire wire in wires)
                {
                    wirePoints += wire.segments.Count();
                }
                wirePoints *= 4;
            }
        }
        private List<Wire> wires = new List<Wire>();

        // Components inside a component
        public List<Component> Subcomponents
        {
            get { return subcomponents; }
            set
            {
                subcomponents = Subcomponents;

                pinPoints = 0;
                componentPoints = subcomponents.Count() * 2;
                foreach (Component subcomponent in subcomponents)
                {
                    pinPoints += subcomponent.pins.Count();
                }
            }
        }
        private List<Component> subcomponents = new List<Component>();

        // Points needed for rendering
        public int wirePoints;
        public int componentPoints;
        public int pinPoints;

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
