using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Entity : Component
    {
        public override void Step()
        {
            // Step each component
            foreach (Component component in subcomponents)
            {
                component.Step();
            }

            // Set all wires to unpowered
            foreach (Wire wire in wires)
            {
                wire.state = false;
            }

            // Set all wires from input pins and components
            SetWires();

            // Set all components connected to wires
            SetPins();
        }

        private void SetWires()
        {
            // Set wires attached to input pins
            for (int i = 0; i < pinConnections.Count; i++)
            {
                if (!wires[pinConnections[i]].state)
                {
                    wires[pinConnections[i]].state = pinStates[i];
                }
            }

            // Set wires attached to subcomponents
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
        }

        private void SetPins()
        {
            // Set each component connected to wire
            foreach (Wire wire in wires)
            {
                foreach (Connection connection in wire.connections)
                {
                    if (connection.component < 0)
                    {
                        // Connected to component pins
                        pinStates[connection.pin] = wire.state;
                    }
                    else
                    {
                        // Connected to subcomponent pins
                        subcomponents[connection.component].pinStates[connection.pin]
                        = wire.state;
                    }
                }
            }
        }

        public void AddComponent(Component component)
        {
            // Add component
            subcomponents.Add(component);
        }

        public void RemoveComponent(int component)
        {
            // Remove connections
            foreach (int pinConnection in subcomponents[component].pinConnections)
            {
                wires[pinConnection].RemoveConnection(component);
            }
            // Remove component
            subcomponents.RemoveAt(component);
        }
    }
}
