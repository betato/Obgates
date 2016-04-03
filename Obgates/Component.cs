using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public abstract void Step();
    }
}
