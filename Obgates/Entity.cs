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
            for (int i = 0; i < pins.Count; i++)
            {
                if (!wires[pins[i].connection].state)
                {
                    wires[pins[i].connection].state = pins[i].state;
                }
            }

            // Set wires attached to subcomponents
            foreach (Component component in subcomponents)
            {
                // Loop through each output
                for (int i = 0; i < component.pins.Count; i++)
                {
                    // Only set wire if false
                    if (!wires[component.pins[i].connection].state)
                    {
                        wires[component.pins[i].connection].state = component.pins[i].state;
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
                        pins[connection.pin].state = wire.state;
                    }
                    else
                    {
                        // Connected to subcomponent pins
                        subcomponents[connection.component].pins[connection.pin].state
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
            foreach (Pin pin in subcomponents[component].pins)
            {
                wires[pin.connection].RemoveConnection(component);
            }
            // Remove component
            subcomponents.RemoveAt(component);
        }

        public void AddWire(Wire wire)
        {
            // Add wire
            wires.Add(wire);
        }

        public void RemoveWire(int wire)
        {
            // Remove wire
            wires.RemoveAt(wire);

            // Remove connections
            foreach (Component subcomponent in subcomponents)
            {
                for (int i = subcomponent.pins.Count - 1; i >= 0; i--)
                {
                    if (subcomponent.pins[i].connection > wire)
                    {
                        // Decrement all connections after the removed wire
                        subcomponent.pins[i].connection--;
                    }
                    else if (subcomponent.pins[i].connection == wire)
                    {
                        // Remove connection
                        subcomponent.pins.RemoveAt(i);
                    }
                }
            }
        }
    }
}
