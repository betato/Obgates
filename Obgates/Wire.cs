using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Wire
    {
        public bool state;
        public List<Connection> connections = new List<Connection>();

        // Line visuals for designer
        public List<Line> segments = new List<Line>();

        public void RemoveConnection(int component, int pin)
        {
            // Remove first connection to pin of component
            for (int i = connections.Count - 1; i >= 0; i--)
            {
                if (connections[i].component == component &&
                    connections[i].pin == pin)
                {
                    connections.RemoveAt(i);
                    return;
                }
            }
        }

        public void RemoveConnection(int component)
        {
            // Remove all connections to component
            for (int i = connections.Count - 1; i >= 0; i--)
            {
                if (connections[i].component == component)
                {
                    connections.RemoveAt(i);
                }
            }
        }
    }
}
