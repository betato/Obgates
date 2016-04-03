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
            pinStates.Add(false);
            pinStates.Add(false);
        }

        public override void step()
        {
            pinStates[1] = pinStates[0];
        }
    }
}
