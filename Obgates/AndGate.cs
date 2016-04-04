using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obgates
{
    class AndGate : Component
    {
        public AndGate()
        {
            pinStates.Add(false);
            pinStates.Add(false);
            pinStates.Add(false);
        }

        public override void Step()
        {
            pinStates[2] = pinStates[1] && pinStates[0];
        }
    }
}
