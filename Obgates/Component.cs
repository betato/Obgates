using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    abstract class Component
    {
        public bool input;
        public bool output;

        public List<Component> subcomponents = new List<Component>();
        public List<int> connections = new List<int>();

        public abstract void step();
    }
}
