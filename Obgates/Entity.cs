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
                // Step each component
                component.step();
            }

            foreach (Wire wire in wires)
            {
                // Set each wire to unpowered
                wire.state = false;
            }

            // Set wires to their proper state
            foreach (Component component in subcomponents)
            {
                // Loop through each output
                for (int i = 0; i < component.pinConnections.Count; i++)
                {
                    // Only set wire if false
                    if (!wires[component.pinConnections[i]].state)
                    {
                        wires[component.pinConnections[i]].state = component.pinStates[i];
                    }
                }
            }

            // Set each component connected by wire
            foreach (Wire wire in wires)
            {
                foreach (Connection connection in wire.connections)
                {
                    subcomponents[connection.component].pinStates[connection.pin]
                        = wire.state;
                }
            }
        }
    }
}
