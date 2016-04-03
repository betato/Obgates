using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Entity : Component
    {
        public override void step()
        {
            foreach (Component component in subcomponents)
            {
                component.step();
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
