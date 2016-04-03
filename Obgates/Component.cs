using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    abstract class Component
    {
        public List<bool> inputs = new List<bool>();
        public List<Output> outputs = new List<Output>();

        public List<Component> subcomponents = new List<Component>();

        public abstract void step();
    }
}
