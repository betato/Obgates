using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class Output
    {
        public bool state;
        public List<List<int>> connections = new List<List<int>>();

        public Output() { }

        public Output(bool state)
        {
            this.state = state;
        }

        public void addConnection(int component, int input)
        {
            int componentIndex = -1;
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i][0] == component)
                {
                    // Connection already includes component
                    componentIndex = i;
                }
            }

            if (componentIndex < 0) 
            {
                // Add input in for new component 
                List<int> inputList = new List<int>();
                inputList.Add(input);
                connections.Add(inputList);
            }
            else
            {
                // Add input for existing component
                connections[componentIndex].Add(input);
            }
        }
    }
}
