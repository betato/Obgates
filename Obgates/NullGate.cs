using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class NullGate : Component
    {
        public NullGate()
        {
            inputs.Add(false);
            outputs.Add(new Output());
        }

        public override void step()
        {
            outputs[0].state = inputs[0];
        }
    }
}
