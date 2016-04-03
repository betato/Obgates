using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Component
    {
        public bool input;
        public bool output;

        public List<Component> subcomponents = new List<Component>();
        public List<int> connections = new List<int>();

        public void step()
        {
            foreach (Component component in subcomponents)
            {
                if (component.input == true)
                {
                    component.output = true;
                }
            }

            foreach (Component component in subcomponents)
            {
                foreach (int connection in component.connections)
                {
                    if (component.output == true)
                    {
                        subcomponents[connection].input = true;
                    }
                }
            }
        }
    }
}
