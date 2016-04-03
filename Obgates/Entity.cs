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
                // Loop through each output
                foreach (Output output in component.outputs)
                {
                    // Set all connected inputs to the same state
                    foreach (List<int> entityConnection in output.connections)
                    {
                        foreach (int connection in entityConnection)
                        {
                            // First int in connection is the component
                            if (!subcomponents[entityConnection[0]].inputs[connection]) {
                                // Only change if false
                                subcomponents[entityConnection[0]].inputs[connection] = output.state;
                            }
                        }
                    }
                }
            }
        }
    }
}
