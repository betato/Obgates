using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections.ObjectModel;

namespace Obgates
{
    abstract class Component
    {
        public Component()
        {
            wires.CollectionChanged += wires_CollectionChanged;
            subcomponents.CollectionChanged += subcomponents_CollectionChanged;
        }

        void wires_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            wirePoints = 0;
            foreach (Wire wire in wires)
            {
                wirePoints += wire.segments.Count();
            }
            wirePoints *= 2;
        }

        void subcomponents_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            pinPoints = 0;
            componentPoints = subcomponents.Count() * 4;
            foreach (Component subcomponent in subcomponents)
            {
                pinPoints += subcomponent.pins.Count();
            }
        }

        // Component inputs and outputs
        public List<Pin> pins = new List<Pin>();

        // Wires inside a component
        public ObservableCollection<Wire> wires = new ObservableCollection<Wire>();

        // Components inside a component
        public ObservableCollection<Component> subcomponents = new ObservableCollection<Component>();

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
